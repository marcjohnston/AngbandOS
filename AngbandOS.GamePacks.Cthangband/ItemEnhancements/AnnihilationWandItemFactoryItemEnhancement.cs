namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AnnihilationWandItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Weight => 10;
    public override int Cost => 3000;
    public override int DamageDice => 1;
    public override int DiceSides => 1;
    public override ColorEnum Color => ColorEnum.Chartreuse;
}
