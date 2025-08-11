namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FreeActionRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override bool FreeAct => true;
    public override int Weight => 2;
    public override int Cost => 1500;
    public override ColorEnum Color => ColorEnum.Gold;
}
