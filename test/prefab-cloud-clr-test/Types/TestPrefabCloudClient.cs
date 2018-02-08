using Prefab;

namespace PrefabCloud.Test.Types
{
	class TestPrefabCloudClient : PrefabCloudClient
	{
		public override void Close()
		{
		}

		public void ConfigValue( string name, ConfigValue value )
		{
			var cfgDelta = new ConfigDelta { Key = name, Value = value };
			m_configDeltaMap.AddOrUpdate( name, cfgDelta, ( a, b ) => cfgDelta );
		}
	}
}
