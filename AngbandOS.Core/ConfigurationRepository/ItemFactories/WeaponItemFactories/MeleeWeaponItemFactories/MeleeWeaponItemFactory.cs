// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

/// <summary>
/// Represents common characteristics for melee weapons.  Hafted, polearm and swords are all melee weapons.
/// </summary>
[Serializable]
internal abstract class MeleeWeaponItemFactory : WeaponItemFactory
{
    /// <summary>
    /// Returns the melee weapon inventory slot for melee weapons.
    /// </summary>
    public override int WieldSlot => InventorySlot.MeleeWeapon;

    public MeleeWeaponItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get(nameof(MeleeWeaponInventorySlot));
    public override bool GetsDamageMultiplier => true;

    protected virtual bool CanBeWeaponOfLaw => false;
    protected virtual bool CanBeWeaponOfSharpness => false;
    protected virtual bool CapableOfVorpalSlaying => false;
    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        base.ApplyMagic(item, level, power, null);
        if (power > 1)
        {
            IArtifactBias artifactBias = null;
            switch (SaveGame.Rng.DieRoll(CanBeWeaponOfLaw || CanBeWeaponOfSharpness ? 42 : 40))
            {
                case 1:
                    item.RareItemTypeIndex = RareItemTypeEnum.WeaponElderSign;
                    if (SaveGame.Rng.DieRoll(4) == 1)
                    {
                        item.RandartItemCharacteristics.Blows = true;
                        if (item.TypeSpecificValue > 2)
                        {
                            item.TypeSpecificValue -= SaveGame.Rng.DieRoll(2);
                        }
                    }
                    break;
                case 2:
                    item.RareItemTypeIndex = RareItemTypeEnum.WeaponDefender;
                    if (SaveGame.Rng.DieRoll(3) == 1)
                    {
                        item.RandartItemCharacteristics.ResPois = true;
                    }
                    item.ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(22) + 16);
                    break;
                case 3:
                    item.RareItemTypeIndex = RareItemTypeEnum.WeaponOfVitriol;
                    break;
                case 4:
                    item.RareItemTypeIndex = RareItemTypeEnum.WeaponOfShocking;
                    break;
                case 5:
                    item.RareItemTypeIndex = RareItemTypeEnum.WeaponOfBurning;
                    break;
                case 6:
                    item.RareItemTypeIndex = RareItemTypeEnum.WeaponOfFreezing;
                    break;
                case 7:
                case 8:
                    item.RareItemTypeIndex = RareItemTypeEnum.WeaponOfSlayAnimal;
                    if (SaveGame.Rng.RandomLessThan(100) < 20)
                    {
                        item.RareItemTypeIndex = RareItemTypeEnum.WeaponOfAnimalBane;
                    }
                    break;
                case 9:
                case 10:
                    item.RareItemTypeIndex = RareItemTypeEnum.WeaponOfSlayDragon;
                    item.ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(12) + 4);
                    if (SaveGame.Rng.RandomLessThan(100) < 20)
                    {
                        if (SaveGame.Rng.DieRoll(3) == 1)
                        {
                            item.RandartItemCharacteristics.ResPois = true;
                        }
                        item.ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(14) + 4);
                        item.RareItemTypeIndex = RareItemTypeEnum.WeaponOfDragonBane;
                    }
                    break;
                case 11:
                case 12:
                    item.RareItemTypeIndex = RareItemTypeEnum.WeaponOfSlayEvil;
                    if (SaveGame.Rng.RandomLessThan(100) < 20)
                    {
                        item.RandartItemCharacteristics.ResFear = true;
                        item.RandartItemCharacteristics.Blessed = true;
                        item.RareItemTypeIndex = RareItemTypeEnum.WeaponOfEvilBane;
                    }
                    break;
                case 13:
                case 14:
                    item.RareItemTypeIndex = RareItemTypeEnum.WeaponOfSlayUndead;
                    item.RandartItemCharacteristics.HoldLife = true;
                    if (SaveGame.Rng.RandomLessThan(100) < 20)
                    {
                        item.RandartItemCharacteristics.ResNether = true;
                        item.RareItemTypeIndex = RareItemTypeEnum.WeaponOfUndeadBane;
                    }
                    break;
                case 15:
                case 16:
                case 17:
                    item.RareItemTypeIndex = RareItemTypeEnum.WeaponOfSlayOrc;
                    break;
                case 18:
                case 19:
                case 20:
                    item.RareItemTypeIndex = RareItemTypeEnum.WeaponOfSlayTroll;
                    break;
                case 21:
                case 22:
                case 23:
                    item.RareItemTypeIndex = RareItemTypeEnum.WeaponOfSlayGiant;
                    break;
                case 24:
                case 25:
                case 26:
                    item.RareItemTypeIndex = RareItemTypeEnum.WeaponOfSlayDemon;
                    break;
                case 27:
                    item.RareItemTypeIndex = RareItemTypeEnum.WeaponOfKadath;
                    if (SaveGame.Rng.DieRoll(3) == 1)
                    {
                        item.RandartItemCharacteristics.ResFear = true;
                    }
                    break;
                case 28:
                    item.RareItemTypeIndex = RareItemTypeEnum.WeaponBlessed;
                    break;
                case 29:
                case 30:
                    item.RareItemTypeIndex = RareItemTypeEnum.WeaponOfExtraAttacks;
                    break;
                case 31:
                case 32:
                    item.RareItemTypeIndex = RareItemTypeEnum.WeaponVampiric;
                    break;
                case 33:
                    item.RareItemTypeIndex = RareItemTypeEnum.WeaponOfPoisoning;
                    break;
                case 34:
                    item.RareItemTypeIndex = RareItemTypeEnum.WeaponChaotic;
                    item.ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(34) + 4);
                    break;
                case 35:
                    item.CreateRandart(false);
                    break;
                case 36:
                case 37:
                    item.RareItemTypeIndex = RareItemTypeEnum.WeaponOfSlaying;
                    if (SaveGame.Rng.DieRoll(3) == 1)
                    {
                        item.DamageDice *= 2;
                    }
                    else
                    {
                        do
                        {
                            item.DamageDice++;
                        } while (SaveGame.Rng.DieRoll(item.DamageDice) == 1);
                        do
                        {
                            item.DamageDiceSides++;
                        } while (SaveGame.Rng.DieRoll(item.DamageDiceSides) == 1);
                    }
                    if (SaveGame.Rng.DieRoll(5) == 1)
                    {
                        item.RandartItemCharacteristics.BrandPois = true;
                    }
                    if (CapableOfVorpalSlaying && SaveGame.Rng.DieRoll(3) == 1)
                    {
                        item.RandartItemCharacteristics.Vorpal = true;
                    }
                    break;
                case 38:
                case 39:
                    item.RareItemTypeIndex = RareItemTypeEnum.WeaponPlanarWeapon;
                    item.ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(22) + 16);
                    if (SaveGame.Rng.DieRoll(5) == 1)
                    {
                        item.RandartItemCharacteristics.SlayDemon = true;
                    }
                    break;
                case 40:
                    item.RareItemTypeIndex = RareItemTypeEnum.WeaponOfLaw;
                    if (SaveGame.Rng.DieRoll(3) == 1)
                    {
                        item.RandartItemCharacteristics.HoldLife = true;
                    }
                    if (SaveGame.Rng.DieRoll(3) == 1)
                    {
                        item.RandartItemCharacteristics.Dex = true;
                    }
                    if (SaveGame.Rng.DieRoll(5) == 1)
                    {
                        item.RandartItemCharacteristics.ResFear = true;
                    }
                    item.ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(22) + 16);
                    break;
                case 41:
                case 42:
                    if (CanBeWeaponOfSharpness)
                    {
                        item.RareItemTypeIndex = RareItemTypeEnum.WeaponOfSharpness;
                        item.TypeSpecificValue = item.GetBonusValue(5, level) + 1;
                    }
                    else
                    {
                        item.RareItemTypeIndex = RareItemTypeEnum.WeaponOfEarthquakes;
                        if (SaveGame.Rng.DieRoll(3) == 1)
                        {
                            item.RandartItemCharacteristics.Blows = true;
                        }
                        item.TypeSpecificValue = item.GetBonusValue(3, level);
                    }
                    break;
            }
            while (SaveGame.Rng.RandomLessThan(10 * item.DamageDice * item.DamageDiceSides) == 0)
            {
                item.DamageDice++;
            }
            if (item.DamageDice > 9)
            {
                item.DamageDice = 9;
            }
        }
        else if (power < -1)
        {
            if (SaveGame.Rng.RandomLessThan(Constants.MaxDepth) < level)
            {
                item.RareItemTypeIndex = RareItemTypeEnum.WeaponOfLeng;
                if (SaveGame.Rng.DieRoll(6) == 1)
                {
                    item.RandartItemCharacteristics.DreadCurse = true;
                }
            }
        }
    }
}
