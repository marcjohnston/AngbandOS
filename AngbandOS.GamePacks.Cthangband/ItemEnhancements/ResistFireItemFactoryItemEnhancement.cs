namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistFireItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override bool IgnoreFire => true;
    public override bool ResFire => true;
}