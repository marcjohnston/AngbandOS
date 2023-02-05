namespace AngbandOS.Core;

[Serializable]
internal class GlovesOfWeaknessRareItemType : Base2RareItemType
{
    public override char Character => ']';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Gloves of Weakness";
    public override int Cost => 0;
    public override string FriendlyName => "of Weakness";
    public override int Level => 0;
    public override int MaxPval => 10;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.GlovesOfWeakness;
    public override int Rarity => 0;
    public override int Rating => 0;
    public override int Slot => 34;
    public override bool Str => true;
}
