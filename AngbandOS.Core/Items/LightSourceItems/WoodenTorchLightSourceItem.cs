namespace AngbandOS.Core.Items
{
[Serializable]
    internal class WoodenTorchLightSourceItem : LightSourceItem
    {
        public WoodenTorchLightSourceItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<LightWoodenTorch>()) { }

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
    }
}