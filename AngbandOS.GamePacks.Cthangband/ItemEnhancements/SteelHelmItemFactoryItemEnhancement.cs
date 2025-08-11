namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SteelHelmItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool CanReflectBoltsAndArrows => true;
    public override int Weight => 60;
    public override int Cost => 200;
    public override int DamageDice => 1;
    public override int DiceSides => 3;
}
