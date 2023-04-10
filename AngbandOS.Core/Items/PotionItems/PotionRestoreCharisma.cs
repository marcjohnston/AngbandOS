namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionRestoreCharisma : PotionItemClass
    {
        private PotionRestoreCharisma(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Restore Charisma";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 300;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Restore Charisma";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int? SubCategory => (int)PotionType.ResCha;
        public override int Weight => 4;

        public override bool Quaff(SaveGame saveGame)
        {
            // Restore charisma restores your charisma
            return saveGame.Player.TryRestoringAbilityScore(Ability.Charisma);
        }
        public override Item CreateItem() => new RestoreCharismaPotionItem(SaveGame);
    }
}
