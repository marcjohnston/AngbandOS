namespace AngbandOS.Core.RareItems;

[Serializable]
internal class WeaponOfFreezingRareItem : RareItem
{
    private WeaponOfFreezingRareItem(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Weapon of Freezing";
    public override bool BrandCold => true;
    public override int Cost => 2500;
    public override string FriendlyName => "of Freezing";
    public override bool IgnoreCold => true;
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.WeaponOfFreezing;
    public override int Rarity => 0;
    public override int Rating => 15;
    public override bool ResCold => true;
    public override int Slot => 24;
}
