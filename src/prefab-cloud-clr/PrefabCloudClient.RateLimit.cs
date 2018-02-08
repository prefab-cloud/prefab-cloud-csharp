using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrefabCloud
{
	public partial class PrefabCloudClient
	{
		protected void RateLimitInit()
		{
			m_rateLimitServiceClient = new Prefab.RateLimitService.RateLimitServiceClient( m_channel );
		}

		protected void RateLimitDispose()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="groups"></param>
		/// <param name="acquireAmount"></param>
		/// <param name="allowPartialResponse"></param>
		/// <returns></returns>
		public async Task RateLimitCheck( IEnumerable<string> groups, int acquireAmount, bool allowPartialResponse = false )
		{
			var req = new Prefab.LimitRequest
			{
				AccountId = m_apiKey.AccountId,
				AcquireAmount = acquireAmount,
				AllowPartialResponse = allowPartialResponse,
			};

			req.Groups.AddRange( groups );

			await m_rateLimitServiceClient.LimitCheckAsync( req, deadline: Deadline() );
		}
	}
}
