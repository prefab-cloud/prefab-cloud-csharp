using Microsoft.VisualStudio.TestTools.UnitTesting;

using PrefabCloud.Test.Types;

namespace PrefabCloud.Test
{
	[TestClass]
	public class FeatureFlagTest
	{
		[TestMethod]
		public void FeatureFlagIsOn()
		{
			var client = new TestPrefabCloudClient();
			var featureFlag = client.FeatureFlag( "foo" );
			Assert.IsFalse( featureFlag.IsOn() );

			client.ConfigValue( "foo", new Prefab.ConfigValue { FeatureFlag = new Prefab.FeatureFlag { Pct = 1 } } );
			Assert.IsTrue( featureFlag.IsOn() );
		}
	}
}
