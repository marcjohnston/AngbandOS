namespace AngbandOS.Core.RareItems;

[Serializable]
internal class ArmourOfResistAcidRareItem : RareItem
{
    private ArmourOfResistAcidRareItem(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '[';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Armour of Resist Acid";
    public override int Cost => 1000;
    public override string FriendlyName => "of Resist Acid";
    public override bool IgnoreAcid => true;
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.ArmourOfResistAcid;
    public override int Rarity => 0;
    public override int Rating => 16;
    public override bool ResAcid => true;
    public override int Slot => 30;
}
