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
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

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
            if (Game.GetInt($"{ability.Name} (3-118): ", ability.InnateMax, 3, out int? abilityValue)) {
                if (abilityValue > 18 + 100)
                {
                    abilityValue = 18 + 100;
                }
                else if (abilityValue < 3)
                {
                    abilityValue = 3;
                }
                ability.Innate = abilityValue.Value;
                ability.InnateMax = abilityValue.Value;
            }
        }
        if (Game.GetInt("Gold: ", Game.Gold.IntValue, out int? goldValue))
        {
            if (goldValue < 0)
            {
                goldValue = 0;
            }
            Game.Gold.IntValue = goldValue.Value;
        }
        if (Game.GetInt("Mana: ", Game.Mana.IntValue, out int? manaValue))
        {
            if (manaValue < 0)
            {
                manaValue = 0;
            }
            Game.Mana.IntValue = manaValue.Value;
        }
        if (Game.GetInt("Experience: ", Game.MaxExperienceGained.IntValue, out int? experienceValue))
        {
            if (experienceValue < 0)
            {
                experienceValue = 0;
            }
            Game.MaxExperienceGained.IntValue = experienceValue.Value;
        }

        Game.CheckExperience();
        Game.RunScript(nameof(RedrawScript));
    }
}
