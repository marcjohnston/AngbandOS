namespace AngbandOS.Core.RareItems;

[Serializable]
internal class WeaponPlanarWeaponRareItem : RareItem
{
    private WeaponPlanarWeaponRareItem(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Weapon (Planar Weapon)";
    public override bool Activate => true;
    public override int Cost => 7000;
    public override bool FreeAct => true;
    public override string FriendlyName => "(Planar Weapon)";
    public override int Level => 0;
    public override int MaxPval => 2;
    public override int MaxToA => 0;
    public override int MaxToD => 4;
    public override int MaxToH => 4;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.WeaponPlanarWeapon;
    public override int Rarity => 0;
    public override int Rating => 22;
    public override bool Regen => true;
    public override bool ResNexus => true;
    public override bool Search => true;
    public override bool SlayEvil => true;
    public override int Slot => 24;
    public override bool SlowDigest => true;
    public override bool Teleport => true;
}
