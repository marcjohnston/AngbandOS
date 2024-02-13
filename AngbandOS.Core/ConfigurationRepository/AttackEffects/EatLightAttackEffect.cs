// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal class EatLightAttackEffect : AttackEffect
{
    private EatLightAttackEffect(SaveGame saveGame) : base(saveGame) { }
    public override int Power => 5;
    public override string Description => "absorb light";
    public override void ApplyToPlayer(int monsterLevel, int monsterIndex, int armorClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        SaveGame.TakeHit(damage, monsterDescription);

        // Choose an inventory slot for lights.
        BaseInventorySlot? chosenLightSourceInventorySlot = SaveGame.SingletonRepository.InventorySlots.ToWeightedRandom(inventorySlot => inventorySlot.ProvidesLight).Choose();

        // Check to see if there are no slots.
        if (chosenLightSourceInventorySlot == null)
        {
            return;
        }

        // Get a random light source            
        //Item? item = chosenLightSourceInventorySlot.WeightedRandom.Choose();

        // Check if there were no choices.
        //if (chosenLightSourceInventorySlot == null)
        //{
        //    return;
        //}

        // Choose an item in from the inventory slot.
        int? i = chosenLightSourceInventorySlot.WeightedRandom.Choose();

        if (i == null)
        {
            return;
        }

        Item? item = SaveGame.GetInventoryItem(i.Value);
        if (item == null)
        {
            return;
        }

        // Only dim lights that consume fuel
        if (item.TypeSpecificValue > 0 && item.FixedArtifact == null)
        {
            item.TypeSpecificValue -= 250 + SaveGame.DieRoll(250);
            if (item.TypeSpecificValue < 1)
            {
                item.TypeSpecificValue = 1;
            }
            if (SaveGame.TimedBlindness.TurnsRemaining == 0)
            {
                SaveGame.MsgPrint("Your light dims.");
                obvious = true;
            }
        }
    }
    public override void ApplyToMonster(Monster monster, int armorClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        pt = null;
        damage = 0;
    }
}