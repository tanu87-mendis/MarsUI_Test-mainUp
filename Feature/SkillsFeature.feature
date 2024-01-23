Feature: SkillsFeature

As a Mars user I
I would like to create, edit and delete langugaes and language levels
So I can manage the user profile successfully 

@tag1 @regression @smoke
Scenario: create skill with valid details
	Given I logged into the Mars portal successfully
	When I navigate to the skills
	When I add new skill 'Team Work' and skill level 'Expert'
	Then the record 'Team Work' should be created successfully

Scenario: Update skill and skill level with valid details 
	Given I logged into the Mars portal successfully
	When I navigate to the skills
	And I add new skill 'Yoga' and skill level 'Expert'
	When I update skill to 'Leadership' and skill level 'Beginner' 
	Then the record 'Leadership' and skill level 'Beginner'should be updated successfully

	Scenario: Delete skill and skill level from profile
	Given I logged into the Mars portal successfully
	When I navigate to the skills
	And I add new skill 'Dancing' and skill level 'Expert'
	When I delete an existing skill 'Dancing' and skill level 'Expert'
	Then the record 'Dancing' should be deleted successfully from the profile




