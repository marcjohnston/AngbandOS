namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IceScrollItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? IgnoreCold => true;
    public override bool? EasyKnow => true;
    public override int? Weight => 5;
    public override int? Value => 5000;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
