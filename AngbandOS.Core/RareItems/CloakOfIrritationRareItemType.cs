namespace AngbandOS.Core.RareItems;

[Serializable]
internal class CloakOfIrritationRareItem : RareItem
{
    private CloakOfIrritationRareItem(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '(';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Cloak of Irritation";
    public override bool Aggravate => true;
    public override int Cost => 0;
    public override string FriendlyName => "of Irritation";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 15;
    public override int MaxToH => 15;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.CloakOfIrritation;
    public override int Rarity => 0;
    public override int Rating => 0;
    public override bool ShowMods => true;
    public override int Slot => 31;
}