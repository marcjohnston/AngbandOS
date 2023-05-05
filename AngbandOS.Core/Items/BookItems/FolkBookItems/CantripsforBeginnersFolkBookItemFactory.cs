namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class CantripsforBeginnersFolkBookItemFactory : FolkBookItemFactory
    {
        private CantripsforBeginnersFolkBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override Colour Colour => Colour.BrightPurple;
        public override string Name => "[Cantrips for Beginners]";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 100;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Cantrips for Beginners]";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int? SubCategory => 0;
        public override int Weight => 30;
        public override bool KindIsGood => false;
        public override Item CreateItem() => new CantripsforBeginnersFolkBookItem(SaveGame);
        public override Spell[] Spells => new Spell[] {
            new FolkSpellZap(),
            new FolkSpellWizardLock(),
            new FolkSpellDetectInvisibility(),
            new FolkSpellDetectMonsters(),
            new FolkSpellBlink(),
            new FolkSpellLightArea(),
            new FolkSpellTrapAndDoorDestruction(),
            new FolkSpellCureLightWounds(),
        };
    }
}
