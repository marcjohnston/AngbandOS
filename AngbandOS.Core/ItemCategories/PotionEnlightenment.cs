using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionEnlightenment : PotionItemClass
    {
        public PotionEnlightenment(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '!';
        public override string Name => "Enlightenment";

        public override int[] Chance => new int[] { 1, 1, 1, 0 };
        public override int Cost => 800;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Enlightenment";
        public override int Level => 25;
        public override int[] Locale => new int[] { 25, 50, 100, 0 };
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
