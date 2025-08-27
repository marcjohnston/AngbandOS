namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistanceAmuletItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override int Weight => 3;
    public override int Value => 25000;
}
