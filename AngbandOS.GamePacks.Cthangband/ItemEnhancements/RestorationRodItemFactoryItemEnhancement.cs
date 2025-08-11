namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RestorationRodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 15;
    public override int Cost => 25000;
    public override int DamageDice => 1;
    public override int DiceSides => 1;
}
