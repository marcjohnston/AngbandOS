namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class IronHelmItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool CanReflectBoltsAndArrows => true;
    public override int Weight => 75;
}