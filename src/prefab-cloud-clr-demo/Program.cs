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
