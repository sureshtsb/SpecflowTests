Feature: SignUp
	As a seller i should be able to sign up 

@mytag
Scenario: As a Seller i should be abled to give valid data and signup 
	Given I have given valid data
	And I have data into the fields
	When I press join
	Then i should be able to signup
