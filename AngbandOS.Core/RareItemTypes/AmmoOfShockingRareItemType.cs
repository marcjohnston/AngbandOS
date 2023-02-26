namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class AmmoOfShockingRareItemType : Base2RareItemType
{
    private AmmoOfShockingRareItemType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '{';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Ammo of Shocking";
    public override bool BrandElec => true;
    public override int Cost => 30;
    public override string FriendlyName => "of Shocking";
    public override bool IgnoreElec => true;
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.AmmoOfShocking;
    public override int Rarity => 0;
    public override int Rating => 10;
    public override int Slot => 23;
}
