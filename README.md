# FlowTechTest

### Overview
Simple test project in C# to hit the countries GraphQL endpoint https://countries.trevorblades.com/ 
Using .net core to allow running on all enviroments (and it's a language I can quickly put something together in!)


### Running Instructions
Prerequisits: 
- .net6 SDK for you OS which can be downloaded from [here](https://dotnet.microsoft.com/en-us/download)

**Note:** Setting up .net core in Linux can sometimes be a pain (I was using Ubuntu 20.04.4). The commands listed below, found in "Scenario 2" [here](https://github.com/dotnet/core/issues/7699) worked for me.

`wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb`
 `sudo dpkg -i packages-microsoft-prod.deb`
`rm packages-microsoft-prod.deb`
`sudo apt install dotnet-sdk-6.0`


### To run the tests:
- Clone the Repo
- Navigate to `..\FlowEngineeringTechTest\GraphQLCountries` via the command line
- Run `dotnet test`


### Additional tests I'd include
###### Expanding out the tests written to cover the remaining queries in a similar fashion.
This would be the initial thing to do here to ensure that all supported queries function. These tests would ensure that we're able retrieve data and any filters work as expected.

###### Expanding the initial test to cover all fields returned for countries.
These would be next in line for the project provided here. These would be aimed to ensure that all fields are able to be returned. 
I'd also cover off any data transformations that can be carried out via querying the endpoint. (I believe this is a thing with GraphQL anyway from my reading)

###### Running static analysis tools against the schema
Given access to the source for the endpoint I'd have static analysis tools running against the schema to ensure that it is valid. Eg. something like [this](https://github.com/cjoudrey/graphql-schema-linter)

###### Additional tests for any consumers of the API 
Again, if the source for the endpoint was under control of the teasm I'd like to validate anu intergrations. Depending upon the circumstances and how the team are working these could include PACT tests to aid defining requirements between consumers and producers of the endpoint along with integration tests where we'd have the consumer hitting the GraphQL endpoint to prove out the integration.

###### Creviating all the above with "I'd like a good discussion with the development team before implemeting anything further"
As I've not worked with GraphQL in a production sense, I'd also want to have a good talk through what is being created with the team so as to get an understanding of where the boundaries between "our" code and "GraphQL" to ensure that tests don't end up being written to test GraphQL (As I'd hope these already exist!)

### Further improvements that could be made
- Move the URL out of the test classes and into a settings file so that it can be changed allowing the tests to run against different environments.
- Potentially adding an extra layer of abstraction to allow the tests to read easier and in a more business orientated fashion (Gherkin could be useful here).
- Enabling of parallelisation to improve execution times.
- Inclusion of a reporting tool such as Allure Reports to allow parsing of the test results to be easier (though a lot of CI tools now do this well enough).