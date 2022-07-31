Feature: LinksValidation

A short summary of the feature

@Links
Scenario: User can verify all the links in webpage
	Given I can Navigate to MottMac Home Page "https://www.mottmac.com"
	When Get All the Links in Webpage
	Then Validate All the links in Webpage
