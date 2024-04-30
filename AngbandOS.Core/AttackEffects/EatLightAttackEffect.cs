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
    private EatLightAttackEffect(Game game) : base(game) { }
    public override int Power => 5;
    public override string Description => "absorb light";
    public override void ApplyToPlayer(int monsterLevel, int armorClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        Game.TakeHit(damage, monsterDescription);

        // Choose an inventory slot for lights.
        BaseInventorySlot? chosenLightSourceInventorySlot = Game.SingletonRepository.ToWeightedRandom<BaseInventorySlot>(inventorySlot => inventorySlot.ProvidesLight).ChooseOrDefault();

        // Check to see if there are no slots.
        if (chosenLightSourceInventorySlot == null)
        {
            return;
        }

        // Choose an item in from the inventory slot.
        int? i = chosenLightSourceInventorySlot.WeightedRandom.ChooseOrDefault();

        if (i == null)
        {
            return;
        }

        Item? item = Game.GetInventoryItem(i.Value);
        if (item == null)
        {
            return;
        }

        // Only dim lights that consume fuel
        if (item.TypeSpecificValue > 0 && item.FixedArtifact == null)
        {
            item.TypeSpecificValue -= 250 + Game.DieRoll(250);
            if (item.TypeSpecificValue < 1)
            {
                item.TypeSpecificValue = 1;
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