﻿// AngbandOS: 2022 Marc Johnston
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
        switch (SaveGame.Rng.DieRoll(8))
        {
            case 1:
                item.RareItemTypeIndex = RareItemTypeEnum.HatOfTheMagi;
                item.ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(22) + 16);
                break;
            case 2:
                item.RareItemTypeIndex = RareItemTypeEnum.HatOfMight;
                item.ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(22) + 16);
                break;
            case 3:
                item.RareItemTypeIndex = RareItemTypeEnum.HatOfTelepathy;
                break;
            case 4:
                item.RareItemTypeIndex = RareItemTypeEnum.HatOfRegeneration;
                break;
            case 5:
            case 6:
                item.RareItemTypeIndex = RareItemTypeEnum.HatOfLordliness;
                item.ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(22) + 16);
                break;
            case 7:
            case 8:
                item.RareItemTypeIndex = RareItemTypeEnum.HatOfSeeing;
                if (SaveGame.Rng.DieRoll(3) == 1)
                {
                    item.RandartItemCharacteristics.Telepathy = true;
                }
                break;
        }
    }

    protected override void ApplyRandomPoorRareCharacteristics(Item item)
    {
        switch (SaveGame.Rng.DieRoll(7))
        {
            case 1:
            case 2:
                item.RareItemTypeIndex = RareItemTypeEnum.HatOfStupidity;
                break;
            case 3:
            case 4:
                item.RareItemTypeIndex = RareItemTypeEnum.HatOfNaivety;
                break;
            case 5:
                item.RareItemTypeIndex = RareItemTypeEnum.HatOfUgliness;
                break;
            case 6:
                item.RareItemTypeIndex = RareItemTypeEnum.HatOfSickliness;
                break;
            case 7:
                item.RareItemTypeIndex = RareItemTypeEnum.HatOfTeleportation;
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
                if (SaveGame.Rng.DieRoll(20) == 1)
                {
                    item.CreateRandart(false);
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