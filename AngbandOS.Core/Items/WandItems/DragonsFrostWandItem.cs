namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DragonsFrostWandItem : WandItem
    {
        public DragonsFrostWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandDragonsFrost>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
        }
    }
}