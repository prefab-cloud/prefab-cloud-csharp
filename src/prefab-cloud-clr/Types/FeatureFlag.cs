using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefabCloud.Types
{
	public abstract class FeatureFlag
	{
		protected PrefabCloudClient m_client;
		protected string m_name;

		protected Prefab.FeatureFlag m_shadowValue = new Prefab.FeatureFlag();
		public Prefab.FeatureFlag Value
		{
			get
			{
				var cfgValue = m_client.ConfigValue( m_name, Prefab.ConfigValue.TypeOneofCase.FeatureFlag );
				return (cfgValue != null ? cfgValue.FeatureFlag : m_shadowValue);
			}
		}


		protected double GetUserPct( string lookupKey )
		{
			var hash = Murmur.MurmurHash.Create32().ComputeHash( Encoding.ASCII.GetBytes( $"{m_client.ApiKey.AccountId}{m_name}{lookupKey}" ) );

			return ((double)(uint)(hash[0] | (hash[1] << 8) | (hash[2] << 16) | (hash[3] << 24)) / (uint.MaxValue - 1));
		}

		public bool IsOn( string lookupKey = null, IEnumerable<string> attributes = null )
		{
			bool result = false;

			var cfgValue = m_client.ConfigValue( m_name, Prefab.ConfigValue.TypeOneofCase.FeatureFlag );

			if (cfgValue != null)
			{
				var attrList = new List<string>();

				if (attributes != null)
				{
					attrList.AddRange( attributes );
				}

				if (lookupKey != null)
				{
					attrList.Add( lookupKey );
				}

				if (attrList.Join( cfgValue.FeatureFlag.Whitelisted, a => a, b => b, ( a, b ) => a ).Any())
				{
					return true;
				}

				if (lookupKey != null)
				{
					return (GetUserPct( lookupKey ) < cfgValue.FeatureFlag.Pct);
				}

				result = cfgValue.FeatureFlag.Pct > new Random().NextDouble();
			}

			return result;
		}

		public async Task Upsert()
		{
			await m_client.ConfigUpsert( m_name, new Prefab.ConfigValue { FeatureFlag = Value } );
		}
	}

	class FeatureFlagObject : FeatureFlag
	{
		public FeatureFlagObject( PrefabCloudClient client, string name )
		{
			m_client = client;
			m_name = name;
		}
	}
}
