namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodRestoration : RodItemFactory
    {
        private RodRestoration(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override bool RequiresAiming => false;
        public override char Character => '-';
        public override string Name => "Restoration";

        public override int[] Chance => new int[] { 16, 0, 0, 0 };
        public override int Cost => 25000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Restoration";
        public override int Level => 80;
        public override int[] Locale => new int[] { 80, 0, 0, 0 };
        public override int? SubCategory => 10;
        public override int Weight => 15;
        public override void Execute(ZapRodEvent zapRodEvent)
        {
            if (SaveGame.Player.RestoreLevel())
            {
                zapRodEvent.Identified = true;
            }
            if (SaveGame.Player.TryRestoringAbilityScore(Ability.Strength))
            {
                zapRodEvent.Identified = true;
            }
            if (SaveGame.Player.TryRestoringAbilityScore(Ability.Intelligence))
            {
                zapRodEvent.Identified = true;
            }
            if (SaveGame.Player.TryRestoringAbilityScore(Ability.Wisdom))
            {
                zapRodEvent.Identified = true;
            }
            if (SaveGame.Player.TryRestoringAbilityScore(Ability.Dexterity))
            {
                zapRodEvent.Identified = true;
            }
            if (SaveGame.Player.TryRestoringAbilityScore(Ability.Constitution))
            {
                zapRodEvent.Identified = true;
            }
            if (SaveGame.Player.TryRestoringAbilityScore(Ability.Charisma))
            {
                zapRodEvent.Identified = true;
            }
            zapRodEvent.Item.TypeSpecificValue = 999;
        }
        public override Item CreateItem() => new RestorationRodItem(SaveGame);
    }
}
