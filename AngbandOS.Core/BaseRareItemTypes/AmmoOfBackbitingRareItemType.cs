namespace AngbandOS.Core;

[Serializable]
internal class AmmoOfBackbitingRareItemType : Base2RareItemType
{
    public override char Character => '{';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Ammo of Backbiting";
    public override int Cost => 0;
    public override string FriendlyName => "of Backbiting";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 50;
    public override int MaxToH => 50;
    public override Enumerations.RareItemTypeEnum RareItemType => Enumerations.RareItemTypeEnum.AmmoOfBackbiting;
    public override int Rarity => 0;
    public override int Rating => 0;
    public override int Slot => 23;
}
