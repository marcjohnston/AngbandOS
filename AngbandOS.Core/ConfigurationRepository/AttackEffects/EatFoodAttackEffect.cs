﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal class EatFoodAttackEffect : AttackEffect
{
    private EatFoodAttackEffect(SaveGame saveGame) : base(saveGame) { }
    public override int Power => 5;
    public override string Description => "eat your food";
    public override void ApplyToPlayer(int monsterLevel, int monsterIndex, int armourClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        SaveGame.TakeHit(damage, monsterDescription);
        // Have ten tries at grabbing a food item from the player
        for (int k = 0; k < 10; k++)
        {
            BaseInventorySlot packInventorySlot = SaveGame.SingletonRepository.InventorySlots.Get<PackInventorySlot>();
            int i = packInventorySlot.WeightedRandom.Choose();
            Item? item = SaveGame.GetInventoryItem(i);
            if (item != null && item.Factory.CanBeEatenByMonsters)
            {
                // Note that the monster doesn't actually get the food item - it's gone
                string itemName = item.Description(false, 0);
                string y = item.Count > 1 ? "One of y" : "Y";
                SaveGame.MsgPrint($"{y}our {itemName} ({i.IndexToLabel()}) was eaten!");
                SaveGame.InvenItemIncrease(i, -1);
                SaveGame.InvenItemOptimize(i);
                obvious = true;
                return;
            }
        }
    }
    public override void ApplyToMonster(Monster monster, int armourClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        pt = null;
        damage = 0;
    }
}