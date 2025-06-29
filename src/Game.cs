using System;

class Game
{
	// Private fields
	private Parser parser;
	private Player player;

	// Constructor
	public Game()
	{
		parser = new Parser();
		player = new Player();
		CreateRooms();
	}
	
	// Initialise the Rooms (and the Items)
	private void CreateRooms()
	{
		// Create the rooms
		Room outside = new Room("outside the main entrance of the university");
		Room theatre = new Room("in a lecture theatre");
		Room pub = new Room("in the campus pub");
		Room lab = new Room("in a computing lab");
		Room office = new Room("in the computing admin office");
		Room basement = new Room("in the basement");

		// Initialise room exits
		outside.AddExit("east", theatre);
		outside.AddExit("south", lab);
		outside.AddExit("west", pub);

		theatre.AddExit("west", outside);

		pub.AddExit("east", outside);

		lab.AddExit("north", outside);
		lab.AddExit("east", office);
		lab.AddExit("down", basement);

		office.AddExit("west", lab);

		basement.AddExit("up", lab);

		// Create your Items here
		Item sword = new Item(10, "sword");
		Item chestplate = new Item(15, "chestplate");
		Item bandage = new Item(5, "bandage");
		Item medKit = new Item(10, "medKit");
		Item key = new Item(5, "key");


		outside.Chest.Put("sword", sword);
		outside.Chest.Put("chestplate", chestplate);

		// Start game outside
		player.CurrentRoom = outside;

		// Put random items in the rooms
		// List of all rooms
		// Room[] rooms = { outside, theatre, pub, lab, office, basement };

		// // List of all items
		// Item[] items = { sword, chestplate, bandage, medKit, key };

		// // Randomly distribute items across rooms
		// Random random = new Random();
		// foreach (Item item in items)
		// {
		// 	int randomRoomIndex = random.Next(items.Length);
		// 	rooms[randomRoomIndex].Chest.Put(item.Description, item);
		// }
	}

	//  Main play routine. Loops until end of play.
	public void Play()
	{
		PrintWelcome();

		// Enter the main command loop. Here we repeatedly read commands and
		// execute them until the player wants to quit.
		bool finished = false;
		while (!finished)
		{
			Command command = parser.GetCommand();
			finished = ProcessCommand(command);
		}
		Console.WriteLine("Thank you for playing.");
	}

	// Print out the opening message for the player.
	private void PrintWelcome()
	{
		Console.WriteLine();
		Console.WriteLine("Welcome to Zuul!");
		Console.WriteLine("Zuul is a new, incredibly boring adventure game.");
		Console.WriteLine("Type 'help' if you need help.");
		Console.WriteLine();
		Console.WriteLine(player.CurrentRoom.GetLongDescription());
	}

	// Given a command, process (that is: execute) the command.
	// If this command ends the game, it returns true.
	// Otherwise false is returned.
	private bool ProcessCommand(Command command)
	{
		bool wantToQuit = false;

		if (command.IsUnknown())
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("I don't know what you mean...");
			Console.ResetColor();
			return wantToQuit; // false
		}

		switch (command.CommandWord)
		{
			case "help":
				PrintHelp();
				break;
			case "go":
				GoRoom(command);
				break;
			case "quit":
				wantToQuit = true;
				break;
			case "look":
				PrintLook();
				break;
			case "status":
				PrintStatus();
				break;
			case "take":
				Take(command);
				break;
			case "drop":
				Drop(command);
				break;
		}

		return wantToQuit;
	}

	// ######################################
	// implementations of user commands:
	// ######################################

	// Print out some help information.
	// Here we print the mission and a list of the command words.
	private void PrintHelp()
	{
		Console.WriteLine("You are lost. You are alone.");
		Console.WriteLine("You wander around at the university.");
		Console.WriteLine();
		// let the parser print the commands
		parser.PrintValidCommands();
	}

	// Print out where the player is and what exits are available.
	private void PrintLook()
	{
		Console.WriteLine(player.CurrentRoom.GetLongDescription());
		Console.ForegroundColor = ConsoleColor.Blue;
		Console.WriteLine(player.CurrentRoom.Chest.ShowItems());
		Console.ResetColor();
	}

	public void PrintStatus()
	{
		Console.WriteLine($"Health: {player.health}/100");
	}


	private void Take(Command command)
	{
		
	}

	private void Drop(Command command)
	{
		// TODO implement
	}

	// Try to go to one direction. If there is an exit, enter the new
	// room, otherwise print an error message.
	private void GoRoom(Command command)
	{
		if (!command.HasSecondWord())
		{
			// if there is no second word, we don't know where to go...
			Console.WriteLine("Go where?");
			return;
		}

		string direction = command.SecondWord;

		// Try to go to the next room.
		Room nextRoom = player.CurrentRoom.GetExit(direction);
		if (nextRoom == null)
		{
			Console.WriteLine("There is no door to " + direction + "!");
			return;
		}

		player.CurrentRoom = nextRoom;
		player.Damage(10);
		player.IsAlive();
		Console.WriteLine(player.CurrentRoom.GetLongDescription());
	}
}
