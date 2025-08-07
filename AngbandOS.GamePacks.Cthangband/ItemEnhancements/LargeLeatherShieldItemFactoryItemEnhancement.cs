namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class LargeLeatherShieldItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool CanReflectBoltsAndArrows => true;
    public override int Weight => 100;
    public override int Cost => 120;
}
