using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class WandTameMonster : WandItemCategory
    {
        public override char Character => '-';
        public override string Name => "Tame Monster";

        public override int Chance1 => 2;
        public override int Cost => 1500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Tame Monster";
        public override int Level => 30;
        public override int Locale1 => 30;
        public override int? SubCategory => WandType.CharmMonster;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            return saveGame.CharmMonster(dir, 45);
        }
        public override void ApplyMagic(Item item, int level, int power)
        {
            item.TypeSpecificValue = Program.Rng.DieRoll(6) + 2;
        }
    }
}
