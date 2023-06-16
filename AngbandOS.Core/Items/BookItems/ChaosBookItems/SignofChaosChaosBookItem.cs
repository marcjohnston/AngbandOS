namespace AngbandOS.Core.Items;

[Serializable]
internal class SignOfChaosChaosBookItem : ChaosBookItem
{
    public SignOfChaosChaosBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SignOfChaosChaosBookItemFactory>()) { }
}