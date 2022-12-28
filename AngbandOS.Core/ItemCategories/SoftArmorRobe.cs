using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class SoftArmorRobe : SoftArmorItemClass
    {
        private SoftArmorRobe(SaveGame saveGame) { } // This object is a singleton.

        public override char Character => '(';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Robe";

        public override int Ac => 2;
        public override int[] Chance => new int[] { 1, 1, 0, 0 };
        public override int Cost => 4;
        public override string FriendlyName => "& Robe~";
        public override int Level => 1;
        public override int[] Locale => new int[] { 1, 50, 0, 0 };
        public override int? SubCategory => 2;
        public override int Weight => 20;

        /// <summary>
        /// Applies special magic to this robe.
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
                    // Robes have a chance of having the armour of permanence instead of a random characteristic.
                    if (Program.Rng.RandomLessThan(100) < 10)
                    {
                        item.RareItemTypeIndex = Enumerations.RareItemType.ArmourOfPermanence;
                    }
                    else
                    {
                        ApplyRandomGoodRareCharacteristics(item);
                    }
                }
            }
        }

    }
}
