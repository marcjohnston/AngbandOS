namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PoisonResistanceRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override bool ResPois => true;
    public override int Weight => 2;
    public override int Value => 16000;
    public override ColorEnum Color => ColorEnum.Gold;
}
