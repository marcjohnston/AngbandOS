// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class ConstitutionAbility : Ability
{
    private ConstitutionAbility(Game game) : base(game) { } // This object is a singleton

    public override bool HasSustain => Game.HasSustainConstitution;
    public override string DescStatNeg => "sickly";
    public override string DescStatPos => "healthy";
    public override string Act => "hale";
    public override string Name => "CON: ";
    public override string NameReduced => "con: ";
    public override void FlagActions()
    {
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateHealthFlaggedAction)).Set();
    }

    public override (string bonus1, string bonus2, string bonus3, string bonus4, string bonus5) GetBonuses()
    {
        int hits = ConHealthBonus;
        string bonus1;
        if (hits == -1)
        {
            bonus1 = "-0.5 HP/lvl";
        }
        else
        {
            bonus1 = hits % 2 == 0 ? $"{hits / 2:+0;-0;+0} HP/lvl" : $"{hits / 2:+0;-0;+0}.5 HP/lvl";
        }
        int regen = ConRecoverySpeed;
        string bonus2 = $", x{regen + 1} recovery";
        return (bonus1, bonus2, string.Empty, string.Empty, string.Empty);
    }
}
