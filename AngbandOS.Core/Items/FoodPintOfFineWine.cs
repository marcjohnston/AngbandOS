using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class FoodPintOfFineWine : FoodItemCategory
    {
        public override char Character => ',';
        public override Colour Colour => Colour.Red;
        public override string Name => "Pint of Fine Wine";

        public override int Cost => 2;
        public override string FriendlyName => "& Pint~ of Fine Wine";
        public override int Pval => 1000;
        public override int? SubCategory => 39;
        public override int Weight => 10;
        public override bool Eat(SaveGame saveGame)
        {
            saveGame.MsgPrint("That tastes good.");
            return true;
        }
    }
}
