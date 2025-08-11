namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HardLeatherCapHelmItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool CanReflectBoltsAndArrows => true;
    public override int Weight => 15;
    public override int Cost => 12;
    public override ColorEnum Color => ColorEnum.Brown;
}
