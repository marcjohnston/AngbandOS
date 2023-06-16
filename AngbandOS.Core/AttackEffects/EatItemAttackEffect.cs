// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal class EatItemAttackEffect : BaseAttackEffect
{
    public override int Power => 5;
    public override string Description => "steal items";
    public override void ApplyToPlayer(SaveGame saveGame, int monsterLevel, int monsterIndex, int armourClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        // Steal an item
        saveGame.Player.TakeHit(damage, monsterDescription);
        if ((saveGame.Player.TimedParalysis.TurnsRemaining == 0 && Program.Rng.RandomLessThan(100) < saveGame.Player.AbilityScores[Ability.Dexterity].DexTheftAvoidance + saveGame.Player.Level) || saveGame.Player.HasAntiTheft)
        {
            saveGame.MsgPrint("You grab hold of your backpack!");
            blinked = true;
            obvious = true;
            return;
        }
        // Have ten tries at picking a suitable item to steal
        for (int k = 0; k < 10; k++)
        {
            BaseInventorySlot packInventorySlot = saveGame.SingletonRepository.InventorySlots.Get<PackInventorySlot>();
            int i = packInventorySlot.WeightedRandom.Choose();
            Item? item = saveGame.GetInventoryItem(i);
            if (item != null && item.FixedArtifact == null && string.IsNullOrEmpty(item.RandartName))
            {
                string itemName = item.Description(false, 3);
                string y = item.Count > 1 ? "One of y" : "Y";
                saveGame.MsgPrint($"{y}our {itemName} ({i.IndexToLabel()}) was stolen!");

                // Give the item to the thief so it can later drop it
                Item stolenItem = item.Clone();
                stolenItem.Count = 1;
                stolenItem.Marked = false;

                saveGame.AddItemToMonster(item.Clone(), monster);

                saveGame.Player.InvenItemIncrease(i, -1);
                saveGame.Player.InvenItemOptimize(i);
                obvious = true;
                blinked = true;
                return;
            }
        }
    }
    public override void ApplyToMonster(SaveGame saveGame, Monster monster, int armourClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        // Monsters don't actually steal from other monsters
        pt = null;
        damage = 0;
        if (Program.Rng.DieRoll(2) == 1)
        {
            blinked = true;
        }
    }
}