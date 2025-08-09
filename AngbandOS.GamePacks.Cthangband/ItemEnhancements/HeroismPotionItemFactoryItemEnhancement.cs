namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class HeroismPotionItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 4;
    public override int Cost => 35;
    public override int DamageDice => 1;
}
