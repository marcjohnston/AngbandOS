// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Projection;
using AngbandOS.StaticData;

namespace AngbandOS.Enumerations
{
    [Serializable]
    internal class AcidAttackEffect : BaseAttackEffect
    {
        public override int Power => 0;
        public override string Description => "shoot acid";
        public override void ApplyToPlayer(SaveGame saveGame, int monsterLevel, int monsterIndex, int armourClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
        {
            obvious = true;
            saveGame.MsgPrint("You are covered in acid!");
            saveGame.AcidDam(damage, monsterDescription);
            saveGame.Level.Monsters.UpdateSmartLearn(monster, Constants.DrsAcid);
        }
        public override void ApplyToMonster(SaveGame saveGame, Monster monster, int armourClass, ref int damage, ref Projectile? pt, ref bool blinked)
        {
            pt = new ProjectAcid(saveGame);
        }
    }
}