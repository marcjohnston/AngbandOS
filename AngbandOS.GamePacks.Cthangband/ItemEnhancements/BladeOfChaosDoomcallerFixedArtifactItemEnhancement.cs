namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BladeOfChaosDoomcallerFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool Aggravate => true;
    public override bool BrandCold => true;
    public override bool BrandFire => true;
    public override bool BrandPois => true;
    public override bool Chaotic => true;
    public override int TreasureRating => 20;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Doomcaller'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int SlayDragon => 5;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for the Blade of Chaos which provides no light.
    /// </summary>
    public override int Radius => 1;
    public override bool ResAcid => true;
    public override bool ResChaos => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override bool SlayEvil => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool Telepathy => true;
    public override bool Vorpal => true;
    public override int Cost => 250000;
    public override int DamageDice => 6;
}
