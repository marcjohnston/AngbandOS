﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ActivatePowerScript : Script, IScript
{
    private ActivatePowerScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the activate power script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        SaveGame.FullScreenOverlay = true;
        ScreenBuffer savedScreen = SaveGame.Screen.Clone();
        try
        {
            SaveGame.SetBackground(BackgroundImageEnum.Normal);

            SaveGame.Screen.Clear();
            int index = 0;
            foreach (Activation activationPower in SaveGame.SingletonRepository.Activations)
            {
                int row = 2 + (index % 40);
                int col = 30 * (index / 40);
                SaveGame.Screen.PrintLine($"{index + 1}. {activationPower.Name}", row, col);
                index++;
            }
            if (!SaveGame.GetString("Activation power?", out string selection, "", 3))
            {
                return;
            }

            if (!Int32.TryParse(selection, out int selectedIndex))
            {
                return;
            }
            selectedIndex--;
            if (selectedIndex < 0 || selectedIndex > SaveGame.SingletonRepository.Activations.Count)
            {
                return;
            }

            Activation activation = SaveGame.SingletonRepository.Activations[selectedIndex];
            activation.Activate();
        }
        finally
        {
            SaveGame.Screen.Restore(savedScreen);
            SaveGame.FullScreenOverlay = false;
            SaveGame.SetBackground(BackgroundImageEnum.Overhead);
        }
    }
}