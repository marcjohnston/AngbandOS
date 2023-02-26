namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class WeaponOfSlayTrollRareItemType : Base2RareItemType
{
    private WeaponOfSlayTrollRareItemType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Weapon of Slay Troll";
    public override int Cost => 2500;
    public override string FriendlyName => "of Slay Troll";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.WeaponOfSlayTroll;
    public override int Rarity => 0;
    public override int Rating => 10;
    public override bool SlayTroll => true;
    public override int Slot => 24;
}
