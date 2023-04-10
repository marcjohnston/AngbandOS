namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CultesdesGoulesDeathBookItem : DeathBookItem
    {
        public CultesdesGoulesDeathBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DeathBookCultesdesGoules>()) { }
    }
}