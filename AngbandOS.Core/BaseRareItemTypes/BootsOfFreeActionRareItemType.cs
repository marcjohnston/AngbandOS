namespace AngbandOS.Core;

[Serializable]
internal class BootsOfFreeActionRareItemType : Base2RareItemType
{
    public override char Character => ']';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Boots of Free Action";
    public override int Cost => 1000;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Free Action";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override Enumerations.RareItemTypeEnum RareItemType => Enumerations.RareItemTypeEnum.BootsOfFreeAction;
    public override int Rarity => 0;
    public override int Rating => 15;
    public override int Slot => 35;
}
