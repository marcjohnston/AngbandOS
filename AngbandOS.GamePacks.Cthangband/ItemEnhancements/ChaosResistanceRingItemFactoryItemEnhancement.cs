namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChaosResistanceRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override bool ResChaos => true;
    public override bool ResConf => true;
    public override int Weight => 2;
    public override int Value => 13000;
}
