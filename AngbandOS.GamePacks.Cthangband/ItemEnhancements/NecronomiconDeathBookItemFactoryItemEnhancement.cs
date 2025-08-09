namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class NecronomiconDeathBookItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool EasyKnow => true;
    public override int Weight => 30;
    public override int Cost => 100000;
    public override int DamageDice => 1;
}
