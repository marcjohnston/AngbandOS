namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CutlassSwordWeaponItem : SwordWeaponItem
    {
        public CutlassSwordWeaponItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SwordCutlass>()) { }
    }
}