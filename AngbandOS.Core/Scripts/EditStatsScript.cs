// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EditStatsScript : Script, IScript, ICastSpellScript
{
    private EditStatsScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Allows the wizard to edit all of the player stats.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        string tmpVal;
        int tmpInt;
        foreach (Ability ability in Game.SingletonRepository.Get<Ability>())
        {
            string ppp = $"{ability.Name} (3-118): ";
            if (!Game.GetString(ppp, out tmpVal, $"{ability.InnateMax}", 3))
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
            ability.Innate = tmpInt;
            ability.InnateMax = tmpInt;
        }
        if (!Game.GetString("Gold: ", out tmpVal, $"{Game.Gold.IntValue}", 9))
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
        Game.Gold.IntValue = tmpInt;

        if (!Game.GetString("Mana: ", out tmpVal, $"{Game.Mana.IntValue}", 9))
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
        Game.Mana.IntValue = tmpInt;

        if (!Game.GetString("Experience: ", out tmpVal, $"{Game.MaxExperienceGained.IntValue}", 9))
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
        Game.MaxExperienceGained.IntValue = tmpInt;

        Game.CheckExperience();
        Game.RunScript(nameof(RedrawScript));
    }
}
