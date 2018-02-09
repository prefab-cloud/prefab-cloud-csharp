# prefab-cloud-csharp
Prefab Cloud .NET Core client

Sample usage:
```c#
using (var client = new PrefabCloud.PrefabCloudClient( "<api-key>" ))
{
  Console.WriteLine( client.FeatureFlag( "example" ).IsOn() );
}
```
