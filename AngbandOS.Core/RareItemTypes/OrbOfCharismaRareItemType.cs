namespace AngbandOS.Core.RareItemTypes;

[Serializable]
internal class OrbOfCharismaRareItemType : Base2RareItemType
{
    private OrbOfCharismaRareItemType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '~';
    public override Colour Colour => Colour.Purple;
    public override string Name => "Orb of Charisma";
    public override int Cost => 1000;
    public override string FriendlyName => "of Charisma";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override RareItemTypeEnum RareItemType => RareItemTypeEnum.OrbOfCharisma;
    public override int Rarity => 0;
    public override int Rating => 0;
    public override int Slot => 0;
    public override bool SustCha => true;
}