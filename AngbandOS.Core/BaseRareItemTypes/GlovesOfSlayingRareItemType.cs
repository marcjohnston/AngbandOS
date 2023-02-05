namespace AngbandOS.Core;

[Serializable]
internal class GlovesOfSlayingRareItemType : Base2RareItemType
{
    public override char Character => ']';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Gloves of Slaying";
    public override int Cost => 1500;
    public override string FriendlyName => "of Slaying";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 6;
    public override int MaxToH => 6;
    public override Enumerations.RareItemTypeEnum RareItemType => Enumerations.RareItemTypeEnum.GlovesOfSlaying;
    public override int Rarity => 0;
    public override int Rating => 17;
    public override bool ShowMods => true;
    public override int Slot => 34;
}
