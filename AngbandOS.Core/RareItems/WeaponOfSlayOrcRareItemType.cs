namespace AngbandOS.Core.RareItems;

[Serializable]
internal class WeaponOfSlayOrcRareItem : RareItem
{
    private WeaponOfSlayOrcRareItem(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Weapon of Slay Orc";
    public override int Cost => 2500;
    public override string FriendlyName => "of Slay Orc";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.WeaponOfSlayOrc;
    public override int Rarity => 0;
    public override int Rating => 10;
    public override bool SlayOrc => true;
    public override int Slot => 24;
}
