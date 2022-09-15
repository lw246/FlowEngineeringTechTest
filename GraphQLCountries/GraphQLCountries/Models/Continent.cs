namespace GraphQLCountries.Models
{
	public class Continent
	{
		public string Code { get; set; }
		public string Name { get; set; }
		public List<Country> Countries { get; set; }
	}
}
