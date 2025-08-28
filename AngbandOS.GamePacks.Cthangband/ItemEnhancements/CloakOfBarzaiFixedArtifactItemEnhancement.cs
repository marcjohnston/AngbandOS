namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CloakOfBarzaiFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? TreasureRating => 10;
    // Cloak of Barzai gives resistances
    public override string? ActivationName => nameof(ActivationsEnum.ResistAll20p1d20Activation);
    public override string FriendlyName => "of Barzai";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResAcid => true;
    public override bool? ResCold => true;
    public override bool? ResElec => true;
    public override bool? ResFire => true;
    public override bool? ResPois => true;
    public override int? Value => 10000;
    public override string BonusAttacksRollExpression => "15";
    public override ColorEnum? Color => ColorEnum.Green;
}
