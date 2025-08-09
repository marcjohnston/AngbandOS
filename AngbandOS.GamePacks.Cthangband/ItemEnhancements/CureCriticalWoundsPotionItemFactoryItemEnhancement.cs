namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class CureCriticalWoundsPotionItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 4;
    public override int Cost => 100;
    public override int DamageDice => 1;
}
