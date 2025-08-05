namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class NetherResistanceRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override bool HoldLife => true;
    public override bool ResNether => true;
    public override int Weight => 2;
}