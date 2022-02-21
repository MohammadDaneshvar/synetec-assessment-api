# Synetec Basic .Net API assessement

This is Synetec's basic API developer assessment.
## How to run this project
1. open the project on the visual studio
2. please set the SynetecAssessmentApi project as a start-up project
3. press F5
## Describing the Project
I used my framework(I developed it 6 years ago) to develop this project that  you can see on the 1-Framework folder.
Describing the patterns and techniques that are used in the Project
- Command bus(CommandBus.cs)
- Dependency injectiuon
- FluentValidation(example:GetEmplyeeBonusQueryValidation.cs)
- Middleware for custom exception handling(CustomExceptionHandlerMiddleware.cs)
- Decorator pattern for validation command on the command bus pipeline(AccessValidatorCommandHandler.cs)
- Repository pattern(help us to mock ORM in Unit test and Independent development without dependence on ORM ,...
- Unit Of Work  pattern
- AutoMapper
- NUnit
- CQRS pattern
- Fixture library( to create random data for the unit test)
- Employee services are in (EmployeeQueryHandlers.cs)