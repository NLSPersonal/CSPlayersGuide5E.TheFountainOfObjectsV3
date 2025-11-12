//Main - The entry point of the program. In this main method an instance of the game class is created. That instance's DisplayRules, ChooseCaveSize and Run methods are then executed. 

using TheFountainOfObjectsV3;

Game gameInstance = new Game();
gameInstance.DisplaysRules();
gameInstance.ChooseCaveSize();
gameInstance.Run();
