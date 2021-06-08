using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Iteration;

namespace Winform_GUI
{
    public partial class FormMain : Form
    {
        //player
        Player p = new Player("Player", "a blob that loves moving from one room to another");
        //command processor creation
        CommandProcessor cmdProcessor = new CommandProcessor();
        //setting up items, rooms and paths
        Item startingItem01 = new Item(new string[] { "bread", "breadstick", "food" }, "a breadstick", "This is a dry breadstick, enough to keep you going.");
        Item startingItem02 = new Item(new string[] { "water", "bottle", "drink" }, "a water bottle", "This is a purified water bottle.");
        Bag startingBag = new Bag(new string[] { "starterbag", "bag" }, "Starter Bag", "A smol Starter Bag, it is enough to hold some items and equipments.");
        Item gemOfEconomicalCorruption = new Item(new string[] { "gem", "economical", "corruption" }, "Gem Of Economical Corruption", "An OP gem that can produce any amount of coins you want.");
        Item firstWildItem = new Item(new string[] { "test", "note" }, "a note", "A testing note to check if things work.");
        Item secondWildItem = new Item(new string[] { "test", "note" }, "a note", "A second testing note to check if things work.");
        Bag firstLoot = new Bag(new string[] { "loot", "chest" }, "an Unlocked Metallic Chest", "It looks like someone left this for you. There's something in it!");
        //1. Create paths and the second room
        Path testDoor = new Path(new string[] { "North", "n", "north" }, "wooden door", "You travel through a small wooden door.");
        Path testDoorReturn = new Path(new string[] { "South", "s", "south" }, "wooden door", "You travel through a small wooden door.");
        Location room2 = new Location(new string[] { "test", "chamber" }, "the Test Chamber", "This is the test chamber of the game.");

        public FormMain()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            string[] cmd = inputField.Text.Split(' ');
            if (cmd.Length == 1 && cmd[0].ToLower() == "me" || cmd[0].ToLower() == "inventory" || cmd[0].ToLower() == "inv")
                cmd = new string[] { "look", "at", "me" };
            //fixing the \n notation for nextline
            outputField.AppendText(cmdProcessor.Execute(p, cmd).Replace("\n", Environment.NewLine) + "\r\n----------\r\n");
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            outputField.ScrollBars = ScrollBars.Both;
            p.Inventory.Put(startingItem01);
            p.Inventory.Put(startingItem02);
            p.Inventory.Put(startingBag);
            firstLoot.Inventory.Put(firstWildItem);
            p.Location.Inventory.Put(firstLoot);
            startingBag.Inventory.Put(gemOfEconomicalCorruption);
            testDoor.Destination = room2;
            testDoor.Destination.Inventory.Put(secondWildItem);
            testDoorReturn.Destination = p.Location;
            //3. Link that path to a room/location
            p.Location.ConstructPath(testDoor);
            p.Location.LocatePathing("n").Destination.ConstructPath(testDoorReturn);
        }
    }
}
