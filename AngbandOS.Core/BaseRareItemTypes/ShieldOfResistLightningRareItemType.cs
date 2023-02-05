namespace AngbandOS.Core;

[Serializable]
internal class ShieldOfResistLightningRareItemType : Base2RareItemType
{
    public override char Character => ')';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Shield of Resist Lightning";
    public override int Cost => 400;
    public override string FriendlyName => "of Resist Lightning";
    public override bool IgnoreElec => true;
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.ShieldOfResistLightning;
    public override int Rarity => 0;
    public override int Rating => 10;
    public override bool ResElec => true;
    public override int Slot => 32;
}
