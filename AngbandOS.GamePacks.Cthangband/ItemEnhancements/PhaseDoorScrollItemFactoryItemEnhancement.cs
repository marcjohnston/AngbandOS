namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PhaseDoorScrollItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 5;
    public override int Cost => 15;
    public override ColorEnum Color => ColorEnum.BrightBeige;
}
