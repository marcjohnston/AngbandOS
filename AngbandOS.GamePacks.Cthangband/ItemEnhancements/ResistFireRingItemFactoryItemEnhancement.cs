namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ResistFireRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override bool IgnoreFire => true;
    public override bool ResFire => true;
    public override int Weight => 2;
    public override int Cost => 250;
    public override ColorEnum Color => ColorEnum.Gold;
}
