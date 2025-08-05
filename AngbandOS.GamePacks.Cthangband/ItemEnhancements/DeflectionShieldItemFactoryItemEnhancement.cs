namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DeflectionShieldItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IgnoreAcid => true;
    public override bool CanReflectBoltsAndArrows => true;
    public override int Weight => 100;
}
