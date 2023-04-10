namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LightWandItem : WandItem
    {
        public LightWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandLight>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(10) + 6;
        }
    }
}