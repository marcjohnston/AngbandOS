namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpecialEnchantWeaponScrollItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override int? Weight => 5;
    public override int? Value => 500;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
