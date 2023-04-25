namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BoltBoltAmmunitionItem : BoltAmmunitionItem
    {
        public BoltBoltAmmunitionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<BoltBoltAmmunitionItemFactory>()) { }
    }
}