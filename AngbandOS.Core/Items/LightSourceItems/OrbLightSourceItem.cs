namespace AngbandOS.Core.Items
{
[Serializable]
    internal class OrbLightSourceItem : LightSourceItem
    {
        public OrbLightSourceItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<OrbLightSourceItemFactory>()) { }
        /// <summary>
        /// Returns an intensity of light provided by the orb.  A value of 2 is returned, plus an additional 3
        /// if the orb is an artifact.
        /// </summary>
        /// <param name="oPtr"></param>
        /// <returns></returns>
        public override int CalcTorch()
        {
            return base.CalcTorch() + 2;
        }
        public override bool IdentityCanBeSensed => true;
    }
}