namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ClothCloakItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool CanReflectBoltsAndArrows => true;
    public override int Weight => 10;
    public override int Cost => 3;
}
