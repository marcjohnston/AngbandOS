namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class RingItem : JewelleryItem
    {
        public override int WieldSlot
        {
            get
            {
                if (SaveGame.GetInventoryItem(InventorySlot.RightHand) == null)
                {
                    return InventorySlot.RightHand;
                }
                return InventorySlot.LeftHand;
            }
        }
        public RingItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 16;

        public override void ApplyMagic(int level, int power) // TODO: Split the switch into rings
        {
            if (power == 0 && Program.Rng.RandomLessThan(100) < 50)
            {
                power = -1;
            }
            IArtifactBias artifactBias = null;
            switch (ItemSubCategory)
            {
                case RingType.Attacks:
                    {
                        TypeSpecificValue = GetBonusValue(3, level);
                        if (TypeSpecificValue < 1)
                        {
                            TypeSpecificValue = 1;
                        }
                        if (power < 0)
                        {
                            IdentBroken = true;
                            IdentCursed = true;
                            TypeSpecificValue = 0 - TypeSpecificValue;
                        }
                        break;
                    }
                case RingType.Str:
                case RingType.Con:
                case RingType.Dex:
                case RingType.Int:
                    {
                        TypeSpecificValue = 1 + GetBonusValue(5, level);
                        if (power < 0)
                        {
                            IdentBroken = true;
                            IdentCursed = true;
                            TypeSpecificValue = 0 - TypeSpecificValue;
                        }
                        break;
                    }
                case RingType.Speed:
                    {
                        TypeSpecificValue = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
                        while (Program.Rng.RandomLessThan(100) < 50)
                        {
                            TypeSpecificValue++;
                        }
                        if (power < 0)
                        {
                            IdentBroken = true;
                            IdentCursed = true;
                            TypeSpecificValue = 0 - TypeSpecificValue;
                            break;
                        }
                        if (SaveGame.Level != null)
                        {
                            SaveGame.Level.TreasureRating += 25;
                        }
                        break;
                    }
                case RingType.Lordly:
                    {
                        do
                        {
                            ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(20) + 18);
                        } while (Program.Rng.DieRoll(4) == 1);
                        BonusArmourClass = 10 + Program.Rng.DieRoll(5) + GetBonusValue(10, level);
                        if (SaveGame.Level != null)
                        {
                            SaveGame.Level.TreasureRating += 5;
                        }
                    }
                    break;

                case RingType.Searching:
                    {
                        TypeSpecificValue = 1 + GetBonusValue(5, level);
                        if (power < 0)
                        {
                            IdentBroken = true;
                            IdentCursed = true;
                            TypeSpecificValue = 0 - TypeSpecificValue;
                        }
                        break;
                    }
                case RingType.Flames:
                case RingType.Acid:
                case RingType.Ice:
                    {
                        BonusArmourClass = 5 + Program.Rng.DieRoll(5) + GetBonusValue(10, level);
                        break;
                    }
                case RingType.Weakness:
                case RingType.Stupidity:
                    {
                        IdentBroken = true;
                        IdentCursed = true;
                        TypeSpecificValue = 0 - (1 + GetBonusValue(5, level));
                        break;
                    }
                case RingType.Woe:
                    {
                        IdentBroken = true;
                        IdentCursed = true;
                        BonusArmourClass = 0 - (5 + GetBonusValue(10, level));
                        TypeSpecificValue = 0 - (1 + GetBonusValue(5, level));
                        break;
                    }
                case RingType.Damage:
                    {
                        BonusDamage = 5 + Program.Rng.DieRoll(8) + GetBonusValue(10, level);
                        if (power < 0)
                        {
                            IdentBroken = true;
                            IdentCursed = true;
                            BonusDamage = 0 - BonusDamage;
                        }
                        break;
                    }
                case RingType.Accuracy:
                    {
                        BonusToHit = 5 + Program.Rng.DieRoll(8) + GetBonusValue(10, level);
                        if (power < 0)
                        {
                            IdentBroken = true;
                            IdentCursed = true;
                            BonusToHit = 0 - BonusToHit;
                        }
                        break;
                    }
                case RingType.Protection:
                    {
                        BonusArmourClass = 5 + Program.Rng.DieRoll(8) + GetBonusValue(10, level);
                        if (power < 0)
                        {
                            IdentBroken = true;
                            IdentCursed = true;
                            BonusArmourClass = 0 - BonusArmourClass;
                        }
                        break;
                    }
                case RingType.Slaying:
                    {
                        BonusDamage = Program.Rng.DieRoll(7) + GetBonusValue(10, level);
                        BonusToHit = Program.Rng.DieRoll(7) + GetBonusValue(10, level);
                        if (power < 0)
                        {
                            IdentBroken = true;
                            IdentCursed = true;
                            BonusToHit = 0 - BonusToHit;
                            BonusDamage = 0 - BonusDamage;
                        }
                        break;
                    }
            }
        }
    }
}