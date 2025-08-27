namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AcidBallsRodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 15;
    public override int Value => 5500;
    public override int DamageDice => 1;
    public override int DiceSides => 1;
}
