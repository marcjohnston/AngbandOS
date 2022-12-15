using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class WeaponOfVitriolRareItemType : Base2RareItemType
{
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
    public override Enumerations.RareItemType RareItemType => Enumerations.RareItemType.WeaponOfVitriol;
    public override int Rarity => 0;
    public override int Rating => 15;
    public override bool ResAcid => true;
    public override int Slot => 24;
}
