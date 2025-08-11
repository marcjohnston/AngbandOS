namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IronHelmItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool CanReflectBoltsAndArrows => true;
    public override int Weight => 75;
    public override int Cost => 75;
    public override int DamageDice => 1;
    public override int DiceSides => 3;
    public override ColorEnum Color => ColorEnum.Grey;
}
