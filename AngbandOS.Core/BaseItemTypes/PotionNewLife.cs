using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionNewLife : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "New Life";

        public override int Chance1 => 20;
        public override int Chance2 => 10;
        public override int Chance3 => 5;
        public override int Cost => 750000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "New Life";
        public override int Level => 50;
        public override int Locale1 => 50;
        public override int Locale2 => 100;
        public override int Locale3 => 120;
        public override int Pval => 100;
        public override int? SubCategory => (int)PotionType.NewLife;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // New life rerolls your health, cures all mutations, and restores you to your birth race
            saveGame.Player.RerollHitPoints();
            if (saveGame.Player.Dna.HasMutations)
            {
                saveGame.MsgPrint("You are cured of all mutations.");
                saveGame.Player.Dna.LoseAllMutations();
                saveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
                saveGame.HandleStuff();
            }
            if (saveGame.Player.RaceIndex != saveGame.Player.RaceIndexAtBirth)
            {
                var oldRaceName = Race.RaceInfo[saveGame.Player.RaceIndexAtBirth].Title;
                saveGame.MsgPrint($"You feel more {oldRaceName} again.");
                saveGame.Player.ChangeRace(saveGame.Player.RaceIndexAtBirth);
                saveGame.Level.RedrawSingleLocation(saveGame.Player.MapY, saveGame.Player.MapX);
            }
            return true;
        }
    }
}
