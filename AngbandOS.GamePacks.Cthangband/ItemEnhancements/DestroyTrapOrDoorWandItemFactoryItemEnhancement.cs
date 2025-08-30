namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DestroyTrapOrDoorWandItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Weight => 10;
    public override int? Value => 100;
    public override int? DamageDice => 1;
    public override int? DiceSides => 1;
    public override ColorEnum? Color => ColorEnum.Chartreuse;
    public override string? HatesElectricity => "true";
}
