namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CultesdesGoulesDeathBookItem : DeathBookItem
    {
        public CultesdesGoulesDeathBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<DeathBookCultesdesGoules>()) { }
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
    }
}