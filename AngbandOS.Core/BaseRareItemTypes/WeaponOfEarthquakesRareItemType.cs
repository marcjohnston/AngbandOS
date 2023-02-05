namespace AngbandOS.Core;

[Serializable]
internal class WeaponOfEarthquakesRareItemType : Base2RareItemType
{
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Weapon of Earthquakes";
    public override int Cost => 4000;
    public override string FriendlyName => "of Earthquakes";
    public override bool Impact => true;
    public override int Level => 0;
    public override int MaxPval => 3;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.WeaponOfEarthquakes;
    public override int Rarity => 0;
    public override int Rating => 20;
    public override int Slot => 24;
    public override bool Tunnel => true;
}
