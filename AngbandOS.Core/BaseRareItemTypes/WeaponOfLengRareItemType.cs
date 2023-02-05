namespace AngbandOS.Core;

[Serializable]
internal class WeaponOfLengRareItemType : Base2RareItemType
{
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Weapon of Leng";
    public override bool Aggravate => true;
    public override int Cost => 0;
    public override bool Cursed => true;
    public override string FriendlyName => "of Leng";
    public override bool HeavyCurse => true;
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 10;
    public override int MaxToD => 20;
    public override int MaxToH => 20;
    public override Enumerations.RareItemTypeEnum RareItemType => Enumerations.RareItemTypeEnum.WeaponOfLeng;
    public override int Rarity => 0;
    public override int Rating => 0;
    public override bool SeeInvis => true;
    public override int Slot => 24;
}
