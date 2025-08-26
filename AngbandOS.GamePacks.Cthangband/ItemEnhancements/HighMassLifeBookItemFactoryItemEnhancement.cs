namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HighMassLifeBookItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 30;
    public override int Value => 1000;
    public override int DamageDice => 1;
    public override int DiceSides => 1;
}
