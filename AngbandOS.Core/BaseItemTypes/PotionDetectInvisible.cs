using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionDetectInvisible : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Detect Invisible";

        public override int Chance1 => 1;
        public override int Cost => 50;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Detect Invisible";
        public override int Level => 3;
        public override int Locale1 => 3;
        public override int? SubCategory => (int)PotionType.DetectInvis;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Detect invisible gives you times see invisibility
            return saveGame.Player.SetTimedSeeInvisibility(saveGame.Player.TimedSeeInvisibility + 12 + Program.Rng.DieRoll(12));
        }
    }
}
