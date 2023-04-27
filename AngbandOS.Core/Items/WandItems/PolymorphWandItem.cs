namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PolymorphWandItem : WandItem
    {
        public PolymorphWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<PolymorphWandItemFactory>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(8) + 6;
        }
    }
}