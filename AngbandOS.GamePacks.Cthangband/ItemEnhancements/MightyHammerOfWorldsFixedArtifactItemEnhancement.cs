namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MightyHammerOfWorldsFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool Aggravate => true;
    public override int TreasureRating => 20;
    public override string FriendlyName => "of Worlds";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Impact => true;
    public override bool InstaArt => true;
    public override bool KillDragon => true;
    public override bool NoMagic => true;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override bool SlayDemon => true;
    public override bool SlayEvil => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool SlayUndead => true;
    public override bool Telepathy => true;
}