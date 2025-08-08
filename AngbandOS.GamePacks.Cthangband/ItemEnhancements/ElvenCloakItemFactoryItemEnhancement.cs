namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ElvenCloakItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool CanReflectBoltsAndArrows => true;
    public override int Weight => 5;
    public override int Cost => 1500;
}
