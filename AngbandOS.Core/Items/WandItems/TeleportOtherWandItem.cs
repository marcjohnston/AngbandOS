namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TeleportOtherWandItem : WandItem
    {
        public TeleportOtherWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandTeleportOther>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
        }
    }
}