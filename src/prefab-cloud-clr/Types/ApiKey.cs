namespace PrefabCloud.Types
{
	public class ApiKey
	{
		public int AccountId { get; protected set; }
		public string Value { get; protected set; }


		public ApiKey( string key )
		{
			this.AccountId = int.Parse( key.Split( '|' )[0] );
			this.Value = key;
		}

		public static implicit operator ApiKey( string s )
		{
			return new ApiKey( s );
		}

		public static implicit operator string( ApiKey apiKey )
		{
			return apiKey.Value;
		}
	}
}
