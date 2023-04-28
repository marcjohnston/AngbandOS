namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LightWandItem : WandItem
    {
        public LightWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<LightWandItemFactory>()) { }
        protected override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(10) + 6;
        }
    }
}