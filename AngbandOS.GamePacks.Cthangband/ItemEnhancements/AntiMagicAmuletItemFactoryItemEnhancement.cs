namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AntiMagicAmuletItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool NoMagic => true;
    public override int Weight => 3;
}

