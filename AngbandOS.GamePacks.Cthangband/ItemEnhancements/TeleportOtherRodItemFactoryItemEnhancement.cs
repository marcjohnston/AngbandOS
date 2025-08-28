namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TeleportOtherRodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override int? Weight => 15;
    public override int? Value => 1400;
    public override int? DamageDice => 1;
    public override int? DiceSides => 1;
}
