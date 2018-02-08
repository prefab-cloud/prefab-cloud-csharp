namespace PrefabCloud.Types
{
	public abstract class FeatureFlag
	{
		protected PrefabCloudClient m_client;
		protected string m_name;


		public bool IsOn()
		{
			var cfgValue = m_client.ConfigValue( m_name, Prefab.ConfigValue.TypeOneofCase.FeatureFlag );

			return (cfgValue != null && cfgValue.FeatureFlag.Pct > 0);
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
