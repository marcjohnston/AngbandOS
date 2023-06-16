namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class BlackDragonScaleMailArmorItemFactory : DragonScaleMailArmorItemFactory
{
    private BlackDragonScaleMailArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override string? DescribeActivationEffect => "breathe acid (130) every 450+d450 turns";
    public override char Character => '[';
    public override Colour Colour => Colour.Black;
    public override string Name => "Black Dragon Scale Mail";

    public override int Ac => 30;
    public override bool Activate => true;
    public override int[] Chance => new int[] { 8, 0, 0, 0 };
    public override int Cost => 30000;
    public override int Dd => 2;
    public override int Ds => 4;
    public override string FriendlyName => "Black Dragon Scale Mail~";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 60;
    public override int[] Locale => new int[] { 60, 0, 0, 0 };
    public override bool ResAcid => true;
    public override int? SubCategory => 1;
    public override int ToA => 10;
    public override int ToH => -2;
    public override int Weight => 200;
    public override Item CreateItem() => new BlackDragonScaleMailArmorItem(SaveGame);
}
