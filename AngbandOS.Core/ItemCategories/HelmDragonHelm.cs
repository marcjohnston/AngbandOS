using AngbandOS.Core.Interface;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class HelmDragonHelm : HelmItemClass
    {
        public override char Character => ']';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Dragon Helm";

        public override int Ac => 8;
        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Cost => 10000;
        public override int Dd => 1;
        public override int Ds => 3;
        public override string FriendlyName => "& Dragon Helm~";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 45;
        public override int[] Locale => new int[] { 80, 0, 0, 0 };
        public override int? SubCategory => 7;
        public override int ToA => 10;
        public override int Weight => 50;

        /// <summary>
        /// Applies special magic to this dragon helm.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="level"></param>
        /// <param name="power"></param>
        public override void ApplyMagic(Item item, int level, int power)
        {
            // Apply the standard armour characteristics, regardless of the power.
            base.ApplyMagic(item, level, power);

            if (item.SaveGame.Level != null)
            {
                item.SaveGame.Level.TreasureRating += 5;
            }
            ApplyDragonscaleResistance(item);
        }
    }
}