namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ProtectionFromEvilScrollItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 5;
    public override int Cost => 250;
    public override ColorEnum Color => ColorEnum.BrightBeige;
}
