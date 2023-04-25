namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DisarmingWandItem : WandItem
    {
        public DisarmingWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<WandDisarming>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(5) + 4;
        }
    }
}