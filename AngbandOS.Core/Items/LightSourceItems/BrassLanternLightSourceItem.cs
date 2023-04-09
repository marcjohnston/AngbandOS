namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BrassLanternLightSourceItem : LightSourceItem
    {
        public BrassLanternLightSourceItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<LightBrassLantern>()) { }

        /// <summary>
        /// Returns an intensity of light provided by the lantern.  2, if the lantern has turns remaining, plus an additional 3
        /// if the lantern is an artifact.
        /// </summary>
        /// <param name="oPtr"></param>
        /// <returns></returns>
        public override int CalcTorch()
        {
            return base.CalcTorch() + TypeSpecificValue > 0 ? 2 : 0;
        }
    }
}