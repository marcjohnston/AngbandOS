using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class WandScareMonster : WandItemCategory
    {
        public override char Character => '-';
        public override string Name => "Scare Monster";

        public override int Chance1 => 4;
        public override int Cost => 500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Scare Monster";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int? SubCategory => WandType.FearMonster;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            return saveGame.FearMonster(dir, 10);
        }
        public override void ApplyMagic(Item item, int level, int power)
        {
            item.TypeSpecificValue = Program.Rng.DieRoll(5) + 3;
        }
    }
}
