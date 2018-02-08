using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

using Grpc.Core;

using Prefab;

namespace PrefabCloud
{
	public partial class PrefabCloudClient
	{
		protected ConcurrentDictionary<string, ConfigDelta> m_configDeltaMap = new ConcurrentDictionary<string, ConfigDelta>();

		protected Thread m_configGetThread;
		protected CancellationTokenSource m_configGetCancellationTokenSource;


		protected void ConfigInit()
		{
			m_configServiceClient = new Prefab.ConfigService.ConfigServiceClient( m_channel );

			m_configGetCancellationTokenSource = new CancellationTokenSource();
			m_configGetThread = new Thread( () => ConfigGet() );
			m_configGetThread.Start();
		}

		protected void ConfigDispose()
		{
			m_configGetCancellationTokenSource.Cancel();
			m_configGetThread.Join();
		}

		protected void ConfigGet( long? startAtId = null, DateTime? deadline = null )
		{
			var req = new Prefab.ConfigServicePointer { AccountId = m_apiKey.AccountId };

			if (startAtId.HasValue)
			{
				req.StartAtId = startAtId.Value;
			}

			var res = m_configServiceClient.GetConfig( req, deadline: deadline ).ResponseStream;

			try
			{
				while (res.MoveNext( m_configGetCancellationTokenSource.Token ).Result)
				{
					foreach (var cfgDelta in res.Current.Deltas)
					{
						if (cfgDelta.Value != null)
						{
							m_configDeltaMap.AddOrUpdate( cfgDelta.Key, cfgDelta, ( a, b ) => cfgDelta );
						}
						else
						{
							ConfigDelta removed;
							m_configDeltaMap.TryRemove( cfgDelta.Key, out removed );
						}
					}
				}
			}
			catch (RpcException x)
			{
				if (x.Status.StatusCode != StatusCode.DeadlineExceeded)
				{
					throw;
				}
			}
			catch
			{
			}
		}

		public static string ConfigKey( string key, string @namespace = null )
		{
			return ((string.IsNullOrEmpty( @namespace ) ? "" : (@namespace + ":")) + key);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		/// <param name="namespace"></param>
		/// <param name="previousKey"></param>
		/// <returns></returns>
		public async Task ConfigUpsert( string key, Prefab.ConfigValue value, string @namespace = null, string previousKey = null )
		{
			var configDelta = new Prefab.ConfigDelta()
			{
				Key = ConfigKey( key, @namespace ),
				Value = value
			};

			var req = new Prefab.UpsertRequest
			{
				AccountId = m_apiKey.AccountId,
				ConfigDelta = configDelta,
			};

			if (!string.IsNullOrEmpty( previousKey ))
			{
				req.PreviousKey = previousKey;
			}

			await m_configServiceClient.UpsertAsync( req, deadline: Deadline() );
		}

		public ConfigValue ConfigValue( string key, Prefab.ConfigValue.TypeOneofCase type = Prefab.ConfigValue.TypeOneofCase.None )
		{
			ConfigValue result = null;

			ConfigDelta cfgDelta;

			if (m_configDeltaMap.TryGetValue( key, out cfgDelta )
					&& cfgDelta.Value != null
					&& (type == Prefab.ConfigValue.TypeOneofCase.None || cfgDelta.Value.TypeCase == type))
			{
				result = cfgDelta.Value;
			}

			return result;
		}

		public Types.FeatureFlag FeatureFlag( string name )
		{
			return new Types.FeatureFlagObject( this, name );
		}
	}
}
