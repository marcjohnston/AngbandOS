namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TrapCreationScrollItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override int? Weight => 5;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
