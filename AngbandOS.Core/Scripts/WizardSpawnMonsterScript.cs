// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class WizardSpawnMonsterScript : Script
{
    private WizardSpawnMonsterScript(SaveGame saveGame) : base(saveGame) { }

    public override bool Execute()
    {
        SaveGame.FullScreenOverlay = true;
        ScreenBuffer savedScreen = SaveGame.Screen.Clone();
        SaveGame.SetBackground(BackgroundImageEnum.Normal);
        SaveGame.Screen.Clear();

        try
        {
            ConsoleTable table = new ConsoleTable("Name", "Character", "Level");
            MonsterRace[] monsterRaces = SaveGame.SingletonRepository.MonsterRaces.OrderBy(_monsterRace => _monsterRace.Name).ToArray();
            foreach (MonsterRace monsterRace in monsterRaces)
            {
                ConsoleTableRow tableRow = table.AddRow();
                tableRow["Name"] = new ConsoleString(ColourEnum.White, monsterRace.Name);
                tableRow["Character"] = new ConsoleString(ColourEnum.White, monsterRace.Symbol.Character.ToString());
                tableRow["Level"] = new ConsoleString(ColourEnum.White, monsterRace.LevelFound.ToString());
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
                    c.Colour = ColourEnum.Red;
                }

                table.Render(SaveGame, consoleWindow, new ConsoleTopLeftAlignment());

                if (!SaveGame.GetCom("Spawn Which Monster? ", out char ch))
                {
                    return false;
                }

                foreach (ConsoleChar c in s)
                {
                    c.Colour = ColourEnum.White;
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
                        SaveGame.Level.Scatter(out int y, out int x, SaveGame.Player.MapY, SaveGame.Player.MapX, 1);
                        SaveGame.Level.PlaceMonsterAux(y, x, monsterRace, false, false, false);
                        return false;
                }
            }
        }
        finally
        {
            SaveGame.Screen.Restore(savedScreen);
            SaveGame.FullScreenOverlay = false;
            SaveGame.SetBackground(BackgroundImageEnum.Overhead);
        }
        return false;
    }
}
