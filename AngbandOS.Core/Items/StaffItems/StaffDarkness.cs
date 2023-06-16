namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class StaffDarkness : StaffItemClass
{
    private StaffDarkness(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '_';
    public override string Name => "Darkness";

    public override int[] Chance => new int[] { 1, 1, 0, 0 };
    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "Darkness";
    public override int Level => 5;
    public override int[] Locale => new int[] { 5, 50, 0, 0 };
    public override int? SubCategory => 0;
    public override int Weight => 50;

    public override void UseStaff(UseStaffEvent eventArgs)
    {
        if (!eventArgs.SaveGame.Player.HasBlindnessResistance && !eventArgs.SaveGame.Player.HasDarkResistance)
        {
            if (eventArgs.SaveGame.Player.TimedBlindness.AddTimer(3 + Program.Rng.DieRoll(5)))
            {
                eventArgs.Identified = true;
            }
        }
        if (eventArgs.SaveGame.UnlightArea(10, 3))
        {
            eventArgs.Identified = true;
        }
    }
    public override Item CreateItem() => new DarknessStaffItem(SaveGame);
}
