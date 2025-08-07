namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IceScrollItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IgnoreCold => true;
    public override bool EasyKnow => true;
    public override int Weight => 5;
    public override int Cost => 5000;
}
