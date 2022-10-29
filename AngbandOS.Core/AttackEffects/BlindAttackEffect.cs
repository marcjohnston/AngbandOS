// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class BlindAttackEffect : BaseAttackEffect
    {
        public override int Power => 2;
        public override string Description => "blind";
        public override void ApplyToPlayer(SaveGame saveGame, int monsterLevel, int monsterIndex, int armourClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
        {
            saveGame.Player.TakeHit(damage, monsterDescription);
            if (!saveGame.Player.HasBlindnessResistance)
            {
                if (saveGame.Player.SetTimedBlindness(saveGame.Player.TimedBlindness + 10 + Program.Rng.DieRoll(monsterLevel)))
                {
                    obvious = true;
                }
            }
            saveGame.Level.Monsters.UpdateSmartLearn(monster, Constants.DrsBlind);
        }
    }
}