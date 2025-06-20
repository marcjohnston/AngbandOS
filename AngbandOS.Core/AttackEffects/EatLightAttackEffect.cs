﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal class EatLightAttackEffect : AttackEffect
{
    private EatLightAttackEffect(Game game) : base(game) { }
    public override int Power => 5;
    public override string Description => "absorb light";
    public override void ApplyToPlayer(Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        Game.TakeHit(damage, monster.IndefiniteVisibleName);

        // Choose a wield slot for lights.
        WieldSlot? chosenLightSourceInventorySlot = Game.SingletonRepository.ToWeightedRandom<WieldSlot>(inventorySlot => inventorySlot.ProvidesLight).ChooseOrDefault();

        // Check to see if there are no slots.
        if (chosenLightSourceInventorySlot == null)
        {
            return;
        }

        // Choose an item from the wield slot.
        int? i = chosenLightSourceInventorySlot.WeightedRandom.ChooseOrDefault();

        // Ensure an item was chosen.
        if (i == null)
        {
            return;
        }

        // Get the item.
        Item? item = Game.GetInventoryItem(i.Value);
        if (item == null)
        {
            return;
        }

        // Only dim lights that consume fuel
        if (item.TurnsOfLightRemaining > 0 && item.FixedArtifact == null)
        {
            item.TurnsOfLightRemaining -= 250 + Game.DieRoll(250);
            if (item.TurnsOfLightRemaining < 1)
            {
                item.TurnsOfLightRemaining = 1;
            }
            if (Game.BlindnessTimer.Value == 0)
            {
                Game.MsgPrint("Your light dims.");
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