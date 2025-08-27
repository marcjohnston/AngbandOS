namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShardResistanceRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override bool ResShards => true;
    public override int Weight => 2;
    public override int Value => 3000;
}
