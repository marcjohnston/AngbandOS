// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal class EatItemAttackEffect : AttackEffect
{
    private EatItemAttackEffect(Game game) : base(game) { }
    public override int Power => 5;
    public override string Description => "steal items";
    public override void ApplyToPlayer(int monsterLevel, int monsterIndex, int armorClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        // Steal an item
        Game.TakeHit(damage, monsterDescription);
        if ((Game.ParalysisTimer.Value == 0 && Game.RandomLessThan(100) < Game.AbilityScores[Ability.Dexterity].DexTheftAvoidance + Game.ExperienceLevel.Value) || Game.HasAntiTheft)
        {
            Game.MsgPrint("You grab hold of your backpack!");
            blinked = true;
            obvious = true;
            return;
        }
        // Have ten tries at picking a suitable item to steal
        for (int k = 0; k < 10; k++)
        {
            BaseInventorySlot packInventorySlot = Game.SingletonRepository.InventorySlots.Get(nameof(PackInventorySlot));
            int i = packInventorySlot.WeightedRandom.Choose();
            Item? item = Game.GetInventoryItem(i);
            if (item != null && !item.IsArtifact)
            {
                string itemName = item.Description(false, 3);
                string y = item.Count > 1 ? "One of y" : "Y";
                Game.MsgPrint($"{y}our {itemName} ({i.IndexToLabel()}) was stolen!");

                // Give the item to the thief so it can later drop it
                Item stolenItem = item.Clone();
                stolenItem.Count = 1;
                stolenItem.Marked = false;

                Game.AddItemToMonster(item.Clone(), monster);

                Game.InvenItemIncrease(i, -1);
                Game.InvenItemOptimize(i);
                obvious = true;
                blinked = true;
                return;
            }
        }
    }
    public override void ApplyToMonster(Monster monster, int armorClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        // Monsters don't actually steal from other monsters
        pt = null;
        damage = 0;
        if (Game.DieRoll(2) == 1)
        {
            blinked = true;
        }
    }
}