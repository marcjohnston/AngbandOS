namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class WeaponOfDragonBaneRareItemType : Base2RareItemType
{
    private WeaponOfDragonBaneRareItemType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Weapon of Dragon Bane";
    public override bool Con => true;
    public override int Cost => 6000;
    public override string FriendlyName => "of Dragon Bane";
    public override bool KillDragon => true;
    public override int Level => 0;
    public override int MaxPval => 1;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.WeaponOfDragonBane;
    public override int Rarity => 0;
    public override int Rating => 24;
    public override bool SlayDragon => true;
    public override int Slot => 24;
}
