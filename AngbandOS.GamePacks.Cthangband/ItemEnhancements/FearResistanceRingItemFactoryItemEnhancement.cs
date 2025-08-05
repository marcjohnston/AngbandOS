namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FearResistanceRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override bool ResFear => true;
    public override int Weight => 2;
}