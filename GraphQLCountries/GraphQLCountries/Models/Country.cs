namespace GraphQLCountries.Models
{
	public class Country
	{
		public string Code { get; set; }
		public string Name { get; set; }
		public string Native { get; set; }
		public string Phone { get; set; }
		public Continent Continent { get; set; }
		public string Capital { get; set; }
		public string Currency { get; set; }
		public Language Language { get; set; }
		public string emoji { get;  set; }
		public string EmojiU { get; set; }
		public State States { get; set; }
	}
}
