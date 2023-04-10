namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class StaffOfTheMagi : StaffItemClass
    {
        private StaffOfTheMagi(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '_';
        public override string Name => "the Magi";

        public override int[] Chance => new int[] { 2, 0, 0, 0 };
        public override int Cost => 4500;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "the Magi";
        public override int Level => 70;
        public override int[] Locale => new int[] { 70, 0, 0, 0 };
        public override int? SubCategory => 19;
        public override int Weight => 50;

        public override void UseStaff(UseStaffEvent eventArgs)
        {
            if (eventArgs.SaveGame.Player.TryRestoringAbilityScore(Ability.Intelligence))
            {
                eventArgs.Identified = true;
            }
            if (eventArgs.SaveGame.Player.Mana < eventArgs.SaveGame.Player.MaxMana)
            {
                eventArgs.SaveGame.Player.Mana = eventArgs.SaveGame.Player.MaxMana;
                eventArgs.SaveGame.Player.FractionalMana = 0;
                eventArgs.Identified = true;
                eventArgs.SaveGame.MsgPrint("Your feel your head clear.");
                eventArgs.SaveGame.RedrawManaFlaggedAction.Set();
            }
        }
        public override Item CreateItem() => new OfTheMagiStaffItem(SaveGame);
    }
}
