namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistColdRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override bool? IgnoreCold => true;
    public override bool? ResCold => true;
    public override int? Weight => 2;
    public override int? Value => 250;
    public override string? HatesElectricity => "true";
}
