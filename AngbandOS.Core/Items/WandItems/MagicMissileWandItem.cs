namespace AngbandOS.Core.Items
{
[Serializable]
    internal class MagicMissileWandItem : WandItem
    {
        public MagicMissileWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<WandMagicMissile>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(10) + 6;
        }
    }
}