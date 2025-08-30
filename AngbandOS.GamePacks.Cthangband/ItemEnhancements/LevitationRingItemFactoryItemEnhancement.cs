namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LevitationRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override bool? Feather => true;
    public override int? Weight => 2;
    public override int? Value => 200;
    public override string? HatesElectricity => "true";
}
