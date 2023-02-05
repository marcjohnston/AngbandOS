namespace AngbandOS.Core;

[Serializable]
internal class AmmoOfHurtEvilRareItemType : Base2RareItemType
{
    public override char Character => '{';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Ammo of Hurt Evil";
    public override int Cost => 25;
    public override string FriendlyName => "of Hurt Evil";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override Enumerations.RareItemTypeEnum RareItemType => Enumerations.RareItemTypeEnum.AmmoOfHurtEvil;
    public override int Rarity => 0;
    public override int Rating => 10;
    public override bool SlayEvil => true;
    public override int Slot => 23;
}
