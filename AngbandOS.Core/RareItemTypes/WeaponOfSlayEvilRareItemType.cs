namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class WeaponOfSlayEvilRareItemType : Base2RareItemType
{
    private WeaponOfSlayEvilRareItemType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Weapon of Slay Evil";
    public override int Cost => 3500;
    public override string FriendlyName => "of Slay Evil";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.WeaponOfSlayEvil;
    public override int Rarity => 0;
    public override int Rating => 18;
    public override bool SlayEvil => true;
    public override int Slot => 24;
}
