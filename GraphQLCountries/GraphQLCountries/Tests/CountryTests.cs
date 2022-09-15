using FluentAssertions;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using GraphQLCountries.Models.Responses;

namespace GraphQLCountries.Tests
{
	internal class CountryTests
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
		public async Task CanGetCountryByCode()
		{
			var request = new GraphQLRequest
			{
				Query = @"
				{
					country(code: ""GB"") {
						code
						currency
					}
				}"
			};

			var response = await graphQlClient.SendQueryAsync<CountryResponse>(request);
			
			Assert.IsNotNull(response.Data.Country);
			response.Data.Country?.Code.Should().Be("GB");
		}

		[Test]
		public async Task UnknownCountryReturnsNull()
		{
			var request = new GraphQLRequest
			{
				Query = @"
				{
					country(code: ""XX"") {
						code
						currency
					}	
				}"
			};

			var response = await graphQlClient.SendQueryAsync<CountryResponse>(request);

			Assert.IsNull(response.Data.Country);
		}
	}
}
