namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class StaffsItemClass : ItemClass
{
    private StaffsItemClass(Game game) : base(game) { }
    public override string Name => "Staff";


    /// <summary>
    /// Returns the staff flavors repository because staves have flavors that need to be identified.
    /// </summary>
    protected override string[] ItemFlavorBindingKeys => new string[]
    {
        nameof(AshenStaffItemFlavor),
        nameof(AspenStaffItemFlavor),
        nameof(BalsaStaffItemFlavor),
        nameof(BambooStaffItemFlavor),
        nameof(BanyanStaffItemFlavor),
        nameof(BirchStaffItemFlavor),
        nameof(CedarStaffItemFlavor),
        nameof(CottonwoodStaffItemFlavor),
        nameof(CypressStaffItemFlavor),
        nameof(DogwoodStaffItemFlavor),
        nameof(ElmStaffItemFlavor),
        nameof(EucalyptusStaffItemFlavor),
        nameof(GoldenStaffItemFlavor),
        nameof(HawthornStaffItemFlavor),
        nameof(HemlockStaffItemFlavor),
        nameof(HickoryStaffItemFlavor),
        nameof(IronwoodStaffItemFlavor),
        nameof(LocustStaffItemFlavor),
        nameof(MahoganyStaffItemFlavor),
        nameof(MapleStaffItemFlavor),
        nameof(MistletoeStaffItemFlavor),
        nameof(MulberryStaffItemFlavor),
        nameof(OakStaffItemFlavor),
        nameof(PineStaffItemFlavor),
        nameof(RedwoodStaffItemFlavor),
        nameof(RosewoodStaffItemFlavor),
        nameof(RunedStaffItemFlavor),
        nameof(SilverStaffItemFlavor),
        nameof(SpruceStaffItemFlavor),
        nameof(SycamoreStaffItemFlavor),
        nameof(TeakStaffItemFlavor),
        nameof(WalnutStaffItemFlavor),
    };
}