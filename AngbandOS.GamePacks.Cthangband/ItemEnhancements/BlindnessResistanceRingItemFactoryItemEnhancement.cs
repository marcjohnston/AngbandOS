namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BlindnessResistanceRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override bool ResBlind => true;
    public override int Weight => 2;
}