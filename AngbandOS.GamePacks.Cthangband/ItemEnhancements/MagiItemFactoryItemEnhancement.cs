namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MagiItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 25;
    public override bool FreeAct => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Search => true;
    public override bool SeeInvis => true;
}