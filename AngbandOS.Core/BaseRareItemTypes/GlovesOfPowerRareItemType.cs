namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class GlovesOfPowerRareItemType : Base2RareItemType
{
    public override char Character => ']';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Gloves of Power";
    public override int Cost => 2500;
    public override string FriendlyName => "of Power";
    public override bool HideType => true;
    public override int Level => 0;
    public override int MaxPval => 5;
    public override int MaxToA => 0;
    public override int MaxToD => 5;
    public override int MaxToH => 5;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.GlovesOfPower;
    public override int Rarity => 0;
    public override int Rating => 22;
    public override bool ShowMods => true;
    public override int Slot => 34;
    public override bool Str => true;
}
