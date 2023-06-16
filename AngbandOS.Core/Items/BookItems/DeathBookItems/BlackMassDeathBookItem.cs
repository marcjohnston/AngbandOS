namespace AngbandOS.Core.Items;

[Serializable]
internal class BlackMassDeathBookItem : DeathBookItem
{
    public BlackMassDeathBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<BlackMassDeathBookItemFactory>()) { }
}