Feature: JobSearch

A short summary of the feature

@MyjobSearch
Scenario Outline:Verify user can search required job under career search
	Given I can Navigate to Mottmac career page "https://www.mottmac.com/careers/search"
	And I can search with relavent job as <Job> in searchbox
	When Click on Search icon
	Then I can view the search results 
	And click on View Job button
	And I can view the Job details

Examples:
| Job               |
| Software Engineer |
| QA inspector      |
