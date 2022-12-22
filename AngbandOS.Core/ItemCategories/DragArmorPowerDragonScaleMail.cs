using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class DragArmorPowerDragonScaleMail : DragArmorItemClass
    {
        private DragArmorPowerDragonScaleMail(SaveGame saveGame) { } // This object is a singleton.

        public override char Character => '[';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Power Dragon Scale Mail";

        public override int Ac => 40;
        public override bool Activate => true;
        public override int[] Chance => new int[] { 64, 0, 0, 0 };
        public override int Cost => 350000;
        public override int Dd => 2;
        public override int Ds => 4;
        public override string FriendlyName => "Power Dragon Scale Mail~";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 110;
        public override int[] Locale => new int[] { 110, 0, 0, 0 };
        public override bool ResAcid => true;
        public override bool ResChaos => true;
        public override bool ResCold => true;
        public override bool ResConf => true;
        public override bool ResDark => true;
        public override bool ResDisen => true;
        public override bool ResElec => true;
        public override bool ResFire => true;
        public override bool ResLight => true;
        public override bool ResNether => true;
        public override bool ResNexus => true;
        public override bool ResPois => true;
        public override bool ResShards => true;
        public override bool ResSound => true;
        public override int? SubCategory => 30;
        public override int ToA => 15;
        public override int ToH => -3;
        public override int Weight => 250;
    }
}
