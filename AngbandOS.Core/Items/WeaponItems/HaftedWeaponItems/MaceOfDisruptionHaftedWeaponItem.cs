namespace AngbandOS.Core.Items
{
[Serializable]
    internal class MaceOfDisruptionHaftedWeaponItem : HaftedWeaponItem
    {
        public MaceOfDisruptionHaftedWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<HaftedMaceOfDisruption>()) { }
    }
}