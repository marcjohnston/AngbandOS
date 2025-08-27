namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DrainLifeRodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 15;
    public override int Value => 3600;
    public override int DamageDice => 1;
    public override int DiceSides => 1;
}
