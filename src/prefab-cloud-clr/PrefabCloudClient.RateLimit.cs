using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrefabCloud
{
	public partial class PrefabCloudClient
	{
		public async Task RateLimitCheck( IEnumerable<string> groups, int acquireAmount, bool allowPartialResponse = false )
		{
			var req = new Prefab.LimitRequest
			{
				AccountId = m_apiKey.AccountId,
				AcquireAmount = acquireAmount,
				AllowPartialResponse = allowPartialResponse,
			};

			req.Groups.AddRange( groups );

			await m_rateLimitServiceClient.LimitCheckAsync( req );
		}
	}
}
