namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AcidBallWandItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IgnoreAcid => true;
    public override int Weight => 10;
}
