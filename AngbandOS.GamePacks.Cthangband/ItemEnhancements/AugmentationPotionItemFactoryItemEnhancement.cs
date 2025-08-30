namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AugmentationPotionItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override int? Weight => 4;
    public override int? Value => 60000;
    public override int? DamageDice => 1;
    public override int? DiceSides => 1;
    public override string? HatesCold => "true";
}
