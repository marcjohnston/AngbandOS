// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.AttackEffects;

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
            BaseInventorySlot packInventorySlot = saveGame.SingletonRepository.InventorySlots.Get<PackInventorySlot>();
            int i = packInventorySlot.WeightedRandom.Choose();
            Item? item = saveGame.GetInventoryItem(i);
            if (item != null && (item.Category == ItemTypeEnum.Staff || item.Category == ItemTypeEnum.Wand) && item.TypeSpecificValue != 0)
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
                    saveGame.RedrawHealthFlaggedAction.Set();
                }
                item.TypeSpecificValue = 0;
                saveGame.NoticeCombineAndReorderFlaggedAction.Set();
                return;
            }
        }
    }
    public override void ApplyToMonster(SaveGame saveGame, Monster monster, int armourClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        pt = saveGame.SingletonRepository.Projectiles.Get<DisenchantProjectile>();
    }
}