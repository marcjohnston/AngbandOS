namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class WeaponOfEvilBaneRareItemType : Base2RareItemType
{
    private WeaponOfEvilBaneRareItemType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Weapon of Evil Bane";
    public override bool Blessed => true;
    public override int Cost => 5000;
    public override string FriendlyName => "of Evil Bane";
    public override int Level => 0;
    public override int MaxPval => 2;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.WeaponOfEvilBane;
    public override int Rarity => 0;
    public override int Rating => 20;
    public override bool SlayEvil => true;
    public override int Slot => 24;
    public override bool Wis => true;
}
