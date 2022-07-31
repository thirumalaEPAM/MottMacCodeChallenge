# # Project name : MottMac CodeChallenge
## Pre-Requisites for project execution
- Visual Studio 2022
- Latest Chrome Driver version 103.0.5060.134 (

## 01 - Automation Framework design Approach

###### IDE & Language
   - Visual Studio 2022 & C#
###### Automation Tool
   - Selenium WebDriver
###### Project Type
   - BDD-SpecFlow
###### Design Pattern
   - Singleton with POM
###### DataDriven
   - Scenario Outline
###### Reports
   - Extent Reports
###### Browsers
   - Chrome Driver
## 02 - Test Scenarios
-Scenario 1 : Verify user can search required job under career search
-Scenario 2 : User can verify all the links in webpage

###### Feature file
```
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
	
Scenario: User can verify all the links in webpage
	Given I can Navigate to MottMac Home Page "https://www.mottmac.com"
	When Get All the Links in Webpage
	Then Validate All the links in Webpage
```
 ## 03 - Brief Description about framework Approach
 - Reports created using ExtentReports and ScreenShots captured for failed scenarios
 
 - In Project solution 
     ###### 1. ObjectRepsitoryLibrary : 
      which contains common utilities, locators (defined in page classfiles : HomePageRepo and CareerPageRepo),Constants, SingletonBaseclass 
       
       
    ###### 2. HelperLibrary : 
     which contains the methods which are specific to the respective pages (Pagehelper class)
     we can call Pagehelper methods from Teststeps methods.
       
    ###### 4. BDDFramework(SpecFlow Project) 
       Feature files : We can include all scenarios in Feature files
       Stepdefination files : We can define all scenarios under stepdefination class file
       MyHooks : We write code snippets that run before or after each scenario

