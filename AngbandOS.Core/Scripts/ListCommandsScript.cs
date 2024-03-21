// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ListCommandsScript : Script, IScript, IRepeatableScript
{
    private ListCommandsScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the list commands script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        ExecuteScript();
        return false;
    }

    /// <summary>
    /// Executes the list commands script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.FullScreenOverlay = true;
        ScreenBuffer savedScreen = Game.Screen.Clone();
        Game.UpdateScreen();
        Game.Screen.Clear();
        Game.SetBackground(BackgroundImageEnum.Normal);
        Game.Screen.Print(ColorEnum.Yellow, "Numpad", 1, 1);
        Game.Screen.Print("7 8 9", 3, 1);
        Game.Screen.Print(" \\|/", 4, 1);
        Game.Screen.Print("4- -6 = Move", 5, 1);
        Game.Screen.Print(" /|\\    (+Shift = run)", 6, 1);
        Game.Screen.Print("1 2 3", 7, 1);
        Game.Screen.Print("5 = Stand still", 8, 1);
        Game.Screen.Print(ColorEnum.Yellow, "Other Symbols", 10, 1);
        Game.Screen.Print(". = Run", 12, 1);
        Game.Screen.Print("< = Go up stairs", 13, 1);
        Game.Screen.Print("> = Go down stairs", 14, 1);
        Game.Screen.Print("+ = Auto-alter a space", 15, 1);
        Game.Screen.Print("* = Target a creature", 16, 1);
        Game.Screen.Print("/ = Identify a symbol", 17, 1);
        Game.Screen.Print("? = Command list", 18, 1);
        Game.Screen.Print("Esc = Save and quit", 20, 1);
        Game.Screen.Print(ColorEnum.Yellow, "Without Shift", 1, 25);
        Game.Screen.Print("a = Aim a wand", 3, 25);
        Game.Screen.Print("b = Browse a book", 4, 25);
        Game.Screen.Print("c = Close a door", 5, 25);
        Game.Screen.Print("d = Drop object", 6, 25);
        Game.Screen.Print("e = Show equipment", 7, 25);
        Game.Screen.Print("f = Fire a missile weapon", 8, 25);
        Game.Screen.Print("g = Get (pick up) object", 9, 25);
        Game.Screen.Print("h = View game help", 10, 25);
        Game.Screen.Print("i = Show Inventory", 11, 25);
        Game.Screen.Print("j = Jam spike in a door", 12, 25);
        Game.Screen.Print("k = Destroy an item", 13, 25);
        Game.Screen.Print("l = Look around", 14, 25);
        Game.Screen.Print("m = Cast spell/Use talent", 15, 25);
        Game.Screen.Print("n =", 16, 25);
        Game.Screen.Print("o = Open a door/chest", 17, 25);
        Game.Screen.Print("p = Mutant/Racial power", 18, 25);
        Game.Screen.Print("q = Quaff a potion", 19, 25);
        Game.Screen.Print("r = Read a scroll", 20, 25);
        Game.Screen.Print("s = Search for traps", 21, 25);
        Game.Screen.Print("t = Take off an item", 22, 25);
        Game.Screen.Print("u = Use a staff", 23, 25);
        Game.Screen.Print("v = Throw object", 24, 25);
        Game.Screen.Print("w = Wield/wear an item", 25, 25);
        Game.Screen.Print("x = Examine an object", 26, 25);
        Game.Screen.Print("y =", 27, 25);
        Game.Screen.Print("z = Zap a rod", 28, 25);
        Game.Screen.Print(ColorEnum.Yellow, "With Shift", 1, 52);
        Game.Screen.Print("A = Activate an artifact", 3, 52);
        Game.Screen.Print("B = Bash a stuck door", 4, 52);
        Game.Screen.Print("C = View your character", 5, 52);
        Game.Screen.Print("D = Disarm a trap", 6, 52);
        Game.Screen.Print("E = Eat some food", 7, 52);
        Game.Screen.Print("F = Fuel a light source", 8, 52);
        Game.Screen.Print("H = How you feel here", 10, 52);
        Game.Screen.Print("J = View your journal", 12, 52);
        Game.Screen.Print("K = Destroy trash objects", 13, 52);
        Game.Screen.Print("L = Locate player", 14, 52);
        Game.Screen.Print("M = View the map", 15, 52);
        Game.Screen.Print("O = Show last message", 17, 52);
        Game.Screen.Print("P = Show previous messages", 18, 52);
        Game.Screen.Print("Q = Quit (Retire character)", 19, 52);
        Game.Screen.Print("R = Rest", 20, 52);
        Game.Screen.Print("S = Auto-search on/off", 21, 52);
        Game.Screen.Print("T = Tunnel", 22, 52);
        Game.Screen.Print("V = Version info", 24, 52);
        if (Game.IsWizard.Value)
        {
            Game.Screen.Print("W = Wizard command", 25, 52);
        }
        Game.AnyKey(44);
        Game.Screen.Restore(savedScreen);
        Game.SetBackground(BackgroundImageEnum.Overhead);
        Game.FullScreenOverlay = false;
    }
}
