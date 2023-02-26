namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class ArmourOfResistColdRareItemType : Base2RareItemType
{
    private ArmourOfResistColdRareItemType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '[';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Armour of Resist Cold";
    public override int Cost => 600;
    public override string FriendlyName => "of Resist Cold";
    public override bool IgnoreCold => true;
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.ArmourOfResistCold;
    public override int Rarity => 0;
    public override int Rating => 12;
    public override bool ResCold => true;
    public override int Slot => 30;
}
