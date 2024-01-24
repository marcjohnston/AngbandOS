// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class WizardHelpScript : Script, IScript
{
    private WizardHelpScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the wizard help script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        SaveGame.FullScreenOverlay = true;
        ScreenBuffer savedScreen = SaveGame.Screen.Clone();
        try
        {
            SaveGame.UpdateScreen();
            SaveGame.Screen.Clear();
            SaveGame.SetBackground(BackgroundImageEnum.Normal);
            SaveGame.Screen.Print(ColourEnum.Red, "Wizard Commands", 1, 31);
            SaveGame.Screen.Print(ColourEnum.Red, "===============", 2, 31);

            List<IHelpCommand> allCommands = new List<IHelpCommand>();
            foreach (IHelpCommand command in SaveGame.SingletonRepository.WizardCommands)
            {
                if (command.IsEnabled && command.HelpGroup != null && !String.IsNullOrEmpty(command.HelpDescription))
                {
                    allCommands.Add(command);
                }
            }

            // We will create a card for each help group and render all of the cards in a wrappable grid.
            ConsoleGrid consoleGrid = new ConsoleGrid();

            // Get all of the help groups.
            HelpGroup[] helpGroups = allCommands
                .Where(_command => _command.HelpGroup != null)
                .Select(_command => _command.HelpGroup)
                .Distinct()
                .OrderBy(_helpGroup => _helpGroup.SortIndex)
                .ToArray();

            // Enumerate the groups in alphabetical order and build a console card for each group.
            foreach (HelpGroup helpGroup in helpGroups)
            {
                List<IHelpCommand> groupCommands = allCommands
                    .Where(_command => _command.HelpGroup == helpGroup)
                    .OrderBy(_command => _command.KeyChar)
                    .ToList();

                ConsoleCard card = new ConsoleCard();
                card.Print(0, 0, ColourEnum.Red, helpGroup.Title);
                card.Print(0, 1, ColourEnum.Red, new string('=', helpGroup.Title.Length));
                int row = 3;
                foreach (IHelpCommand command in groupCommands)
                {
                    card.Print(0, row, ColourEnum.White, $"{command.KeyChar} = {command.HelpDescription}");
                    row++;
                }
                consoleGrid.AddCard(card);
            }
            consoleGrid.Render(SaveGame, new ConsoleWindow(1, 4, 79, 21), new ConsoleTopLeftAlignment());
            SaveGame.Screen.Print("Hit any key to continue", 43, 23);
            SaveGame.Inkey();
        }
        finally
        {
            SaveGame.Screen.Restore(savedScreen);
            SaveGame.SetBackground(BackgroundImageEnum.Overhead);
            SaveGame.FullScreenOverlay = false;
        }
    }
}
