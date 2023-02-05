namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class ArmourBlastedRareItemType : Base2RareItemType
{
    public override char Character => '[';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Armour (Blasted)";
    public override int Cost => 0;
    public override string FriendlyName => "(Blasted)";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 10;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.ArmourBlasted;
    public override int Rarity => 0;
    public override int Rating => 0;
    public override int Slot => 30;
}
