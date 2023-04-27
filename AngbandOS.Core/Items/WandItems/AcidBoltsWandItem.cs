namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AcidBoltsWandItem : WandItem
    {
        public AcidBoltsWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<AcidBoltsWandItemFactory>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(8) + 6;
        }
    }
}