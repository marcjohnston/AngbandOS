using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionLife : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Life";

        public override int Chance1 => 4;
        public override int Chance2 => 2;
        public override int Cost => 5000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Life";
        public override int Level => 60;
        public override int Locale1 => 60;
        public override int Locale2 => 100;
        public override int? SubCategory => (int)PotionType.Life;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Life heals you 5000 health, removes experience and ability score drains, and
            // cures blindness, confusion, stun, poison, and bleeding
            saveGame.MsgPrint("You feel life flow through your body!");
            saveGame.Player.RestoreLevel();
            saveGame.Player.RestoreHealth(5000);
            saveGame.Player.SetTimedPoison(0);
            saveGame.Player.SetTimedBlindness(0);
            saveGame.Player.SetTimedConfusion(0);
            saveGame.Player.SetTimedHallucinations(0);
            saveGame.Player.SetTimedStun(0);
            saveGame.Player.SetTimedBleeding(0);
            saveGame.Player.TryRestoringAbilityScore(Ability.Strength);
            saveGame.Player.TryRestoringAbilityScore(Ability.Constitution);
            saveGame.Player.TryRestoringAbilityScore(Ability.Dexterity);
            saveGame.Player.TryRestoringAbilityScore(Ability.Wisdom);
            saveGame.Player.TryRestoringAbilityScore(Ability.Intelligence);
            saveGame.Player.TryRestoringAbilityScore(Ability.Charisma);
            return true;
        }
    }
}
