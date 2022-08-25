using Cthangband.Enumerations;
using Cthangband.UI;
using System;

namespace Cthangband.Commands
{
    /// <summary>
    /// Display a list of all the keyboard commands
    /// </summary>
    [Serializable]
    internal class CommandListCommand : ICommand
    {
        public char Key => '?';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            saveGame.Gui.FullScreenOverlay = true;
            saveGame.Gui.Save();
            saveGame.Gui.UpdateScreen();
            saveGame.Gui.Clear();
            saveGame.Gui.SetBackground(BackgroundImage.Normal);
            saveGame.Gui.Print(Colour.Yellow, "Numpad", 1, 1);
            saveGame.Gui.Print("7 8 9", 3, 1);
            saveGame.Gui.Print(" \\|/", 4, 1);
            saveGame.Gui.Print("4- -6 = Move", 5, 1);
            saveGame.Gui.Print(" /|\\    (+Shift = run)", 6, 1);
            saveGame.Gui.Print("1 2 3", 7, 1);
            saveGame.Gui.Print("5 = Stand still", 8, 1);
            saveGame.Gui.Print(Colour.Yellow, "Other Symbols", 10, 1);
            saveGame.Gui.Print(". = Run", 12, 1);
            saveGame.Gui.Print("< = Go up stairs", 13, 1);
            saveGame.Gui.Print("> = Go down stairs", 14, 1);
            saveGame.Gui.Print("+ = Auto-alter a space", 15, 1);
            saveGame.Gui.Print("* = Target a creature", 16, 1);
            saveGame.Gui.Print("/ = Identify a symbol", 17, 1);
            saveGame.Gui.Print("? = Command list", 18, 1);
            saveGame.Gui.Print("Esc = Save and quit", 20, 1);
            saveGame.Gui.Print(Colour.Yellow, "Without Shift", 1, 25);
            saveGame.Gui.Print("a = Aim a wand", 3, 25);
            saveGame.Gui.Print("b = Browse a book", 4, 25);
            saveGame.Gui.Print("c = Close a door", 5, 25);
            saveGame.Gui.Print("d = Drop object", 6, 25);
            saveGame.Gui.Print("e = Show equipment", 7, 25);
            saveGame.Gui.Print("f = Fire a missile weapon", 8, 25);
            saveGame.Gui.Print("g = Get (pick up) object", 9, 25);
            saveGame.Gui.Print("h = View game help", 10, 25);
            saveGame.Gui.Print("i = Show Inventory", 11, 25);
            saveGame.Gui.Print("j = Jam spike in a door", 12, 25);
            saveGame.Gui.Print("k = Destroy an item", 13, 25);
            saveGame.Gui.Print("l = Look around", 14, 25);
            saveGame.Gui.Print("m = Cast spell/Use talent", 15, 25);
            saveGame.Gui.Print("n =", 16, 25);
            saveGame.Gui.Print("o = Open a door/chest", 17, 25);
            saveGame.Gui.Print("p = Mutant/Racial power", 18, 25);
            saveGame.Gui.Print("q = Quaff a potion", 19, 25);
            saveGame.Gui.Print("r = Read a scroll", 20, 25);
            saveGame.Gui.Print("s = Search for traps", 21, 25);
            saveGame.Gui.Print("t = Take off an item", 22, 25);
            saveGame.Gui.Print("u = Use a staff", 23, 25);
            saveGame.Gui.Print("v = Throw object", 24, 25);
            saveGame.Gui.Print("w = Wield/wear an item", 25, 25);
            saveGame.Gui.Print("x = Examine an object", 26, 25);
            saveGame.Gui.Print("y =", 27, 25);
            saveGame.Gui.Print("z = Zap a rod", 28, 25);
            saveGame.Gui.Print(Colour.Yellow, "With Shift", 1, 52);
            saveGame.Gui.Print("A = Activate an artifact", 3, 52);
            saveGame.Gui.Print("B = Bash a stuck door", 4, 52);
            saveGame.Gui.Print("C = View your character", 5, 52);
            saveGame.Gui.Print("D = Disarm a trap", 6, 52);
            saveGame.Gui.Print("E = Eat some food", 7, 52);
            saveGame.Gui.Print("F = Fuel a light source", 8, 52);
            saveGame.Gui.Print("H = How you feel here", 10, 52);
            saveGame.Gui.Print("J = View your journal", 12, 52);
            saveGame.Gui.Print("K = Destroy trash objects", 13, 52);
            saveGame.Gui.Print("L = Locate player", 14, 52);
            saveGame.Gui.Print("M = View the map", 15, 52);
            saveGame.Gui.Print("O = Show last message", 17, 52);
            saveGame.Gui.Print("P = Show previous messages", 18, 52);
            saveGame.Gui.Print("Q = Quit (Retire character)", 19, 52);
            saveGame.Gui.Print("R = Rest", 20, 52);
            saveGame.Gui.Print("S = Auto-search on/off", 21, 52);
            saveGame.Gui.Print("T = Tunnel", 22, 52);
            saveGame.Gui.Print("V = Version info", 24, 52);
            if (saveGame.Player.IsWizard)
            {
                saveGame.Gui.Print("W = Wizard command", 25, 52);
            }
            saveGame.Gui.AnyKey(44);
            saveGame.Gui.Load();
            saveGame.Gui.SetBackground(BackgroundImage.Overhead);
            saveGame.Gui.FullScreenOverlay = false;
        }
    }
}
