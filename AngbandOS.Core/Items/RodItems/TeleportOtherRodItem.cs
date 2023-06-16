namespace AngbandOS.Core.Items;

[Serializable]
internal class TeleportOtherRodItem : RodItem
{
    public TeleportOtherRodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RodTeleportOther>()) { }
}