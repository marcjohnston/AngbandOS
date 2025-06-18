namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IgnoreElementsItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
}