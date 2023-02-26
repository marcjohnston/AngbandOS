namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class WeaponShatteredRareItemType : Base2RareItemType
{
    private WeaponShatteredRareItemType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Weapon (Shattered)";
    public override int Cost => 0;
    public override string FriendlyName => "(Shattered)";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 5;
    public override int MaxToH => 5;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.WeaponShattered;
    public override int Rarity => 0;
    public override int Rating => 0;
    public override int Slot => 24;
}
