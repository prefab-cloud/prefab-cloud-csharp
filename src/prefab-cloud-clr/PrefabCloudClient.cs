using System;
using System.Threading.Tasks;

using Grpc.Core;

using PrefabCloud.Types;

namespace PrefabCloud
{
	/// <summary>
	/// Prefab Cloud client
	/// </summary>
	public partial class PrefabCloudClient : IDisposable
	{
		protected Prefab.RateLimitService.RateLimitServiceClient m_rateLimitServiceClient;
		protected Prefab.ConfigService.ConfigServiceClient m_configServiceClient;

		protected Channel m_channel;

		protected ApiKey m_apiKey;
		public ApiKey ApiKey { get { return m_apiKey; } }

		protected TimeSpan m_timeout;


		protected PrefabCloudClient()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="apiKey">API key</param>
		/// <param name="host">default - api.prefab.cloud:8443</param>
		/// <param name="timeout">default - 1s</param>
		public PrefabCloudClient( ApiKey apiKey, string host = @"api.prefab.cloud:8443", TimeSpan? timeout = null )
		{
			m_apiKey = apiKey;
			m_timeout = timeout ?? TimeSpan.FromSeconds( 2 );

			var channelCredentials = new Grpc.Core.SslCredentials();
			m_channel = new Channel( host, ChannelCredentials.Create(
				channelCredentials,
				CallCredentials.FromInterceptor( new AsyncAuthInterceptor( ( a, b ) => Task.Run( () => b.Add( "auth", m_apiKey ) ) ) ) ) );

			RateLimitInit();
			ConfigInit();
		}

		protected DateTime Deadline()
		{
			return DateTime.UtcNow.Add( m_timeout );
		}

		public virtual void Close()
		{
			ConfigDispose();
			RateLimitDispose();

			m_channel.ShutdownAsync().Wait();
		}

		public void Dispose()
		{
			Close();
		}
	}
}
