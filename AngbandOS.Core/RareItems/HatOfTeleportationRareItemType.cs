namespace AngbandOS.Core.RareItems;

[Serializable]
internal class HatOfTeleportationRareItem : RareItem
{
    private HatOfTeleportationRareItem(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => ']';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Hat of Teleportation";
    public override int Cost => 0;
    public override string FriendlyName => "of Teleportation";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.HatOfTeleportation;
    public override int Rarity => 0;
    public override int Rating => 0;
    public override int Slot => 33;
    public override bool Teleport => true;
}