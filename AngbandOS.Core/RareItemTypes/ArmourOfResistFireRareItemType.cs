namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class ArmourOfResistFireRareItemType : Base2RareItemType
{
    private ArmourOfResistFireRareItemType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '[';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Armour of Resist Fire";
    public override int Cost => 800;
    public override string FriendlyName => "of Resist Fire";
    public override bool IgnoreFire => true;
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.ArmourOfResistFire;
    public override int Rarity => 0;
    public override int Rating => 14;
    public override bool ResFire => true;
    public override int Slot => 30;
}
