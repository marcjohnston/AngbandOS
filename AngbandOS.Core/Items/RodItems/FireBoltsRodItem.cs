namespace AngbandOS.Core.Items
{
[Serializable]
    internal class FireBoltsRodItem : RodItem
    {
        public FireBoltsRodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RodFireBolts>()) { }
    }
}