namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class StaffCureLightWounds : StaffItemClass
{
    private StaffCureLightWounds(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '_';
    public override string Name => "Cure Light Wounds";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 350;
    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "Cure Light Wounds";
    public override int Level => 5;
    public override int[] Locale => new int[] { 5, 0, 0, 0 };
    public override int? SubCategory => 16;
    public override int Weight => 50;

    public override void UseStaff(UseStaffEvent eventArgs)
    {
        if (eventArgs.SaveGame.Player.RestoreHealth(Program.Rng.DieRoll(8)))
        {
            eventArgs.Identified = true;
        }
    }
    public override Item CreateItem() => new CureLightWoundsStaffItem(SaveGame);
}
