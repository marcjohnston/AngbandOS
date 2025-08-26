namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class EnchantWeaponToHitScrollItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 5;
    public override int Value => 125;
    public override ColorEnum Color => ColorEnum.BrightBeige;
}
