namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FearResistanceRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override bool ResFear => true;
    public override int Weight => 2;
    public override int Cost => 300;
    public override ColorEnum Color => ColorEnum.Gold;
}
