namespace AngbandOS.Core.ItemClasses
{
    /// <summary>
    /// Represents common characteristics for melee weapons.  Hafted, polearm and swords are all melee weapons.
    /// </summary>
    [Serializable]
    internal abstract class MeleeWeaponItemClass : WeaponItemClass
    {
        public MeleeWeaponItemClass(SaveGame saveGame) : base(saveGame) { }
        public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<MeleeWeaponInventorySlot>();
        protected virtual bool CanBeWeaponOfLaw => false;
        public override int WieldSlot => InventorySlot.MeleeWeapon;
        public override bool IdentityCanBeSensed => true;
        protected virtual bool CapableOfVorpalSlaying => false;
        protected virtual bool CanBeWeaponOfSharpness => false;
        public override void ApplyMagic(Item item, int level, int power)
        {
            base.ApplyMagic(item, level, power);
            if (power > 1)
            {
                IArtifactBias artifactBias = null;
                switch (Program.Rng.DieRoll(CanBeWeaponOfLaw || CanBeWeaponOfSharpness ? 42 : 40))
                {
                    case 1:
                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponElderSign;
                        if (Program.Rng.DieRoll(4) == 1)
                        {
                            item.RandartItemCharacteristics.Blows = true;
                            if (item.TypeSpecificValue > 2)
                            {
                                item.TypeSpecificValue -= Program.Rng.DieRoll(2);
                            }
                        }
                        break;
                    case 2:
                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponDefender;
                        if (Program.Rng.DieRoll(3) == 1)
                        {
                            item.RandartItemCharacteristics.ResPois = true;
                        }
                        item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
                        break;
                    case 3:
                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfVitriol;
                        break;
                    case 4:
                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfShocking;
                        break;
                    case 5:
                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfBurning;
                        break;
                    case 6:
                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfFreezing;
                        break;
                    case 7:
                    case 8:
                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayAnimal;
                        if (Program.Rng.RandomLessThan(100) < 20)
                        {
                            item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfAnimalBane;
                        }
                        break;
                    case 9:
                    case 10:
                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayDragon;
                        item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(12) + 4);
                        if (Program.Rng.RandomLessThan(100) < 20)
                        {
                            if (Program.Rng.DieRoll(3) == 1)
                            {
                                item.RandartItemCharacteristics.ResPois = true;
                            }
                            item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(14) + 4);
                            item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfDragonBane;
                        }
                        break;
                    case 11:
                    case 12:
                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayEvil;
                        if (Program.Rng.RandomLessThan(100) < 20)
                        {
                            item.RandartItemCharacteristics.ResFear = true;
                            item.RandartItemCharacteristics.Blessed = true;
                            item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfEvilBane;
                        }
                        break;
                    case 13:
                    case 14:
                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayUndead;
                        item.RandartItemCharacteristics.HoldLife = true;
                        if (Program.Rng.RandomLessThan(100) < 20)
                        {
                            item.RandartItemCharacteristics.ResNether = true;
                            item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfUndeadBane;
                        }
                        break;
                    case 15:
                    case 16:
                    case 17:
                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayOrc;
                        break;
                    case 18:
                    case 19:
                    case 20:
                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayTroll;
                        break;
                    case 21:
                    case 22:
                    case 23:
                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayGiant;
                        break;
                    case 24:
                    case 25:
                    case 26:
                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayDemon;
                        break;
                    case 27:
                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfKadath;
                        if (Program.Rng.DieRoll(3) == 1)
                        {
                            item.RandartItemCharacteristics.ResFear = true;
                        }
                        break;
                    case 28:
                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponBlessed;
                        break;
                    case 29:
                    case 30:
                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfExtraAttacks;
                        break;
                    case 31:
                    case 32:
                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponVampiric;
                        break;
                    case 33:
                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfPoisoning;
                        break;
                    case 34:
                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponChaotic;
                        item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(34) + 4);
                        break;
                    case 35:
                        item.CreateRandart(false);
                        break;
                    case 36:
                    case 37:
                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlaying;
                        if (Program.Rng.DieRoll(3) == 1)
                        {
                            item.DamageDice *= 2;
                        }
                        else
                        {
                            do
                            {
                                item.DamageDice++;
                            } while (Program.Rng.DieRoll(item.DamageDice) == 1);
                            do
                            {
                                item.DamageDiceSides++;
                            } while (Program.Rng.DieRoll(item.DamageDiceSides) == 1);
                        }
                        if (Program.Rng.DieRoll(5) == 1)
                        {
                            item.RandartItemCharacteristics.BrandPois = true;
                        }
                        if (CapableOfVorpalSlaying && Program.Rng.DieRoll(3) == 1)
                        {
                            item.RandartItemCharacteristics.Vorpal = true;
                        }
                        break;
                    case 38:
                    case 39:
                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponPlanarWeapon;
                        item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
                        if (Program.Rng.DieRoll(5) == 1)
                        {
                            item.RandartItemCharacteristics.SlayDemon = true;
                        }
                        break;
                    case 40:
                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfLaw;
                        if (Program.Rng.DieRoll(3) == 1)
                        {
                            item.RandartItemCharacteristics.HoldLife = true;
                        }
                        if (Program.Rng.DieRoll(3) == 1)
                        {
                            item.RandartItemCharacteristics.Dex = true;
                        }
                        if (Program.Rng.DieRoll(5) == 1)
                        {
                            item.RandartItemCharacteristics.ResFear = true;
                        }
                        item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
                        break;
                    case 41:
                    case 42:
                        if (CanBeWeaponOfSharpness)
                        {
                            item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSharpness;
                            item.TypeSpecificValue = GetBonusValue(5, level) + 1;
                        }
                        else
                        {
                            item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfEarthquakes;
                            if (Program.Rng.DieRoll(3) == 1)
                            {
                                item.RandartItemCharacteristics.Blows = true;
                            }
                            item.TypeSpecificValue = GetBonusValue(3, level);
                        }
                        break;
                }
                while (Program.Rng.RandomLessThan(10 * item.DamageDice * item.DamageDiceSides) == 0)
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
                if (Program.Rng.RandomLessThan(Constants.MaxDepth) < level)
                {
                    item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfLeng;
                    if (Program.Rng.DieRoll(6) == 1)
                    {
                        item.RandartItemCharacteristics.DreadCurse = true;
                    }
                }
            }

        }
    }
}
