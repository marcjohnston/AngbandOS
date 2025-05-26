// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class WisdomAbility : Ability
{
    private WisdomAbility(Game game) : base(game) { } // This object is a singleton

    public override bool HasSustain => Game.HasSustainWisdom;
    public override string DescStatNeg => "naive";
    public override string DescStatPos => "wise";
    public override string Act => "wise";
    public override string Name => "WIS: ";
    public override string NameReduced => "wis: ";
    public override void FlagActions()
    {
        if (Game.BaseCharacterClass.SpellStat == this)
        {
            Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateManaFlaggedAction)).Set();
            Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateSpellsFlaggedAction)).Set();
        }
    }

    public override (string bonus1, string bonus2, string bonus3, string bonus4, string bonus5) GetBonuses()
    {
        int save = WisSavingThrowBonus;
        string bonus1 = $"{save:+0;-0;+0} save";
        return (bonus1, string.Empty, string.Empty, string.Empty, string.Empty);
    }
}
