namespace AngbandOS.Core.RareItems;

[Serializable]
internal class WeaponOfDiggingRareItem : RareItem
{
    private WeaponOfDiggingRareItem(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Weapon of Digging";
    public override bool BrandAcid => true;
    public override int Cost => 500;
    public override string FriendlyName => "of Digging";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 0;
    public override int MaxPval => 5;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.WeaponOfDigging;
    public override int Rarity => 0;
    public override int Rating => 4;
    public override int Slot => 24;
    public override bool Tunnel => true;
}