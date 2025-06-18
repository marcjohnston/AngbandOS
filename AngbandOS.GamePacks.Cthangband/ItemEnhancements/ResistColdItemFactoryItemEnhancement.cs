namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistColdItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override bool IgnoreCold => true;
    public override bool ResCold => true;
}