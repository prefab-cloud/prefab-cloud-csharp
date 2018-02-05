using System;
using System.Threading.Tasks;

using Grpc.Core;

using PrefabCloud.Types;

namespace PrefabCloud
{
	public partial class PrefabCloudClient : IDisposable
	{
		protected Prefab.RateLimitService.RateLimitServiceClient m_rateLimitServiceClient;
		protected Prefab.ConfigService.ConfigServiceClient m_configServiceClient;

		protected Channel m_channel;

		protected ApiKey m_apiKey;


		public PrefabCloudClient( ApiKey apiKey, string host = @"api.prefab.cloud:8443" )
		{
			m_apiKey = apiKey;

			var channelCredentials = new Grpc.Core.SslCredentials();
			m_channel = new Channel( host, ChannelCredentials.Create(
				channelCredentials,
				CallCredentials.FromInterceptor( new AsyncAuthInterceptor( ( a, b ) => Task.Run( () => b.Add( "auth", m_apiKey ) ) ) ) ) );

			m_rateLimitServiceClient = new Prefab.RateLimitService.RateLimitServiceClient( m_channel );
			m_configServiceClient = new Prefab.ConfigService.ConfigServiceClient( m_channel );
		}

		public void Dispose()
		{
			m_channel.ShutdownAsync().Wait();
		}
	}
}
