namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    /// <summary>
    /// Represents weapon items.  Arrow, bolt, bow, digging, hafted, polearm, shot and swords are all weapon classes.
    /// </summary>
    internal abstract class WeaponItemClass : ItemFactory
    {
        public WeaponItemClass(SaveGame saveGame) : base(saveGame) { }
        public override bool HasQuality => true;


        /// <summary>
        /// Returns true, for all weapons where both the hit (ToH) and damage (ToD) are equal to or greater than zero.  False, for all weapons with either stat less than 0.
        /// </summary>
        public override bool KindIsGood
        {
            get
            {
                if (ToH < 0)
                {
                    return false;
                }
                if (ToD < 0)
                {
                    return false;
                }
                return true;
            }
        }


        public override bool CanApplySlayingBonus => true;

        public override bool CanApplyTunnelBonus => true;

        public override bool IsWorthless(Item item)
        {
            if (item.TypeSpecificValue < 0)
            {
                return true;
            }
            if (item.BonusToHit + item.BonusDamage < 0)
            {
                return true;
            }
            return false;
        }
    }
}
