namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LightAndDarknessResistanceRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override bool ResDark => true;
    public override bool ResLight => true;
    public override int Weight => 2;
    public override int Cost => 3000;
    public override ColorEnum Color => ColorEnum.Gold;
}
