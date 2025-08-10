namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class TrapLocationRodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 15;
    public override int Cost => 100;
    public override int DamageDice => 1;
    public override int DiceSides => 1;
}
