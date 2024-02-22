// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class CrownArmorItemFactory : ArmorItemFactory
{
    /// <summary>
    /// Returns the head inventory slot, for crowns.
    /// </summary>
    public override int WieldSlot => InventorySlot.Head;

    protected override void ApplyRandomGoodRareCharacteristics(Item item)
    {
        IArtifactBias artifactBias = null;
        switch (SaveGame.DieRoll(8))
        {
            case 1:
                item.RareItem = SaveGame.SingletonRepository.RareItems.Get(nameof(HatOfTheMagiRareItem));
                item.ApplyRandomResistance(ref artifactBias, SaveGame.DieRoll(22) + 16);
                break;
            case 2:
                item.RareItem = SaveGame.SingletonRepository.RareItems.Get(nameof(HatOfMightRareItem));
                item.ApplyRandomResistance(ref artifactBias, SaveGame.DieRoll(22) + 16);
                break;
            case 3:
                item.RareItem = SaveGame.SingletonRepository.RareItems.Get(nameof(HatOfTelepathyRareItem));
                break;
            case 4:
                item.RareItem = SaveGame.SingletonRepository.RareItems.Get(nameof(HatOfRegenerationRareItem));
                break;
            case 5:
            case 6:
                item.RareItem = SaveGame.SingletonRepository.RareItems.Get(nameof(HatOfLordlinessRareItem));
                item.ApplyRandomResistance(ref artifactBias, SaveGame.DieRoll(22) + 16);
                break;
            case 7:
            case 8:
                item.RareItem = SaveGame.SingletonRepository.RareItems.Get(nameof(HatOfSeeingRareItem));
                if (SaveGame.DieRoll(3) == 1)
                {
                    item.RandomArtifactItemCharacteristics.Telepathy = true;
                }
                break;
        }
    }

    protected override void ApplyRandomPoorRareCharacteristics(Item item)
    {
        switch (SaveGame.DieRoll(7))
        {
            case 1:
            case 2:
                item.RareItem = SaveGame.SingletonRepository.RareItems.Get(nameof(HatOfStupidityRareItem));
                break;
            case 3:
            case 4:
                item.RareItem = SaveGame.SingletonRepository.RareItems.Get(nameof(HatOfNaivetyRareItem));
                break;
            case 5:
                item.RareItem = SaveGame.SingletonRepository.RareItems.Get(nameof(HatOfUglinessRareItem));
                break;
            case 6:
                item.RareItem = SaveGame.SingletonRepository.RareItems.Get(nameof(HatOfSicklinessRareItem));
                break;
            case 7:
                item.RareItem = SaveGame.SingletonRepository.RareItems.Get(nameof(HatOfTeleportationRareItem));
                break;
        }
    }

    public CrownArmorItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get(nameof(CrownsItemClass));

    /// <summary>
    /// Applies standard magic to crowns.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="level"></param>
    /// <param name="power"></param>
    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        if (power != 0)
        {
            // Apply the standard armor characteristics.
            base.ApplyMagic(item, level, power, null);

            if (power > 1)
            {
                if (SaveGame.DieRoll(20) == 1)
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
    public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get(nameof(HeadInventorySlot));
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Crown;
    public override bool HatesAcid => true;

    public override int PackSort => 24;
    public override ColorEnum Color => ColorEnum.BrightBrown;
}
