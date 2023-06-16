namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class IceRingItemFactory : RingItemFactory
{
    private IceRingItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override string? DescribeActivationEffect => "ball of cold and resist cold";
    public override char Character => '=';
    public override string Name => "Ice";

    public override bool Activate => true;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 3000;
    public override string FriendlyName => "Ice";
    public override bool IgnoreCold => true;
    public override int Level => 50;
    public override int[] Locale => new int[] { 50, 0, 0, 0 };
    public override bool ResCold => true;
    public override int? SubCategory => 19;
    public override int ToA => 15;
    public override int Weight => 2;
    public override Item CreateItem() => new IceRingItem(SaveGame);
}
