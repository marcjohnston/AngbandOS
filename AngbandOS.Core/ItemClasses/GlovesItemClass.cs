using AngbandOS.ArtifactBiases;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class GlovesItemClass : ArmourItemClass
    {
        public GlovesItemClass(SaveGame saveGame) : base(saveGame) { }
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Gloves;
        public override bool HatesFire => true;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.BrightBrown;

        public override int? SubCategory => null; // No longer being used

        /// <summary>
        /// Applies a good random rare characteristics to gloves.
        /// </summary>
        /// <param name="item"></param>
        protected override void ApplyRandomGoodRareCharacteristics(Item item)
        {
            switch (Program.Rng.DieRoll(10))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    item.RareItemTypeIndex = Enumerations.RareItemType.GlovesOfFreeAction;
                    break;
                case 5:
                case 6:
                case 7:
                    item.RareItemTypeIndex = Enumerations.RareItemType.GlovesOfSlaying;
                    break;
                case 8:
                case 9:
                    item.RareItemTypeIndex = Enumerations.RareItemType.GlovesOfAgility;
                    break;
                case 10:
                    IArtifactBias artifactBias = null;
                    item.RareItemTypeIndex = Enumerations.RareItemType.GlovesOfPower;
                    item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
                    break;
            }
        }

        /// <summary>
        /// Applies a poor random rare characteristics to gloves.
        /// </summary>
        /// <param name="item"></param>
        protected override void ApplyRandomPoorRareCharacteristics(Item item)
        {
            switch (Program.Rng.DieRoll(2))
            {
                case 1:
                    {
                        item.RareItemTypeIndex = Enumerations.RareItemType.GlovesOfClumsiness;
                        break;
                    }
                default:
                    {
                        item.RareItemTypeIndex = Enumerations.RareItemType.GlovesOfWeakness;
                        break;
                    }
            }
        }

        /// <summary>
        /// Applies standard magic to gloves.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="level"></param>
        /// <param name="power"></param>
        public override void ApplyMagic(Item item, int level, int power)
        {
            if (power != 0)
            {
                // Apply the standard armour characteristics.
                base.ApplyMagic(item, level, power);

                if (power > 1)
                {
                    if (Program.Rng.DieRoll(20) == 1)
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
    }
}
