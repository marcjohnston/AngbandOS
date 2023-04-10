namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DrainLifeWandItem : WandItem
    {
        public DrainLifeWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandDrainLife>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(3) + 3;
        }
    }
}