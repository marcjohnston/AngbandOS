﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class BootsArmorItemFactory : ArmorItemFactory
{
    /// <summary>
    /// Returns the feet inventory slot for boots.
    /// </summary>
    public override int WieldSlot => InventorySlot.Feet;

    public BootsArmorItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get(nameof(BootsItemClass));
    public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get(nameof(FeetInventorySlot));
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Boots;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;
    public override int PackSort => 27;

    public override ColorEnum Color => ColorEnum.BrightBrown;

    /// <summary>
    /// Applies standard magic to boots.
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

    protected override void ApplyRandomGoodRareCharacteristics(Item item)
    {
        switch (SaveGame.Rng.DieRoll(24))
        {
            case 1:
                item.RareItemTypeIndex = RareItemTypeEnum.BootsOfSpeed;
                break;
            case 2:
            case 3:
            case 4:
            case 5:
                item.RareItemTypeIndex = RareItemTypeEnum.BootsOfFreeAction;
                break;
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
            case 11:
            case 12:
            case 13:
                item.RareItemTypeIndex = RareItemTypeEnum.BootsOfStealth;
                break;
            case 14:
            case 15:
            case 16:
            case 17:
            case 18:
            case 19:
            case 20:
            case 21:
            case 22:
            case 23:
            case 24:
                item.RareItemTypeIndex = RareItemTypeEnum.BootsWinged;
                if (SaveGame.Rng.DieRoll(2) == 1)
                {
                    IArtifactBias artifactBias = null;
                    item.ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(22) + 16);
                }
                break;
        }
    }

    /// <summary>
    /// Applies a poor random rare characteristics to boots.
    /// </summary>
    /// <param name="item"></param>
    protected override void ApplyRandomPoorRareCharacteristics(Item item)
    {
        switch (SaveGame.Rng.DieRoll(3))
        {
            case 1:
                item.RareItemTypeIndex = RareItemTypeEnum.BootsOfNoise;
                break;
            case 2:
                item.RareItemTypeIndex = RareItemTypeEnum.BootsOfSlowness;
                break;
            case 3:
                item.RareItemTypeIndex = RareItemTypeEnum.BootsOfAnnoyance;
                break;
        }
    }
}