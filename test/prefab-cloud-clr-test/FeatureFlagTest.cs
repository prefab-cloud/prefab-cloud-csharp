using Microsoft.VisualStudio.TestTools.UnitTesting;

using PrefabCloud.Test.Types;

namespace PrefabCloud.Test
{
	[TestClass]
	public class FeatureFlagTest
	{
		string featureName = "FlagName";
		string lookupKeyHashHi = "hashes high";
		string lookupKeyHashLo = "hashes low";
		string lookupKeyAny = "anything";


		[TestMethod]
		public void FeatureFlagIsOn()
		{
			var client = new TestPrefabCloudClient();
			var featureFlag = client.FeatureFlag( featureName );
			Assert.IsFalse( featureFlag.IsOn() );

			client.ConfigValue( featureName, new Prefab.ConfigValue { FeatureFlag = new Prefab.FeatureFlag { Pct = 1 } } );
			Assert.IsTrue( featureFlag.IsOn() );

			Assert.IsTrue( featureFlag.IsOn( lookupKeyHashHi ) );
			Assert.IsTrue( featureFlag.IsOn( lookupKeyHashLo ) );
		}

		[TestMethod]
		public void FeatureFlagNotIsOn()
		{
			var client = new TestPrefabCloudClient();
			var featureFlag = client.FeatureFlag( featureName );
			client.ConfigValue( featureName, new Prefab.ConfigValue { FeatureFlag = new Prefab.FeatureFlag { Pct = 0 } } );

			Assert.IsFalse( featureFlag.IsOn( lookupKeyHashHi ) );
			Assert.IsFalse( featureFlag.IsOn( lookupKeyHashLo ) );
		}

		[TestMethod]
		public void FeatureFlagPct()
		{
			var client = new TestPrefabCloudClient();
			var featureFlag = client.FeatureFlag( featureName );
			client.ConfigValue( featureName, new Prefab.ConfigValue { FeatureFlag = new Prefab.FeatureFlag { Pct = 0.5 } } );

			Assert.IsFalse( featureFlag.IsOn( lookupKeyHashHi ) );
			Assert.IsTrue( featureFlag.IsOn( lookupKeyHashLo ) );
		}

		[TestMethod]
		public void FeatureFlagWhitelist()
		{
			var client = new TestPrefabCloudClient();
			var featureFlag = client.FeatureFlag( featureName );
			client.ConfigValue( featureName, new Prefab.ConfigValue { FeatureFlag = new Prefab.FeatureFlag { Pct = 0 } } );

			featureFlag.Value.Whitelisted.AddRange( new string[] { "beta", "user:1", "user:3" } );

			Assert.IsFalse( featureFlag.IsOn( lookupKeyAny ) );
			Assert.IsTrue( featureFlag.IsOn( lookupKeyAny, new string[] { "beta" } ) );
			Assert.IsTrue( featureFlag.IsOn( lookupKeyAny, new string[] { "alpha", "beta" } ) );
			Assert.IsTrue( featureFlag.IsOn( lookupKeyAny, new string[] { "alpha", "user:1" } ) );
			Assert.IsFalse( featureFlag.IsOn( lookupKeyAny, new string[] { "alpha", "user:2" } ) );
		}
	}
}
