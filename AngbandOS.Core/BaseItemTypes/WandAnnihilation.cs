using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class WandAnnihilation : WandItemCategory
    {
        public override char Character => '-';
        public override string Name => "Annihilation";

        public override int Chance1 => 4;
        public override int Cost => 3000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Annihilation";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 60;
        public override int Locale1 => 60;
        public override int? SubCategory => WandType.Annihilation;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            return saveGame.DrainLife(dir, 125);
        }
        public override void ApplyMagic(Item item, int level, int power)
        {
            item.TypeSpecificValue = Program.Rng.DieRoll(2) + 1;
        }
    }
}
