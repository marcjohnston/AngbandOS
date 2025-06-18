namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistAcidItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override bool IgnoreAcid => true;
    public override bool ResAcid => true;
}