// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class DexterityAbility : Ability
{
    private DexterityAbility(Game game) : base(game) { } // This object is a singleton

    public override bool HasSustain => Game.HasSustainDexterity;
    public override string DescStatNeg => "clumsy";
    public override string DescStatPos => "dextrous";
    public override string Act => "agile";
    public override string Name => "DEX: ";
    public override string NameReduced => "dex: ";
    public override (string bonus1, string bonus2, string bonus3, string bonus4, string bonus5) GetBonuses()
    {
        int toHit = DexAttackBonus;
        string bonus1 = $"{toHit:+0;-0;+0} to hit";
        int disarm = DexDisarmBonus;
        string bonus2 = $", {disarm:+0;-0;+0}% disarm";
        int ac = DexArmorClassBonus;
        string bonus3 = $", {ac:+0;-0;+0} AC";
        int theft = DexTheftAvoidance;
        string bonus4 = $", {theft}% anti-theft";
        return (bonus1, bonus2, bonus3, bonus4, string.Empty);
    }
}
