// Main - The entry point of the application that initializes and runs the game. 

using TheFountainOfObjectsV3;

Game gameInstance = new Game();
gameInstance.DisplaysRules();
Game.DisplayHelp();
gameInstance.ChooseCaveSize();
gameInstance.Run();
