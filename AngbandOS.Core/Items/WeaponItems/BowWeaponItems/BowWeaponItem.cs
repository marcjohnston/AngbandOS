namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class BowWeaponItem : WeaponItem
    {
        /// <summary>
        /// Returns the factory that created this bow weapon item.
        /// </summary>
        public override BowWeaponItemFactory Factory => (BowWeaponItemFactory)base.Factory;

        public override void ApplyRandomSlaying(ref IArtifactBias artifactBias)
        {
            if (artifactBias != null)
            {
                if (artifactBias.ApplySlaying(this))
                {
                    return;
                }
            }

            switch (Program.Rng.DieRoll(6))
            {
                case 1:
                case 2:
                case 3:
                    RandartItemCharacteristics.XtraMight = true;
                    if (artifactBias == null && Program.Rng.DieRoll(9) == 1)
                    {
                        artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<RangerArtifactBias>();
                    }
                    break;

                default:
                    RandartItemCharacteristics.XtraShots = true;
                    if (artifactBias == null && Program.Rng.DieRoll(9) == 1)
                    {
                        artifactBias = SaveGame.SingletonRepository.ArtifactBiases.Get<RangerArtifactBias>();
                    }
                    break;
            }
        }

        public override int WieldSlot => InventorySlot.RangedWeapon;
        public BowWeaponItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override bool IdentityCanBeSensed => true;
        public override bool CanApplyBlowsBonus => false;

        protected override void ApplyMagic(int level, int power, Store? store)
        {
            base.ApplyMagic(level, power, null);
            if (power > 1)
            {
                switch (Program.Rng.DieRoll(21))
                {
                    case 1:
                    case 11:
                        RareItemTypeIndex = RareItemTypeEnum.BowOfExtraMight;
                        IArtifactBias artifactBias = null;
                        ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(34) + 4);
                        break;
                    case 2:
                    case 12:
                        RareItemTypeIndex = RareItemTypeEnum.BowOfExtraShots;
                        break;
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                        RareItemTypeIndex = RareItemTypeEnum.BowOfVelocity;
                        break;
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                    case 17:
                    case 18:
                    case 19:
                    case 20:
                        RareItemTypeIndex = RareItemTypeEnum.BowOfAccuracy;
                        break;
                    case 21:
                        CreateRandart(false);
                        break;
                }
            }
        }
        public override string GetDetailedDescription()
        {
            string basenm = "";
            RefreshFlagBasedProperties();
            int power = Factory.MissileDamageMultiplier;
            if (Factory.XtraMight)
            {
                power++;
            }
            basenm += $" (x{power})";
            if (IsKnown())
            {
                basenm += $" ({GetSignedValue(BonusToHit)},{GetSignedValue(BonusDamage)})";

                if (BaseArmorClass != 0)
                {
                    // Add base armour class for all types of armour and when the base armour class is greater than zero.
                    basenm += $" [{BaseArmorClass},{GetSignedValue(BonusArmorClass)}]";
                }
                else if (BonusArmorClass != 0)
                {
                    // This is not armour, only show bonus armour class, if it is not zero and we know about it.
                    basenm += $" [{GetSignedValue(BonusArmorClass)}]";
                }
            }
            else if (BaseArmorClass != 0)
            {
                basenm += $" [{BaseArmorClass}]";
            }
            return basenm;
        }
    }
}