namespace AngbandOS.Core.RareItems;

[Serializable]
internal class HatOfLightRareItem : RareItem
{
    private HatOfLightRareItem(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => ']';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Hat of Light";
    public override int Cost => 500;
    public override string FriendlyName => "of Light";
    public override int Level => 0;
    public override bool Lightsource => true;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.HatOfLight;
    public override int Rarity => 0;
    public override int Rating => 6;
    public override bool ResLight => true;
    public override int Slot => 33;
}
