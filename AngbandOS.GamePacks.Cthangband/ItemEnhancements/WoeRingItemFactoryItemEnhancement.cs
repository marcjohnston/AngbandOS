namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WoeRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? IsCursed => true;
    public override bool? HideType => true;
    public override bool? Teleport => true;
    public override int? Weight => 2;
    public override int? Value => -4750;
    public override string? HatesElectricity => "true";
    public override bool? Valueless => true;
}
