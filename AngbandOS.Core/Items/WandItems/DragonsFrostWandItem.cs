namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DragonsFrostWandItem : WandItem
    {
        public DragonsFrostWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<DragonsFrostWandItemFactory>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
        }
    }
}