namespace AngbandOS.Core.Items
{
[Serializable]
    internal class WonderWandItem : WandItem
    {
        public WonderWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<WandWonder>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(15) + 8;
        }
    }
}