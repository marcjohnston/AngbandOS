namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DexterityRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool HideType => true;
    public override int Weight => 2;
    public override int Value => 500;
    public override ColorEnum Color => ColorEnum.Gold;
}
