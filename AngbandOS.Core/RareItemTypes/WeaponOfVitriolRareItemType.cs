namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class WeaponOfVitriolRareItemType : Base2RareItemType
{
    private WeaponOfVitriolRareItemType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Weapon of Vitriol";
    public override bool BrandAcid => true;
    public override int Cost => 8000;
    public override string FriendlyName => "of Vitriol";
    public override bool IgnoreAcid => true;
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.WeaponOfVitriol;
    public override int Rarity => 0;
    public override int Rating => 15;
    public override bool ResAcid => true;
    public override int Slot => 24;
}