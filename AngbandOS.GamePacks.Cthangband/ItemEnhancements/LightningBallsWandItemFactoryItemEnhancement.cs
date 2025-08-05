namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LightningBallsWandItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IgnoreElec => true;
    public override int Weight => 10;
}