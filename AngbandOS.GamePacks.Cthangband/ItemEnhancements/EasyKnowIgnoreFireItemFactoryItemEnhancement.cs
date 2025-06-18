namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class EasyKnowIgnoreFireItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IgnoreFire=> true;
    public override bool EasyKnow => true;
}