namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class DetonationsPotionItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 4;
    public override int Cost => 10000;
    public override int DamageDice => 25;
    public override int DiceSides => 25;
}
