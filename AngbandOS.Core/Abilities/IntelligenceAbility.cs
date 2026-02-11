// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class IntelligenceAbility : Ability
{
    private IntelligenceAbility(Game game) : base(game) { } // This object is a singleton

    public override bool HasSustain => Game.HasSustainIntelligence;
    public override string DescStatNeg => "stupid";
    public override string DescStatPos => "smart";
    public override string Act => "bright";
    public override string Name => "INT: ";
    public override string NameReduced => "int: ";
    public override void FlagActions()
    {
        if (Game.CharacterClass.SpellStat == this)
        {
            Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateManaFlaggedAction)).Set();
            Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateSpellsFlaggedAction)).Set();
        }
    }

    public override (string bonus1, string bonus2, string bonus3, string bonus4, string bonus5) GetBonuses()
    {
        int device = IntUseDeviceBonus;
        string bonus1 = $"{device:+0;-0;+0} device";
        int disarm = IntDisarmBonus;
        string bonus2 = $", {disarm:+0;-0;+0}% disarm";
        return (bonus1, bonus2, string.Empty, string.Empty, string.Empty);
    }
}
