// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EditStatsScript : Script, IScript
{
    private EditStatsScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Allows the wizard to edit all of the player stats.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        string tmpVal;
        int tmpInt;
        for (int i = 0; i < 6; i++)
        {
            string ppp = $"{Constants.StatNames[i]} (3-118): ";
            if (!SaveGame.GetString(ppp, out tmpVal, $"{SaveGame.AbilityScores[i].InnateMax}", 3))
            {
                return;
            }
            if (!int.TryParse(tmpVal, out tmpInt))
            {
                tmpInt = 0;
            }
            if (tmpInt > 18 + 100)
            {
                tmpInt = 18 + 100;
            }
            else if (tmpInt < 3)
            {
                tmpInt = 3;
            }
            SaveGame.AbilityScores[i].Innate = tmpInt;
            SaveGame.AbilityScores[i].InnateMax = tmpInt;
        }
        if (!SaveGame.GetString("Gold: ", out tmpVal, $"{SaveGame.Gold.Value}", 9))
        {
            return;
        }
        if (!int.TryParse(tmpVal, out tmpInt))
        {
            tmpInt = 0;
        }
        if (tmpInt < 0)
        {
            tmpInt = 0;
        }
        SaveGame.Gold.Value = tmpInt;

        if (!SaveGame.GetString("Mana: ", out tmpVal, $"{SaveGame.Mana}", 9))
        {
            return;
        }
        if (!int.TryParse(tmpVal, out tmpInt))
        {
            tmpInt = 0;
        }
        if (tmpInt < 0)
        {
            tmpInt = 0;
        }
        SaveGame.Mana = tmpInt;

        if (!SaveGame.GetString("Experience: ", out tmpVal, $"{SaveGame.MaxExperienceGained}", 9))
        {
            return;
        }
        if (!int.TryParse(tmpVal, out tmpInt))
        {
            tmpInt = 0;
        }
        if (tmpInt < 0)
        {
            tmpInt = 0;
        }
        SaveGame.MaxExperienceGained = tmpInt;

        SaveGame.CheckExperience();
        SaveGame.RunScript(nameof(RedrawScript));
    }
}
