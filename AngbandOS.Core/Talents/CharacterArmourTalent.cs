// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Talents;

[Serializable]
internal class CharacterArmorTalent : Talent
{
    private CharacterArmorTalent(Game game) : base(game) { }
    public override string Name => "Character Armor";
    public override int Level => 13;
    public override int ManaCost => 12;
    public override int BaseFailure => 50;

    public override void Use()
    {
        Game.StoneskinTimer.AddTimer(Game.ExperienceLevel.IntValue);
        if (Game.ExperienceLevel.IntValue > 14)
        {
            Game.AcidResistanceTimer.AddTimer(Game.ExperienceLevel.IntValue);
        }
        if (Game.ExperienceLevel.IntValue > 19)
        {
            Game.RunScript(nameof(FireResistance1xTimerScript));
        }
        if (Game.ExperienceLevel.IntValue > 24)
        {
            Game.ColdResistanceTimer.AddTimer(Game.ExperienceLevel.IntValue);
        }
        if (Game.ExperienceLevel.IntValue > 29)
        {
            Game.LightningResistanceTimer.AddTimer(Game.ExperienceLevel.IntValue);
        }
        if (Game.ExperienceLevel.IntValue > 34)
        {
            Game.PoisonResistanceTimer.AddTimer(Game.ExperienceLevel.IntValue);
        }
    }

    protected override string LearnedDetails()
    {
        return $"dur {Game.ExperienceLevel.IntValue}";
    }
}