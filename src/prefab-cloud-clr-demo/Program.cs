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
