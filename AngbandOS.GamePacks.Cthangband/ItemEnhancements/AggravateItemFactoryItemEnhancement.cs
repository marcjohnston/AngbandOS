namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AggravateItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool Aggravate => true;
    public override bool IsCursed => true;
    public override bool EasyKnow => true;
}