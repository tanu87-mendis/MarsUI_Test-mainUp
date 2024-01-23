Feature: LanguageFeature

As a Mars user I
I would like to create, edit and delete langugaes and language levels
So I can manage the user profile successfully 

@tag1 @smoke
Scenario: create language and language level with valid details
	Given I logged into the Mars portal successfully
	When I navigate to the user profile
	When I add new language 'Sinhala'
	Then the record 'Sinhala' should be created successfully

	
Scenario Outline: edit existing language and lanuage level
	Given I logged into the Mars portal successfully 
	When I navigate to the user profile
	When I update the '<Languagae>','<Level>' of  existing language under user profile
	Then the the record should be updated '<Languagae>', '<Level>' successfully

	Examples: 
	| Languagae | Level            |
	| Russian   | Basic            |
	| Mandarin  | Fluent           |
	| Arabic    | Native/Bilingual |
	| Test      | Native/Bilingual |

Scenario: Delete language and language level from profile
	Given I logged into the Mars portal successfully
	When I navigate to the user profile
	When I add new language 'English'
	And I delete an existing language 'English'
	Then the record 'English' should be deleted successfully 

