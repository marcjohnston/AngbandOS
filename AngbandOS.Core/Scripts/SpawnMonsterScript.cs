// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SpawnMonsterScript : Script, IScript, ICastSpellScript
{
    private SpawnMonsterScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

    /// <summary>
    /// Executes the spawn monster script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.FullScreenOverlay = true;
        ScreenBuffer savedScreen = Game.Screen.Clone();
        Game.SetBackground(BackgroundImageEnum.Normal);
        Game.Screen.Clear();

        try
        {
            ConsoleTable table = new ConsoleTable("Name", "Character", "Level");
            MonsterRace[] monsterRaces = Game.SingletonRepository.Get<MonsterRace>().OrderBy(_monsterRace => _monsterRace.FriendlyName).ToArray();
            foreach (MonsterRace monsterRace in monsterRaces)
            {
                ConsoleTableRow tableRow = table.AddRow();
                tableRow["Name"] = new ConsoleString(ColorEnum.White, monsterRace.FriendlyName);
                tableRow["Character"] = new ConsoleString(ColorEnum.White, monsterRace.Symbol.Character.ToString());
                tableRow["Level"] = new ConsoleString(ColorEnum.White, monsterRace.LevelFound.ToString());
            }

            ConsoleWindow consoleWindow = new ConsoleWindow(0, 1, 79, 42);
            int selectedIndex = 0;
            while (true)
            {
                if (selectedIndex < 0)
                {
                    selectedIndex = 0;
                }
                else if (selectedIndex >= table.Rows.Length)
                {
                    selectedIndex = table.Rows.Length - 1;
                }

                if (selectedIndex < table.TopRow)
                {
                    table.TopRow = selectedIndex;
                }
                else if (selectedIndex > table.TopRow + consoleWindow.Height)
                {
                    table.TopRow = selectedIndex - consoleWindow.Height;
                }
                ConsoleString s = (ConsoleString)table.Rows[selectedIndex]["Name"];
                foreach (ConsoleChar c in s)
                {
                    c.Color = ColorEnum.Red;
                }

                table.Render(Game, consoleWindow, new ConsoleTopLeftAlignment());

                if (!Game.GetCom("Spawn Which Monster? ", out char ch))
                {
                    return;
                }

                foreach (ConsoleChar c in s)
                {
                    c.Color = ColorEnum.White;
                }
                switch (ch)
                {
                    case '9':
                        selectedIndex -= consoleWindow.Height;
                        break;
                    case '3':
                        selectedIndex += consoleWindow.Height;
                        break;
                    case '8':
                        selectedIndex -= 1;
                        break;
                    case '2':
                        selectedIndex += 1;
                        break;
                    case '\r':
                        MonsterRace monsterRace = monsterRaces[selectedIndex];
                        (int y, int x) = Game.Scatter(Game.MapY.IntValue, Game.MapX.IntValue, 1);
                        Game.PlaceMonsterAux(y, x, monsterRace, false, false, false);
                        return;
                }
            }
        }
        finally
        {
            Game.Screen.Restore(savedScreen);
            Game.FullScreenOverlay = false;
            Game.SetBackground(BackgroundImageEnum.Overhead);
        }
    }
}
