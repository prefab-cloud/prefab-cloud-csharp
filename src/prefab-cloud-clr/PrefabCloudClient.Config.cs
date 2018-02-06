using System.Threading.Tasks;

using Grpc.Core;

using Prefab;

namespace PrefabCloud
{
	public partial class PrefabCloudClient
	{
		public AsyncServerStreamingCall<ConfigDeltas> ConfigGet( long? startAtId = null )
		{
			var req = new Prefab.ConfigServicePointer { AccountId = m_apiKey.AccountId };

			if (startAtId.HasValue)
			{
				req.StartAtId = startAtId.Value;
			}

			return m_configServiceClient.GetConfig( req );
		}

		public async Task ConfigUpsert( string key, Prefab.ConfigValue value, string @namespace = null, string previousKey = null )
		{
			var configDelta = new Prefab.ConfigDelta()
			{
				Key = (string.IsNullOrEmpty( @namespace ) ? "" : (@namespace + ":")) + key,
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

			await m_configServiceClient.UpsertAsync( req );
		}
	}
}
