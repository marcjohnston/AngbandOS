namespace AngbandOS.Core.Items
{
[Serializable]
    internal class StarEssenceElendilLightSourceItem : LightSourceItem
    {
        public StarEssenceElendilLightSourceItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<StarEssenceElendilLightSourceItemFactory>()) { }
    }
}