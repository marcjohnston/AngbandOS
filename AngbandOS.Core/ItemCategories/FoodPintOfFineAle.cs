using AngbandOS.Core.Interface;
using System;
using System.Collections.Generic;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class FoodPintOfFineAle : FoodItemClass
    {
        public override char Character => ',';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Pint of Fine Ale";

        public override int Cost => 1;
        public override string FriendlyName => "& Pint~ of Fine Ale";
        public override int Pval => 500;
        public override int? SubCategory => 38;
        public override int Weight => 5;
        public override bool Eat(SaveGame saveGame)
        {
            saveGame.MsgPrint("That tastes good.");
            return true;
        }
    }
}