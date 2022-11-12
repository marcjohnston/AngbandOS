// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Enumerations;

namespace AngbandOS.Core.AttackEffects
{
    [Serializable]
    internal class LoseStrAttackEffect : BaseAttackEffect
    {
        public override int Power => 0;
        public override string Description => "reduce strength";
        public override void ApplyToPlayer(SaveGame saveGame, int monsterLevel, int monsterIndex, int armourClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
        {
            saveGame.Player.TakeHit(damage, monsterDescription);
            if (saveGame.Player.TryDecreasingAbilityScore(Ability.Strength))
            {
                obvious = true;
            }
        }
    }
}