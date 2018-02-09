using System;

namespace PrefabCloud.Demo
{
	class Program
	{
		static void Main( string[] args )
		{
			try
			{
				using (var client = new PrefabCloud.PrefabCloudClient( "<api-key>" ))
				{
					client.ConfigUpsert( "foo", new Prefab.ConfigValue { Int = 123 } ).Wait();
					client.ConfigUpsert( "foo", new Prefab.ConfigValue { String = "foo-value" }, "foons" ).Wait();

					var featureFlag = client.FeatureFlag( "example" );
					Console.WriteLine( featureFlag.IsOn() );
				}
			}
			catch (Exception x)
			{
				Console.WriteLine( x );
			}

			Console.WriteLine( "press any key..." );
			Console.ReadKey( true );
		}
	}
}
