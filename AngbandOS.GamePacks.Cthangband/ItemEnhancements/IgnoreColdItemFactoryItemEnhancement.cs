namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IgnoreColdItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IgnoreCold => true;
    public override bool EasyKnow => true;
}