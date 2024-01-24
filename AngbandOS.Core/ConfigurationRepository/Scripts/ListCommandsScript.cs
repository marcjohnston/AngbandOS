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
    private ListCommandsScript(SaveGame saveGame) : base(saveGame) { }

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
        SaveGame.FullScreenOverlay = true;
        ScreenBuffer savedScreen = SaveGame.Screen.Clone();
        SaveGame.UpdateScreen();
        SaveGame.Screen.Clear();
        SaveGame.SetBackground(BackgroundImageEnum.Normal);
        SaveGame.Screen.Print(ColourEnum.Yellow, "Numpad", 1, 1);
        SaveGame.Screen.Print("7 8 9", 3, 1);
        SaveGame.Screen.Print(" \\|/", 4, 1);
        SaveGame.Screen.Print("4- -6 = Move", 5, 1);
        SaveGame.Screen.Print(" /|\\    (+Shift = run)", 6, 1);
        SaveGame.Screen.Print("1 2 3", 7, 1);
        SaveGame.Screen.Print("5 = Stand still", 8, 1);
        SaveGame.Screen.Print(ColourEnum.Yellow, "Other Symbols", 10, 1);
        SaveGame.Screen.Print(". = Run", 12, 1);
        SaveGame.Screen.Print("< = Go up stairs", 13, 1);
        SaveGame.Screen.Print("> = Go down stairs", 14, 1);
        SaveGame.Screen.Print("+ = Auto-alter a space", 15, 1);
        SaveGame.Screen.Print("* = Target a creature", 16, 1);
        SaveGame.Screen.Print("/ = Identify a symbol", 17, 1);
        SaveGame.Screen.Print("? = Command list", 18, 1);
        SaveGame.Screen.Print("Esc = Save and quit", 20, 1);
        SaveGame.Screen.Print(ColourEnum.Yellow, "Without Shift", 1, 25);
        SaveGame.Screen.Print("a = Aim a wand", 3, 25);
        SaveGame.Screen.Print("b = Browse a book", 4, 25);
        SaveGame.Screen.Print("c = Close a door", 5, 25);
        SaveGame.Screen.Print("d = Drop object", 6, 25);
        SaveGame.Screen.Print("e = Show equipment", 7, 25);
        SaveGame.Screen.Print("f = Fire a missile weapon", 8, 25);
        SaveGame.Screen.Print("g = Get (pick up) object", 9, 25);
        SaveGame.Screen.Print("h = View game help", 10, 25);
        SaveGame.Screen.Print("i = Show Inventory", 11, 25);
        SaveGame.Screen.Print("j = Jam spike in a door", 12, 25);
        SaveGame.Screen.Print("k = Destroy an item", 13, 25);
        SaveGame.Screen.Print("l = Look around", 14, 25);
        SaveGame.Screen.Print("m = Cast spell/Use talent", 15, 25);
        SaveGame.Screen.Print("n =", 16, 25);
        SaveGame.Screen.Print("o = Open a door/chest", 17, 25);
        SaveGame.Screen.Print("p = Mutant/Racial power", 18, 25);
        SaveGame.Screen.Print("q = Quaff a potion", 19, 25);
        SaveGame.Screen.Print("r = Read a scroll", 20, 25);
        SaveGame.Screen.Print("s = Search for traps", 21, 25);
        SaveGame.Screen.Print("t = Take off an item", 22, 25);
        SaveGame.Screen.Print("u = Use a staff", 23, 25);
        SaveGame.Screen.Print("v = Throw object", 24, 25);
        SaveGame.Screen.Print("w = Wield/wear an item", 25, 25);
        SaveGame.Screen.Print("x = Examine an object", 26, 25);
        SaveGame.Screen.Print("y =", 27, 25);
        SaveGame.Screen.Print("z = Zap a rod", 28, 25);
        SaveGame.Screen.Print(ColourEnum.Yellow, "With Shift", 1, 52);
        SaveGame.Screen.Print("A = Activate an artifact", 3, 52);
        SaveGame.Screen.Print("B = Bash a stuck door", 4, 52);
        SaveGame.Screen.Print("C = View your character", 5, 52);
        SaveGame.Screen.Print("D = Disarm a trap", 6, 52);
        SaveGame.Screen.Print("E = Eat some food", 7, 52);
        SaveGame.Screen.Print("F = Fuel a light source", 8, 52);
        SaveGame.Screen.Print("H = How you feel here", 10, 52);
        SaveGame.Screen.Print("J = View your journal", 12, 52);
        SaveGame.Screen.Print("K = Destroy trash objects", 13, 52);
        SaveGame.Screen.Print("L = Locate player", 14, 52);
        SaveGame.Screen.Print("M = View the map", 15, 52);
        SaveGame.Screen.Print("O = Show last message", 17, 52);
        SaveGame.Screen.Print("P = Show previous messages", 18, 52);
        SaveGame.Screen.Print("Q = Quit (Retire character)", 19, 52);
        SaveGame.Screen.Print("R = Rest", 20, 52);
        SaveGame.Screen.Print("S = Auto-search on/off", 21, 52);
        SaveGame.Screen.Print("T = Tunnel", 22, 52);
        SaveGame.Screen.Print("V = Version info", 24, 52);
        if (SaveGame.IsWizard)
        {
            SaveGame.Screen.Print("W = Wizard command", 25, 52);
        }
        SaveGame.AnyKey(44);
        SaveGame.Screen.Restore(savedScreen);
        SaveGame.SetBackground(BackgroundImageEnum.Overhead);
        SaveGame.FullScreenOverlay = false;
    }
}
