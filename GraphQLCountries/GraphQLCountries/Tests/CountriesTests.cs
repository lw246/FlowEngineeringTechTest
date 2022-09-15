using FluentAssertions;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using GraphQLCountries.Models.Responses;

namespace GraphQLCountries.Tests
{
	internal class CountriesTests
	{
		private GraphQLHttpClient graphQlClient;

		[SetUp]
		public void Setup()
		{
			graphQlClient =
				new GraphQLHttpClient("https://countries.trevorblades.com/", new NewtonsoftJsonSerializer());
		}

		[TearDown]
		public void Dispose()
		{
			graphQlClient.Dispose();
		}

		[Test]
		public async Task CanGetAllCountryCodes()
		{
			var request = new GraphQLRequest
			{
				Query = @"
				{
					countries {
						code
					}
				}"
			};

			var response = await graphQlClient.SendQueryAsync<CountriesResponse>(request);

			response.Data.Countries.Should().AllSatisfy(c => c.Code.Should().NotBeNull());
		}

		[Test]
		public async Task CanFilterCountriesByCountryCode()
		{
			var request = new GraphQLRequest
			{
				Query = @"
				{
					countries(filter: { 
						code: { ne: ""GB"" }
					}) 
					{
						code
					}
				}",
			};

			var response = await graphQlClient.SendQueryAsync<CountriesResponse>(request);

			response.Data.Countries.Should().NotContain(c => c.Code == "GB");
		}

		[Test]
		public async Task CanFilterCountriesByCurrency()
		{
			var request = new GraphQLRequest
			{
				Query = @"
				{
					countries(filter: {
						currency: { ne: ""GBP"" }
					}) 
					{
						code
						currency
					}
				}",
			};

			var response = await graphQlClient.SendQueryAsync<CountriesResponse>(request);

			response.Data.Countries.Should().NotContain(c => c.Code == "GB");
			response.Data.Countries.Should().NotContain(c => c.Currency == "GBP");
		}

		[Test]
		public async Task CanFilterCountriesByContinent()
		{
			var request = new GraphQLRequest
			{
				Query = @"
				{
					countries(filter: {
						continent: { ne: ""EU"" }
					}) 
					{
						code
						continent { code }
					}
				}",
			};

			var response = await graphQlClient.SendQueryAsync<CountriesResponse>(request);

			response.Data.Countries.Should().NotContain(c => c.Code == "GB");
			response.Data.Countries.Should().NotContain(c => c.Continent!.Code == "EU");
		}
	}
}
