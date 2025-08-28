namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IgnoreFireItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? IgnoreFire => true;
    public override bool? EasyKnow => true;
    public override int? Value => 100;
}
