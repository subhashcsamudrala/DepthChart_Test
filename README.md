This code has been developed using Visual Studio 2019. I have taken a console application to write the functionality and a unit test project (xUnit) to test the functionality. 

To run the code, in UnitTest1.cs file, right click on the TestDepthChart test method and say Debug. Please place breakpoints to debug and see the result. 



Assumptions:
In Use case 2 for removePlayerFromDepthChart method, point 1 says to return the Player object but point 2 says to return empty list when the player is not listed in the depth chart. Since the same method cannot return a player object (which is not a list) and an empty list, I am returning Player object if the player is listed in the depth chart else returning null.