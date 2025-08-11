namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PintOfFineWineFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 10;
    public override int Cost => 2;
    public override ColorEnum Color => ColorEnum.Red;
}
