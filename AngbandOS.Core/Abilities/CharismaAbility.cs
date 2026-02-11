// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class CharismaAbility : Ability
{
    private CharismaAbility(Game game) : base(game) { } // This object is a singleton

    public override bool HasSustain => Game.HasSustainCharisma;
    public override string DescStatNeg => "ugly";
    public override string DescStatPos => "cute";
    public override string Act => "beautiful";
    public override string Name => "CHA: ";
    public override string NameReduced => "cha: ";
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
        int haggle = CharismaPriceAdjustment;
        string bonus1 = $"{haggle}% prices";
        return (bonus1, string.Empty, string.Empty, string.Empty, string.Empty);
    }
}