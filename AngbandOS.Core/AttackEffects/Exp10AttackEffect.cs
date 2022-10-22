// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Enumerations
{

    [Serializable]
    internal class Exp10AttackEffect : ExpAttackEffect
    {
        public override int Power => 5;
        public override string Description => "lower experience (by 10d6+)";
        protected override int HoldLifePercentChange => 95;
        protected override int DiceCount => 10;
    }
}