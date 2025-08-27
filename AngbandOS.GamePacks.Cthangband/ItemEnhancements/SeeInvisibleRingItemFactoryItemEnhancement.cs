namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SeeInvisibleRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override bool SeeInvis => true;
    public override int Weight => 2;
    public override int Value => 340;
}
