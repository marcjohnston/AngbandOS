namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class SpecialPowerRareItemType : Base2RareItemType
{
    private SpecialPowerRareItemType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => 'x';
    public override string Name => "Special Power";
    public override int Cost => 0;
    public override string FriendlyName => "";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.SpecialPower;
    public override int Rarity => 0;
    public override int Rating => 0;
    public override int Slot => 0;
}
