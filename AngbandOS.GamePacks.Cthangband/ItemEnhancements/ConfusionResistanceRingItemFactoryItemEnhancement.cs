namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ConfusionResistanceRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override bool ResConf => true;
    public override int Weight => 2;
    public override int Cost => 3000;
}
