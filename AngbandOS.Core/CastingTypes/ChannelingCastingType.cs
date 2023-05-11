namespace AngbandOS.Core.CastingTypes
{
    [Serializable]
    internal class ChannelingCastingType : CastingType
    {
        private ChannelingCastingType(SaveGame saveGame) : base(saveGame) { }

        /// <summary>
        /// Returns true, because channeling casting allows the player to use mana instead of consuming the item.
        /// </summary>
        public override bool CanUseManaInsteadOfConsumingItem => true;
    }
}