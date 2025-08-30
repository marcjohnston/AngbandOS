namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpearOfDestinyFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.StoneToMudDirectionalActivation);
    public override bool? Blessed => true;
    public override bool? BrandFire => true;
    public override int? TreasureRating => 20;
    public override bool? Feather => true;
    public override string FriendlyName => "of Destiny";
    public override bool? HideType => true;
    public override bool? HoldLife => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a spear which provides no light.
    /// </summary>
    public override int? Radius => 3;

    public override string? Infravision => "4";
    public override string? Intelligence => "4";
    public override string? Wisdom => "4";
    public override bool? ResFear => true;
    public override bool? ResFire => true;
    public override bool? ResLight => true;
    public override bool? SeeInvis => true;
    public override bool? ShowMods => true;
    public override bool? SlayDemon => true;
    public override int? SlayDragon => 3;
    public override bool? SlayEvil => true;
    public override bool? SlayGiant => true;
    public override bool? SlayUndead => true;
    public override int? Value => 77777;
    public override string Hits => "15";
    public override string Damage => "15";
    public override ColorEnum? Color => ColorEnum.Grey;
}
