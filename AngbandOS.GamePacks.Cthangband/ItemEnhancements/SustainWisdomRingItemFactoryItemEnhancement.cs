namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SustainWisdomRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override bool SustWis => true;
    public override int Weight => 2;
    public override int Cost => 600;
    public override ColorEnum Color => ColorEnum.Gold;
}
