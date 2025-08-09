namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class IronHelmItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool CanReflectBoltsAndArrows => true;
    public override int Weight => 75;
    public override int Cost => 75;
    public override int DamageDice => 1;
}
