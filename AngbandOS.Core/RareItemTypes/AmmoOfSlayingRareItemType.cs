namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class AmmoOfSlayingRareItemType : Base2RareItemType
{
    private AmmoOfSlayingRareItemType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '{';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Ammo of Slaying";
    public override int Cost => 20;
    public override string FriendlyName => "of Slaying";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 12;
    public override int MaxToH => 12;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.AmmoOfSlaying;
    public override int Rarity => 0;
    public override int Rating => 15;
    public override int Slot => 23;
}
