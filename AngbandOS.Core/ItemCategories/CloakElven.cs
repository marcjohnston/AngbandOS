using AngbandOS.Core.Interface;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class CloakElven : CloakItemClass
    {
        public override char Character => '(';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Elven Cloak";

        public override int Ac => 4;
        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Cost => 1500;
        public override string FriendlyName => "& Elven Cloak~";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override bool Search => true;
        public override bool Stealth => true;
        public override int? SubCategory => 2;
        public override int ToA => 4;
        public override int Weight => 5;

        public override void ApplyMagic(Item item, int level, int power)
        {
            // Apply the standard armour characteristics.
            base.ApplyMagic(item, level, power);

            item.TypeSpecificValue = Program.Rng.DieRoll(4);
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