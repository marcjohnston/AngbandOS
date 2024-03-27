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
    private EditStatsScript(Game game) : base(game) { }

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
            if (!Game.GetString(ppp, out tmpVal, $"{Game.AbilityScores[i].InnateMax}", 3))
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
            Game.AbilityScores[i].Innate = tmpInt;
            Game.AbilityScores[i].InnateMax = tmpInt;
        }
        if (!Game.GetString("Gold: ", out tmpVal, $"{Game.Gold.Value}", 9))
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
        Game.Gold.Value = tmpInt;

        if (!Game.GetString("Mana: ", out tmpVal, $"{Game.Mana.Value}", 9))
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
        Game.Mana.Value = tmpInt;

        if (!Game.GetString("Experience: ", out tmpVal, $"{Game.MaxExperienceGained.Value}", 9))
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
        Game.MaxExperienceGained.Value = tmpInt;

        Game.CheckExperience();
        Game.RunScript(nameof(RedrawScript));
    }
}
