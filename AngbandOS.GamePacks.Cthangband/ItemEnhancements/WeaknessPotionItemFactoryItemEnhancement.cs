namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaknessPotionItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override int? Weight => 4;
    public override int? DamageDice => 3;
    public override int? DiceSides => 12;
}
