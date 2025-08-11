namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FlaskOfOilItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 10;
    public override int Cost => 3;
    public override int DamageDice => 2;
    public override int DiceSides => 6;
    public override ColorEnum Color => ColorEnum.Yellow;
}
