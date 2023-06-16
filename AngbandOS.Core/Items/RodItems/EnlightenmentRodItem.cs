namespace AngbandOS.Core.Items;

[Serializable]
internal class EnlightenmentRodItem : RodItem
{
    public EnlightenmentRodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RodEnlightenment>()) { }
}