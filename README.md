# prefab-cloud-csharp
https://www.prefab.cloud/  .NET client

FeatureFlags & RateLimits as a service

## Sample usage:
```c#
using (var client = new PrefabCloud.PrefabCloudClient( "<api-key>" ))
{
  Console.WriteLine( client.FeatureFlag( "example" ).IsOn() );
}
```

## NuGet
https://www.nuget.org/packages/prefab-cloud-clr
