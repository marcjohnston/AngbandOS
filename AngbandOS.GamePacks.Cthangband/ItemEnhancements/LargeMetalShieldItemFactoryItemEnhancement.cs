namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class LargeMetalShieldItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool CanReflectBoltsAndArrows => true;
    public override int Weight => 120;
    public override int Cost => 200;
}
