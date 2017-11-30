# SupportWheelOfFate

## How to:
1. Open solution in Visual Studio 2017 (2015 should also work).
2. Run SupportWheelOfFate.WebUI

## Disclaimer
Don't be suprised if after refresh selected shift engineers will not change - they were choosen for todays shift. 
Tomorrow Wheel of Fate will choose others ;)

## But how can I know if the business requirements has been met?
Simply run 
```csharp
SupportWhellOfFate.Domain.IntegrationTests.DefaultSupportEngineerFilterFactoryIntegrationTests 
```
they will prove that 10 engineers in 10 days will have 2 shifts each, 
and that none of engineers will have shift in consequent days.

## Business requirements
Design and build the “Support Wheel of Fate”

### Background
At one of our companies, all engineers take it in turns to support the business for half a day at a time. This is affectionately known as BAU.
Currently, there is no tool which decides who is doing BAU and when, all rotas are created and maintained by hand.

### Task
Your task is to design and build an online “Support Wheel of Fate”. This should select two engineers at random to both complete a half day of support each. For the purposes of this task, you are free to assume that we have 10 engineers.

### Business Rules
There are some rules and these are liable to change in the future:
* An engineer can do at most one half day shift in a day.
* An engineer cannot have half day shifts on consecutive days.
* Each engineer should have completed one whole day of support in any 2 week period.

