namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IocainePotionItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 4;
    public override int DamageDice => 20;
    public override int DiceSides => 20;
    public override ColorEnum Color => ColorEnum.Blue;
}
