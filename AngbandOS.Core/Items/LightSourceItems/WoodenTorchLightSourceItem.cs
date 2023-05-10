namespace AngbandOS.Core.Items
{
[Serializable]
    internal class WoodenTorchLightSourceItem : LightSourceItem
    {
        public WoodenTorchLightSourceItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<WoodenTorchLightSourceItemFactory>()) { }

        /// <summary>
        /// Returns true because a torch can be used as fuel for another torch.
        /// </summary>
        public override bool IsFuelForTorch => true;

        /// <summary>
        /// Returns an intensity of light provided by the torch.  1, if the torch has turns remaining, plus an optional 3
        /// if the torch is an artifact.
        /// </summary>
        /// <param name="oPtr"></param>
        /// <returns></returns>
        public override int CalcTorch()
        {
            return base.CalcTorch() + TypeSpecificValue > 0 ? 1 : 0;
        }

        protected override void ApplyMagic(int level, int power, Store? store)
        {
            if (store != null)
            {
                TypeSpecificValue = Constants.FuelTorch / 2;
            }
            else if (TypeSpecificValue != 0)
            {
                TypeSpecificValue = Program.Rng.DieRoll(TypeSpecificValue);
            }
        }
    }
}