namespace AngbandOS.Core.RareItems;

[Serializable]
internal class OrbOfHealthRareItem : RareItem
{
    private OrbOfHealthRareItem(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '~';
    public override Colour Colour => Colour.Purple;
    public override string Name => "Orb of Health";
    public override int Cost => 1000;
    public override string FriendlyName => "of Health";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.OrbOfHealth;
    public override int Rarity => 0;
    public override int Rating => 0;
    public override bool Regen => true;
    public override int Slot => 0;
}
