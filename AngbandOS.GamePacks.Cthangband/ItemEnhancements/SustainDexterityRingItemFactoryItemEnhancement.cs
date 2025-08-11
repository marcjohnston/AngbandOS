namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SustainDexterityRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override bool SustDex => true;
    public override int Weight => 2;
    public override int Cost => 750;
    public override ColorEnum Color => ColorEnum.Gold;
}
