using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ShieldDragonShield : ShieldItemClass
    {
        public ShieldDragonShield(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '[';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Dragon Shield";

        public override int Ac => 8;
        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Cost => 10000;
        public override int Dd => 1;
        public override int Ds => 3;
        public override string FriendlyName => "& Dragon Shield~";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 70;
        public override int[] Locale => new int[] { 80, 0, 0, 0 };
        public override int? SubCategory => 6;
        public override int ToA => 10;
        public override int Weight => 100;

        /// <summary>
        /// Applies special magic to this dragon shield.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="level"></param>
        /// <param name="power"></param>
        public override void ApplyMagic(Item item, int level, int power)
        {
            // Apply the standard armour characteristics, regardless of the power level.
            base.ApplyMagic(item, level, power);

            if (item.SaveGame.Level != null)
            {
                item.SaveGame.Level.TreasureRating += 5;
            }
            ApplyDragonscaleResistance(item);
        }
    }
}
