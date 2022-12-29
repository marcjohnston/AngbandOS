namespace AngbandOS.Core;

[Serializable]
internal class WeaponOfKadathRareItemType : Base2RareItemType
{
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Weapon of Kadath";
    public override bool Con => true;
    public override int Cost => 20000;
    public override bool Dex => true;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Kadath";
    public override int Level => 0;
    public override int MaxPval => 2;
    public override int MaxToA => 0;
    public override int MaxToD => 5;
    public override int MaxToH => 5;
    public override Enumerations.RareItemType RareItemType => Enumerations.RareItemType.WeaponOfKadath;
    public override int Rarity => 0;
    public override int Rating => 20;
    public override bool SeeInvis => true;
    public override bool SlayGiant => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override int Slot => 24;
    public override bool Str => true;
}
