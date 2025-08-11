namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DisenchantmentResistanceRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override bool ResDisen => true;
    public override int Weight => 2;
    public override int Cost => 15000;
    public override ColorEnum Color => ColorEnum.Gold;
}
