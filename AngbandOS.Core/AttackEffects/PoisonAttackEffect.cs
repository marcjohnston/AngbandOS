// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core;
using AngbandOS.Projection;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class PoisonAttackEffect : BaseAttackEffect
    {
        public override int Power => 5;
        public override string Description => "poison";
        public override void ApplyToPlayer(SaveGame saveGame, int monsterLevel, int monsterIndex, int armourClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
        {
            // Poison does additional damage
            saveGame.Player.TakeHit(damage, monsterDescription);
            if (!(saveGame.Player.HasPoisonResistance || saveGame.Player.TimedPoisonResistance != 0))
            {
                // Hagarg Ryonis might save us from the additional damage
                if (Program.Rng.DieRoll(10) <= saveGame.Player.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
                {
                    saveGame.MsgPrint("Hagarg Ryonis's favour protects you!");
                }
                else if (saveGame.Player.SetTimedPoison(saveGame.Player.TimedPoison + Program.Rng.DieRoll(monsterLevel) + 5))
                {
                    obvious = true;
                }
            }
            saveGame.Level.Monsters.UpdateSmartLearn(monster, Constants.DrsPois);
        }
        public override void ApplyToMonster(SaveGame saveGame, Monster monster, int armourClass, ref int damage, ref Projectile? pt, ref bool blinked)
        {
            pt = new ProjectPois(saveGame);
        }
    }
}