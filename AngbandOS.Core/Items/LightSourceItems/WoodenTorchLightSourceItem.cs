namespace AngbandOS.Core.Items
{
[Serializable]
    internal class WoodenTorchLightSourceItem : LightSourceItem
    {
        public WoodenTorchLightSourceItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<WoodenTorchLightSourceItemFactory>()) { }

        /// <summary>
        /// Returns 1 because wooden torches consume a single turn of light for every world turn.
        /// </summary>
        public override int BurnRate => 1;

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

        public override void ApplyMagic(int level, int power)
        {
            if (TypeSpecificValue != 0)
            {
                TypeSpecificValue = Program.Rng.DieRoll(TypeSpecificValue);
            }
        }
    }
}