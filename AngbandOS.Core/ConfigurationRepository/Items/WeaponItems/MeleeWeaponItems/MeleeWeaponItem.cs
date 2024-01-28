// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal abstract class MeleeWeaponItem : WeaponItem
{
    public MeleeWeaponItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }

    protected virtual bool CanBeWeaponOfLaw => false;
    protected virtual bool CanBeWeaponOfSharpness => false;
    protected virtual bool CapableOfVorpalSlaying => false;
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        base.ApplyMagic(level, power, null);
        if (power > 1)
        {
            IArtifactBias artifactBias = null;
            switch (SaveGame.Rng.DieRoll(CanBeWeaponOfLaw || CanBeWeaponOfSharpness ? 42 : 40))
            {
                case 1:
                    RareItemTypeIndex = RareItemTypeEnum.WeaponElderSign;
                    if (SaveGame.Rng.DieRoll(4) == 1)
                    {
                        RandartItemCharacteristics.Blows = true;
                        if (TypeSpecificValue > 2)
                        {
                            TypeSpecificValue -= SaveGame.Rng.DieRoll(2);
                        }
                    }
                    break;
                case 2:
                    RareItemTypeIndex = RareItemTypeEnum.WeaponDefender;
                    if (SaveGame.Rng.DieRoll(3) == 1)
                    {
                        RandartItemCharacteristics.ResPois = true;
                    }
                    ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(22) + 16);
                    break;
                case 3:
                    RareItemTypeIndex = RareItemTypeEnum.WeaponOfVitriol;
                    break;
                case 4:
                    RareItemTypeIndex = RareItemTypeEnum.WeaponOfShocking;
                    break;
                case 5:
                    RareItemTypeIndex = RareItemTypeEnum.WeaponOfBurning;
                    break;
                case 6:
                    RareItemTypeIndex = RareItemTypeEnum.WeaponOfFreezing;
                    break;
                case 7:
                case 8:
                    RareItemTypeIndex = RareItemTypeEnum.WeaponOfSlayAnimal;
                    if (SaveGame.Rng.RandomLessThan(100) < 20)
                    {
                        RareItemTypeIndex = RareItemTypeEnum.WeaponOfAnimalBane;
                    }
                    break;
                case 9:
                case 10:
                    RareItemTypeIndex = RareItemTypeEnum.WeaponOfSlayDragon;
                    ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(12) + 4);
                    if (SaveGame.Rng.RandomLessThan(100) < 20)
                    {
                        if (SaveGame.Rng.DieRoll(3) == 1)
                        {
                            RandartItemCharacteristics.ResPois = true;
                        }
                        ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(14) + 4);
                        RareItemTypeIndex = RareItemTypeEnum.WeaponOfDragonBane;
                    }
                    break;
                case 11:
                case 12:
                    RareItemTypeIndex = RareItemTypeEnum.WeaponOfSlayEvil;
                    if (SaveGame.Rng.RandomLessThan(100) < 20)
                    {
                        RandartItemCharacteristics.ResFear = true;
                        RandartItemCharacteristics.Blessed = true;
                        RareItemTypeIndex = RareItemTypeEnum.WeaponOfEvilBane;
                    }
                    break;
                case 13:
                case 14:
                    RareItemTypeIndex = RareItemTypeEnum.WeaponOfSlayUndead;
                    RandartItemCharacteristics.HoldLife = true;
                    if (SaveGame.Rng.RandomLessThan(100) < 20)
                    {
                        RandartItemCharacteristics.ResNether = true;
                        RareItemTypeIndex = RareItemTypeEnum.WeaponOfUndeadBane;
                    }
                    break;
                case 15:
                case 16:
                case 17:
                    RareItemTypeIndex = RareItemTypeEnum.WeaponOfSlayOrc;
                    break;
                case 18:
                case 19:
                case 20:
                    RareItemTypeIndex = RareItemTypeEnum.WeaponOfSlayTroll;
                    break;
                case 21:
                case 22:
                case 23:
                    RareItemTypeIndex = RareItemTypeEnum.WeaponOfSlayGiant;
                    break;
                case 24:
                case 25:
                case 26:
                    RareItemTypeIndex = RareItemTypeEnum.WeaponOfSlayDemon;
                    break;
                case 27:
                    RareItemTypeIndex = RareItemTypeEnum.WeaponOfKadath;
                    if (SaveGame.Rng.DieRoll(3) == 1)
                    {
                        RandartItemCharacteristics.ResFear = true;
                    }
                    break;
                case 28:
                    RareItemTypeIndex = RareItemTypeEnum.WeaponBlessed;
                    break;
                case 29:
                case 30:
                    RareItemTypeIndex = RareItemTypeEnum.WeaponOfExtraAttacks;
                    break;
                case 31:
                case 32:
                    RareItemTypeIndex = RareItemTypeEnum.WeaponVampiric;
                    break;
                case 33:
                    RareItemTypeIndex = RareItemTypeEnum.WeaponOfPoisoning;
                    break;
                case 34:
                    RareItemTypeIndex = RareItemTypeEnum.WeaponChaotic;
                    ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(34) + 4);
                    break;
                case 35:
                    CreateRandart(false);
                    break;
                case 36:
                case 37:
                    RareItemTypeIndex = RareItemTypeEnum.WeaponOfSlaying;
                    if (SaveGame.Rng.DieRoll(3) == 1)
                    {
                        DamageDice *= 2;
                    }
                    else
                    {
                        do
                        {
                            DamageDice++;
                        } while (SaveGame.Rng.DieRoll(DamageDice) == 1);
                        do
                        {
                            DamageDiceSides++;
                        } while (SaveGame.Rng.DieRoll(DamageDiceSides) == 1);
                    }
                    if (SaveGame.Rng.DieRoll(5) == 1)
                    {
                        RandartItemCharacteristics.BrandPois = true;
                    }
                    if (CapableOfVorpalSlaying && SaveGame.Rng.DieRoll(3) == 1)
                    {
                        RandartItemCharacteristics.Vorpal = true;
                    }
                    break;
                case 38:
                case 39:
                    RareItemTypeIndex = RareItemTypeEnum.WeaponPlanarWeapon;
                    ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(22) + 16);
                    if (SaveGame.Rng.DieRoll(5) == 1)
                    {
                        RandartItemCharacteristics.SlayDemon = true;
                    }
                    break;
                case 40:
                    RareItemTypeIndex = RareItemTypeEnum.WeaponOfLaw;
                    if (SaveGame.Rng.DieRoll(3) == 1)
                    {
                        RandartItemCharacteristics.HoldLife = true;
                    }
                    if (SaveGame.Rng.DieRoll(3) == 1)
                    {
                        RandartItemCharacteristics.Dex = true;
                    }
                    if (SaveGame.Rng.DieRoll(5) == 1)
                    {
                        RandartItemCharacteristics.ResFear = true;
                    }
                    ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(22) + 16);
                    break;
                case 41:
                case 42:
                    if (CanBeWeaponOfSharpness)
                    {
                        RareItemTypeIndex = RareItemTypeEnum.WeaponOfSharpness;
                        TypeSpecificValue = GetBonusValue(5, level) + 1;
                    }
                    else
                    {
                        RareItemTypeIndex = RareItemTypeEnum.WeaponOfEarthquakes;
                        if (SaveGame.Rng.DieRoll(3) == 1)
                        {
                            RandartItemCharacteristics.Blows = true;
                        }
                        TypeSpecificValue = GetBonusValue(3, level);
                    }
                    break;
            }
            while (SaveGame.Rng.RandomLessThan(10 * DamageDice * DamageDiceSides) == 0)
            {
                DamageDice++;
            }
            if (DamageDice > 9)
            {
                DamageDice = 9;
            }
        }
        else if (power < -1)
        {
            if (SaveGame.Rng.RandomLessThan(Constants.MaxDepth) < level)
            {
                RareItemTypeIndex = RareItemTypeEnum.WeaponOfLeng;
                if (SaveGame.Rng.DieRoll(6) == 1)
                {
                    RandartItemCharacteristics.DreadCurse = true;
                }
            }
        }

    }
}