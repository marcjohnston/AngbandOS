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
    private EatItemAttackEffect(SaveGame saveGame) : base(saveGame) { }
    public override int Power => 5;
    public override string Description => "steal items";
    public override void ApplyToPlayer(int monsterLevel, int monsterIndex, int armorClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        // Steal an item
        SaveGame.TakeHit(damage, monsterDescription);
        if ((SaveGame.TimedParalysis.TurnsRemaining == 0 && SaveGame.RandomLessThan(100) < SaveGame.AbilityScores[Ability.Dexterity].DexTheftAvoidance + SaveGame.ExperienceLevel) || SaveGame.HasAntiTheft)
        {
            SaveGame.MsgPrint("You grab hold of your backpack!");
            blinked = true;
            obvious = true;
            return;
        }
        // Have ten tries at picking a suitable item to steal
        for (int k = 0; k < 10; k++)
        {
            BaseInventorySlot packInventorySlot = SaveGame.SingletonRepository.InventorySlots.Get(nameof(PackInventorySlot));
            int i = packInventorySlot.WeightedRandom.Choose();
            Item? item = SaveGame.GetInventoryItem(i);
            if (item != null && !item.IsArtifact)
            {
                string itemName = item.Description(false, 3);
                string y = item.Count > 1 ? "One of y" : "Y";
                SaveGame.MsgPrint($"{y}our {itemName} ({i.IndexToLabel()}) was stolen!");

                // Give the item to the thief so it can later drop it
                Item stolenItem = item.Clone();
                stolenItem.Count = 1;
                stolenItem.Marked = false;

                SaveGame.AddItemToMonster(item.Clone(), monster);

                SaveGame.InvenItemIncrease(i, -1);
                SaveGame.InvenItemOptimize(i);
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
        if (SaveGame.DieRoll(2) == 1)
        {
            blinked = true;
        }
    }
}