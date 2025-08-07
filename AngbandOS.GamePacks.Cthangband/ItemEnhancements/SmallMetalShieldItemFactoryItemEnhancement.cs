namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class SmallMetalShieldItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool CanReflectBoltsAndArrows => true;
    public override int Weight => 65;
    public override int Cost => 50;
}
