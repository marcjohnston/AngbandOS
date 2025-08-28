namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class NexusResistanceRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override bool? ResNexus => true;
    public override int? Weight => 2;
    public override int? Value => 3000;
}
