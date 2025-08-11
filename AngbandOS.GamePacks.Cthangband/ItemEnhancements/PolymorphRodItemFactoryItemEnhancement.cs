namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PolymorphRodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 15;
    public override int Cost => 1200;
    public override int DamageDice => 1;
    public override int DiceSides => 1;
}
