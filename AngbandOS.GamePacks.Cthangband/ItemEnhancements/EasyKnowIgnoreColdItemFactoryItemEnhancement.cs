namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class EasyKnowIgnoreColdItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IgnoreCold => true;
    public override bool EasyKnow => true;
}
