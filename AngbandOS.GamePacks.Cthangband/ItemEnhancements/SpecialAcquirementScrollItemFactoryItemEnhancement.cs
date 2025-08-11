namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpecialAcquirementScrollItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 5;
    public override int Cost => 200000;
    public override ColorEnum Color => ColorEnum.BrightBeige;
}
