// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RunRandomActivationScript : Script, IScript
{
    private RunRandomActivationScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the activate power script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        string selection;
        Game.FullScreenOverlay = true;
        ScreenBuffer savedScreen = Game.Screen.Clone();
        try
        {
            Game.SetBackground(BackgroundImageEnum.Normal);

            Game.Screen.Clear();
            int index = 0;
            foreach (Activation activation in Game.SingletonRepository.Get<Activation>())
            {
                int row = 2 + (index % 40);
                int col = 30 * (index / 40);
                Game.Screen.PrintLine($"{index + 1}. {activation.Name}", row, col);
                index++;
            }
            if (!Game.GetString("Activation power?", out selection, "", 3))
            {
                return;
            }
        }
        finally
        {
            Game.Screen.Restore(savedScreen);
            Game.FullScreenOverlay = false;
            Game.SetBackground(BackgroundImageEnum.Overhead);
        }

        if (!Int32.TryParse(selection, out int selectedIndex))
        {
            return;
        }
        selectedIndex--;
        if (selectedIndex < 0 || selectedIndex > Game.SingletonRepository.Count<Activation>())
        {
            return;
        }

        Activation selectedActivation = Game.SingletonRepository.Get<Activation>(selectedIndex);
        //selectedActivation.Activate(); // TODO: Wizard command does not work
    }
}
