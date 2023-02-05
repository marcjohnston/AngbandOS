namespace AngbandOS.Core;

[Serializable]
internal class AmmoOfSlayingRareItemType : Base2RareItemType
{
    public override char Character => '{';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Ammo of Slaying";
    public override int Cost => 20;
    public override string FriendlyName => "of Slaying";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 12;
    public override int MaxToH => 12;
    public override Enumerations.RareItemTypeEnum RareItemType => Enumerations.RareItemTypeEnum.AmmoOfSlaying;
    public override int Rarity => 0;
    public override int Rating => 15;
    public override int Slot => 23;
}
