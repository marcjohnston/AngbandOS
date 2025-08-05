namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class AzathothChaosBookItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool EasyKnow => true;
    public override int Weight => 30;
}