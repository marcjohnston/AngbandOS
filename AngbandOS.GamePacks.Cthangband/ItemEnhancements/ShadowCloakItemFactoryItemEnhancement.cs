namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShadowCloakItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ResDark => true;
    public override bool ResLight => true;
    public override bool CanReflectBoltsAndArrows => true;
    public override int Weight => 5;
}