// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class StrengthAbility : Ability
{
    private StrengthAbility(Game game) : base(game) { } // This object is a singleton

    public override bool HasSustain => Game.HasSustainStrength;

    public override string DescStatNeg => "weak";
    public override string DescStatPos => "strong";
    public override string Act => "strong";
    public override string Name => "STR: ";
    public override string NameReduced => "str: ";
    public override (string bonus1, string bonus2, string bonus3, string bonus4, string bonus5) GetBonuses()
    {
        int toHit = StrAttackBonus;
        string bonus1 = $"{toHit:+0;-0;+0} to hit";
        int toDam = StrDamageBonus;
        string bonus2 = $", {toDam:+0;-0;+0} damage";
        int carry = StrCarryingCapacity * 5;
        string bonus3 = $", carry {carry}lb";
        int weap = StrMaxWeaponWeight;
        string bonus4 = $", wield {weap}lb";
        int dig = StrDiggingBonus;
        string bonus5 = $", {dig}% digging";
        return (bonus1, bonus2, bonus3, bonus4, bonus5);
    }
}
