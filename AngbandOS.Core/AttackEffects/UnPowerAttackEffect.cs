// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Enumerations;
using AngbandOS.Projection;

namespace AngbandOS.Core.AttackEffects
{
    [Serializable]
    internal class UnPowerAttackEffect : BaseAttackEffect
    {
        public override int Power => 15;
        public override string Description => "drain charges";
        public override void ApplyToPlayer(SaveGame saveGame, int monsterLevel, int monsterIndex, int armourClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
        {
            // Unpower might drain charges from our items
            saveGame.Player.TakeHit(damage, monsterDescription);
            for (int k = 0; k < 10; k++)
            {
                int i = Program.Rng.RandomLessThan(InventorySlot.PackCount);
                Item item = saveGame.Player.Inventory[i];
                if (item.BaseItemCategory != null)
                {
                    continue;
                }
                if ((item.Category == ItemTypeEnum.Staff || item.Category == ItemTypeEnum.Wand) && item.TypeSpecificValue != 0)
                {
                    saveGame.MsgPrint("Energy drains from your pack!");
                    obvious = true;
                    int j = monsterLevel;
                    monster.Health += j * item.TypeSpecificValue * item.Count;
                    if (monster.Health > monster.MaxHealth)
                    {
                        monster.Health = monster.MaxHealth;
                    }
                    if (saveGame.TrackedMonsterIndex == monsterIndex)
                    {
                        saveGame.Player.RedrawNeeded.Set(RedrawFlag.PrHealth);
                    }
                    item.TypeSpecificValue = 0;
                    saveGame.Player.NoticeFlags |= Constants.PnCombine | Constants.PnReorder;
                    return;
                }
            }
        }
        public override void ApplyToMonster(SaveGame saveGame, Monster monster, int armourClass, ref int damage, ref Projectile? pt, ref bool blinked)
        {
            pt = new ProjectDisenchant(saveGame);
        }
    }
}