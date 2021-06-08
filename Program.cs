using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iteration;
//using System.Windows.Forms;

namespace Iteration
{
    class Program
    {
        public static void Main(string[] args)
        {

            string P1Name, P1Desc, input;
            Console.WriteLine("Welcome to SwinAdventure!\nInsert your name, traveler:");
            P1Name = Console.ReadLine();
            Console.WriteLine("Insert your description (ex: a normal explorer with no special abilities at all):");
            P1Desc = Console.ReadLine();
            Player p = new Player(P1Name, P1Desc);
            //command processor creation
            CommandProcessor cmdProcessor = new CommandProcessor();

            //iteration 5 - starting objects setup
            Item startingItem01 = new Item(new string[] { "bread", "breadstick", "food" }, "a breadstick", "This is a dry breadstick, enough to keep you going.");
            Item startingItem02 = new Item(new string[] { "water", "bottle", "drink" }, "a water bottle", "This is a purified water bottle.");
            Bag startingBag = new Bag(new string[] { "starterbag", "bag" }, "Starter Bag", "A smol Starter Bag, it is enough to hold some items and equipments.");
            Item gemOfEconomicalCorruption = new Item(new string[] { "gem", "economical", "corruption" }, "Gem Of Economical Corruption", "An OP gem that can produce any amount of coins you want.");
            Item firstWildItem = new Item(new string[] {"test", "note" }, "a note", "A testing note to check if things work.");
            Item secondWildItem = new Item(new string[] { "test", "note" }, "a note", "A second testing note to check if things work.");
            Bag firstLoot = new Bag(new string[] { "loot", "chest" }, "an Unlocked Metallic Chest", "It looks like someone left this for you. There's something in it!");
            p.Inventory.Put(startingItem01);
            p.Inventory.Put(startingItem02);
            p.Inventory.Put(startingBag);
            firstLoot.Inventory.Put(firstWildItem);
            p.Location.Inventory.Put(firstLoot);
            startingBag.Inventory.Put(gemOfEconomicalCorruption);
            Console.WriteLine("You have been equiped with some items to aid you on your journey!");

            //iteration 7 live test + structure
            //1. Create paths
            Path testDoor = new Path(new string[] { "North", "n", "north" }, "wooden door", "You travel through a small wooden door.");
            Path testDoorReturn = new Path(new string[] { "South", "s", "south" }, "wooden door", "You travel through a small wooden door.");
            //2. Set its destination
            testDoor.Destination = new Location(new string[] { "test", "chamber" }, "the Test Chamber", "This is the test chamber of the game.");
            testDoor.Destination.Inventory.Put(secondWildItem);
            testDoorReturn.Destination = p.Location;
            //3. Link that path to a room/location
            p.Location.ConstructPath(testDoor);
            p.Location.LocatePathing("n").Destination.ConstructPath(testDoorReturn);

            string[] cmd;
            int i;
            do
            {
                i = 0;
                Console.Write("--------------------\nCommand -> ");
                input = Console.ReadLine();
                //processing the input into a command (string array, all lowercase)
                cmd = input.Split(' ');
                foreach(string str in cmd)
                {
                    cmd[i] = str.ToLower();
                    i++;
                }
                //handling special commands
                if (cmd.Length == 1 && cmd[0].ToLower() == "me" || cmd[0].ToLower() == "inventory" || cmd[0].ToLower() == "inv")
                {
                    cmd = new string[] { "look", "at", "me" };
                }
                //command processor
                Console.WriteLine(cmdProcessor.Execute(p, cmd));
                //quitting
                if (cmdProcessor.Execute(p, cmd) == "Game ended. Bye.")
                    break;
            } while (true);
            Console.ReadLine();
        }
    }
}
