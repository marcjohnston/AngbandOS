namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SustainStrengthRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override bool? SustStr => true;
    public override int? Weight => 2;
    public override int? Value => 750;
}
