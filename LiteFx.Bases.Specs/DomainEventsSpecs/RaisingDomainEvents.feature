﻿Feature: Rasing Domaind Events
	In order to alert all my domain
	As a developer
	I want to raise events against the model
	So that anyone could handle it

Scenario: Rasing and handling a Domain Event
	Given I have registered a ordinary domain event handler into DomainEvent static class
	And a ordinary subject
	When I set a value in the ordinary subject 
	And the ordinary event happen
	Then my handler should be called

Scenario: Handling a Domain Event with an Action
	Given I have registered a ordinary action into DomainEvent static class
	And a ordinary subject
	When I set a value in the ordinary subject 
	And the ordinary event happen
	Then my action should be called
