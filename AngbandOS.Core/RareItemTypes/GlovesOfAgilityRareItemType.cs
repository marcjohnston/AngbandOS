namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class GlovesOfAgilityRareItemType : Base2RareItemType
{
    private GlovesOfAgilityRareItemType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => ']';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Gloves of Agility";
    public override int Cost => 1000;
    public override bool Dex => true;
    public override string FriendlyName => "of Agility";
    public override bool HideType => true;
    public override int Level => 0;
    public override int MaxPval => 5;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.GlovesOfAgility;
    public override int Rarity => 0;
    public override int Rating => 14;
    public override int Slot => 34;
}