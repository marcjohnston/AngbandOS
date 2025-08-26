namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpecialEnchantArmorScrollItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 5;
    public override int Value => 500;
    public override ColorEnum Color => ColorEnum.BrightBeige;
}
