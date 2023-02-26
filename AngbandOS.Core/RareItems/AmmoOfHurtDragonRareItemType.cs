namespace AngbandOS.Core.RareItems;

[Serializable]
internal class AmmoOfHurtDragonRareItem : RareItem
{
    private AmmoOfHurtDragonRareItem(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '{';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Ammo of Hurt Dragon";
    public override int Cost => 35;
    public override string FriendlyName => "of Hurt Dragon";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.AmmoOfHurtDragon;
    public override int Rarity => 0;
    public override int Rating => 10;
    public override bool SlayDragon => true;
    public override int Slot => 23;
}
