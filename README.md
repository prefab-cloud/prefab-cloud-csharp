# prefab-cloud-csharp
Prefab Cloud .NET client

## Sample usage:
```c#
using (var client = new PrefabCloud.PrefabCloudClient( "<api-key>" ))
{
  Console.WriteLine( client.FeatureFlag( "example" ).IsOn() );
}
```

## NuGet
https://www.nuget.org/packages/prefab-cloud-clr
