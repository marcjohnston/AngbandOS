namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IgnoreAcidAndCanReflectBoltsAndArrowsItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IgnoreAcid => true;
    public override bool CanReflectBoltsAndArrows => true;
}