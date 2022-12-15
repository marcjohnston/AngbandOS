// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Projection;

namespace AngbandOS.Core.AttackEffects
{
    [Serializable]
    internal class ConfuseAttackEffect : BaseAttackEffect
    {
        public override int Power => 10;
        public override string Description => "confuse";
        public override void ApplyToPlayer(SaveGame saveGame, int monsterLevel, int monsterIndex, int armourClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
        {
            saveGame.Player.TakeHit(damage, monsterDescription);
            if (!saveGame.Player.HasConfusionResistance)
            {
                if (saveGame.Player.SetTimedConfusion(saveGame.Player.TimedConfusion + 3 + Program.Rng.DieRoll(monsterLevel)))
                {
                    obvious = true;
                }
            }
            saveGame.Level.Monsters.UpdateSmartLearn(monster, Constants.DrsConf);
        }
        public override void ApplyToMonster(SaveGame saveGame, Monster monster, int armourClass, ref int damage, ref Projectile? pt, ref bool blinked)
        {
            pt = new ProjectConfusion(saveGame);
        }
    }
}