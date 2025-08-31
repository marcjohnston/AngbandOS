namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DarknessScrollItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override int? Weight => 5;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
    public override bool? Valueless => true;
}
