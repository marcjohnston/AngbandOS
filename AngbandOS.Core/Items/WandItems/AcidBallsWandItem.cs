namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AcidBallsWandItem : WandItem
    {
        public AcidBallsWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandAcidBalls>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(5) + 2;
        }
    }
}