# FlowTechTest

### Running Instructions
Prerequisits: 
- .net6 SDK for you OS from [here](https://dotnet.microsoft.com/en-us/download)

Note: Setting .net core up in Linux can be a pain (I was using Ubuntu 20.04.4). The commands listed below, found in "Scenario 2" [here](https://github.com/dotnet/core/issues/7699) worked for me.

`wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb`
 `sudo dpkg -i packages-microsoft-prod.deb`
`rm packages-microsoft-prod.deb`
`sudo apt install dotnet-sdk-6.0`


### To run the tests:
- Clone the Repo
- Navigate to `{repoLocation}\GraphQLCountries` via the command line
- Run `dotnet test`


### Additional tests I'd include
- Expanding the initial test to cover all fields returned for countries.
- Expanding out the tests written to cover the remaining queries in a similar fashion.
- Running static analysis tools against the schema (eg. something along [these lines](https://github.com/cjoudrey/graphql-schema-linter))
- Additional tests for any consumers of the API to validate any integrations. These could either be PACT style tests or proper integration style tests where we have the consumer hitting the GraphQL endpoint. 
