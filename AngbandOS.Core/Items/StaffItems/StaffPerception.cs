namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class StaffPerception : StaffItemClass
{
    private StaffPerception(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '_';
    public override string Name => "Perception";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 400;
    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "Perception";
    public override int Level => 10;
    public override int[] Locale => new int[] { 10, 0, 0, 0 };
    public override int? SubCategory => 5;
    public override int Weight => 50;

    public override void UseStaff(UseStaffEvent eventArgs)
    {
        if (!eventArgs.SaveGame.IdentifyItem())
        {
            eventArgs.ChargeUsed = false;
        }
        eventArgs.Identified = true;
    }
    public override Item CreateItem() => new PerceptionStaffItem(SaveGame);
}
