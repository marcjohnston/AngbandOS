namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SaltWaterPotionItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override int? Weight => 4;
    public override int? DamageDice => 1;
    public override int? DiceSides => 1;
}
