namespace AngbandOS.Core.Items;

[Serializable]
internal class OilFlaskItem : FlaskItem
{
    public OilFlaskItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<OilFlaskItemFactory>()) { }
}