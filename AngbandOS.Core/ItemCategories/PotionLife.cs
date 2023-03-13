namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionLife : PotionItemClass
    {
        private PotionLife(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Life";

        public override int[] Chance => new int[] { 4, 2, 0, 0 };
        public override int Cost => 5000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Life";
        public override int Level => 60;
        public override int[] Locale => new int[] { 60, 100, 0, 0 };
        public override int? SubCategory => (int)PotionType.Life;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Life heals you 5000 health, removes experience and ability score drains, and
            // cures blindness, confusion, stun, poison, and bleeding
            saveGame.MsgPrint("You feel life flow through your body!");
            saveGame.Player.RestoreLevel();
            saveGame.Player.RestoreHealth(5000);
            saveGame.Player.TimedPoison.ResetTimer();
            saveGame.Player.TimedBlindness.ResetTimer();
            saveGame.Player.TimedConfusion.ResetTimer();
            saveGame.Player.TimedHallucinations.ResetTimer();
            saveGame.Player.TimedStun.ResetTimer();
            saveGame.Player.TimedBleeding.ResetTimer();
            saveGame.Player.TryRestoringAbilityScore(Ability.Strength);
            saveGame.Player.TryRestoringAbilityScore(Ability.Constitution);
            saveGame.Player.TryRestoringAbilityScore(Ability.Dexterity);
            saveGame.Player.TryRestoringAbilityScore(Ability.Wisdom);
            saveGame.Player.TryRestoringAbilityScore(Ability.Intelligence);
            saveGame.Player.TryRestoringAbilityScore(Ability.Charisma);
            return true;
        }
        public override bool Smash(SaveGame saveGame, int who, int y, int x)
        {
            saveGame.Project(who, 1, y, x, Program.Rng.DiceRoll(50, 50), new OldHealProjectile(saveGame), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
            return false;
        }
        public override Item CreateItem(SaveGame saveGame) => new LifePotionItem(saveGame);
    }
}
