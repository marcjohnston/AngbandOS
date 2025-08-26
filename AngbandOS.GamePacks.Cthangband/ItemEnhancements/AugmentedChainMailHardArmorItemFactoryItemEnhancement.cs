namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AugmentedChainMailHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool CanReflectBoltsAndArrows => true;
    public override int Weight => 270;
    public override int Value => 900;
    public override int DamageDice => 1;
    public override int DiceSides => 4;
    public override ColorEnum Color => ColorEnum.Grey;
}
