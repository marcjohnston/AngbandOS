using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionEnlightenment : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Enlightenment";

        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Chance3 => 1;
        public override int Cost => 800;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Enlightenment";
        public override int Level => 25;
        public override int Locale1 => 25;
        public override int Locale2 => 50;
        public override int Locale3 => 100;
        public override int? SubCategory => (int)PotionType.Enlightenment;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Enlightenment shows you the whole level
            saveGame.MsgPrint("An image of your surroundings forms in your mind...");
            saveGame.Level.WizLight();
            return true;
        }
    }
}
