namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShortSwordOfMerlinFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override string FriendlyName => "of Merlin";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusAttacksRollExpression => "2";
    public override bool Regen => true;
    public override bool ResDisen => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayAnimal => true;
    public override bool SlowDigest => true;
    public override int Value => 35000;
    public override string BonusHitsRollExpression => "3";
    public override string BonusDamageRollExpression => "7";
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
