namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LordlyProtectionRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 5;
    public override bool FreeAct => true;
    public override bool HoldLife => true;
    public override bool ResDisen => true;
    public override bool ResPois => true;
    public override int Weight => 2;
}