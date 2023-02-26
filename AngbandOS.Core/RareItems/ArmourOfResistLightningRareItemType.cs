namespace AngbandOS.Core.RareItems;

[Serializable]
internal class ArmourOfResistLightningRareItem : RareItem
{
    private ArmourOfResistLightningRareItem(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '[';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Armour of Resist Lightning";
    public override int Cost => 400;
    public override string FriendlyName => "of Resist Lightning";
    public override bool IgnoreElec => true;
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.ArmourOfResistLightning;
    public override int Rarity => 0;
    public override int Rating => 10;
    public override bool ResElec => true;
    public override int Slot => 30;
}
