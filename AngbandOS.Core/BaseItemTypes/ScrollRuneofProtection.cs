using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollRuneofProtection : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Rune of Protection";

        public override int Chance1 => 2;
        public override int Chance2 => 4;
        public override int Cost => 500;
        public override string FriendlyName => "Rune of Protection";
        public override int Level => 50;
        public override int Locale1 => 50;
        public override int Locale2 => 90;
        public override int? SubCategory => 38;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            eventArgs.SaveGame.ElderSign();
            eventArgs.Identified = true;
        }
    }
}
