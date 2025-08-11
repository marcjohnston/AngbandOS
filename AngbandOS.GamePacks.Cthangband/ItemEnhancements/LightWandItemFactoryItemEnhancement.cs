namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LightWandItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int Weight => 10;
    public override int Cost => 200;
    public override int DamageDice => 1;
    public override int DiceSides => 1;
}
