namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistAcidAmuletItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override bool IgnoreAcid => true;
    public override bool ResAcid => true;
    public override int Weight => 3;
    public override int Value => 300;
}
