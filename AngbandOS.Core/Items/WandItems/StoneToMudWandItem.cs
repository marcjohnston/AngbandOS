namespace AngbandOS.Core.Items
{
[Serializable]
    internal class StoneToMudWandItem : WandItem
    {
        public StoneToMudWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<WandStoneToMud>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(8) + 3;
        }
    }
}