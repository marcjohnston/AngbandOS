using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionSpecialEnlightenment : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "*Enlightenment*";

        public override int Chance1 => 4;
        public override int Cost => 80000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "*Enlightenment*";
        public override int Level => 70;
        public override int Locale1 => 70;
        public override int? SubCategory => (int)PotionType.StarEnlightenment;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // *Enlightenment* shows you the whole level, increases your intelligence and
            // wisdom, identifies all your items, and detects everything
            saveGame.MsgPrint("You begin to feel more enlightened...");
            saveGame.MsgPrint(null);
            saveGame.Level.WizLight();
            saveGame.Player.TryIncreasingAbilityScore(Ability.Intelligence);
            saveGame.Player.TryIncreasingAbilityScore(Ability.Wisdom);
            saveGame.DetectTraps();
            saveGame.DetectDoors();
            saveGame.DetectStairs();
            saveGame.DetectTreasure();
            saveGame.DetectObjectsGold();
            saveGame.DetectObjectsNormal();
            saveGame.IdentifyPack();
            saveGame.SelfKnowledge();
            return true;
        }
    }
}
