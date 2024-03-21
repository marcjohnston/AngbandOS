// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class CloakArmorItemFactory : ArmorItemFactory
{
    /// <summary>
    /// Returns the about body inventory slot for cloaks.
    /// </summary>
    public override int WieldSlot => InventorySlot.AboutBody;

    protected override void ApplyRandomGoodRareCharacteristics(Item item)
    {
        WeightedRandom<RareItem> weightedRandom = new WeightedRandom<RareItem>(Game);
        weightedRandom.Add(8, Game.SingletonRepository.RareItems.Get(nameof(CloakOfProtectionRareItem)));
        weightedRandom.Add(8, Game.SingletonRepository.RareItems.Get(nameof(CloakOfStealthRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(CloakOfAmanRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(CloakOfElectricityRareItem)));
        weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(CloakOfImmolationRareItem)));
        item.RareItem = weightedRandom.ChooseOrDefault();
    }

    protected override void ApplyRandomPoorRareCharacteristics(Item item)
    {
        switch (Game.DieRoll(3))
        {
            case 1:
                item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(CloakOfIrritationRareItem));
                break;
            case 2:
                item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(CloakOfVulnerabilityRareItem));
                break;
            case 3:
                item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(CloakOfEnvelopingRareItem));
                break;
        }
    }

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        if (power != 0)
        {
            // Apply the standard armor characteristics.
            base.ApplyMagic(item, level, power, null);

            if (power > 1)
            {
                if (Game.DieRoll(20) == 1)
                {
                    item.CreateRandomArtifact(false);
                }
                else
                {
                    ApplyRandomGoodRareCharacteristics(item);
                }
            }
            else if (power < -1)
            {
                ApplyRandomPoorRareCharacteristics(item);
            }
        }
    }

    public CloakArmorItemFactory(Game game) : base(game) { }
    public override ItemClass ItemClass => Game.SingletonRepository.ItemClasses.Get(nameof(CloaksItemClass));
    public override BaseInventorySlot BaseWieldSlot => Game.SingletonRepository.InventorySlots.Get(nameof(AboutBodyInventorySlot));
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Cloak;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;

    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override int PackSort => 22;

    public override bool CanProvideSheathOfElectricity => true;

    public override bool CanProvideSheathOfFire => true;

    public override bool CanReflectBoltsAndArrows => true;

    public override bool CanApplyArtifactBiasResistance => true;
}
