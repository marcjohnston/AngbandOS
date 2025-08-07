namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TridentOfTheGnorriFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.TeleportAwayEvery150DirectionalActivation);
    public override bool Blessed => true;
    public override int TreasureRating => 20;
    public override bool Dex => true;
    public override bool FreeAct => true;
    public override string FriendlyName => "of the Gnorri";
    public override bool HideType => true;
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImAcid => true;
    public override string? BonusDexterityRollExpression => "4";
    public override bool Regen => true;
    public override bool ResNether => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override bool SlayDragon => true;
    public override bool SlowDigest => true;
    public override bool Feather => true;
    public override int Radius => 3;
    public override bool Telepathy => true;
    public override int Cost => 120000;
}
