namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ColdBallsRodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 15;
    public override int Cost => 4500;
    public override int DamageDice => 1;
    public override int DiceSides => 1;
}
