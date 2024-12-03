// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal class EatFoodAttackEffect : AttackEffect
{
    private EatFoodAttackEffect(Game game) : base(game) { }
    public override int Power => 5;
    public override string Description => "eat your food";
    public override void ApplyToPlayer(Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        Game.TakeHit(damage, monster.IndefiniteVisibleName);
        // Have ten tries at grabbing a food item from the player
        for (int k = 0; k < 10; k++)
        {
            WieldSlot packInventorySlot = Game.SingletonRepository.Get<WieldSlot>(nameof(PackWieldSlot));
            int i = packInventorySlot.WeightedRandom.Choose();
            Item? item = Game.GetInventoryItem(i);
            if (item != null && item.CanBeEatenByMonsters)
            {
                // Note that the monster doesn't actually get the food item - it's gone
                string itemName = item.GetDescription(false);
                string y = item.StackCount > 1 ? "One of y" : "Y";
                Game.MsgPrint($"{y}our {itemName} ({i.IndexToLabel()}) was eaten!");
                Game.InvenItemIncrease(i, -1);
                Game.InvenItemOptimize(i);
                obvious = true;
                return;
            }
        }
    }
    public override void ApplyToMonster(Monster monster, int armorClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        pt = null;
        damage = 0;
    }
}