namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RobeSoftArmorItem : SoftArmorItem
    {
        public RobeSoftArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SoftArmorRobe>()) { }

        /// <summary>
        /// Applies special magic to this robe.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="level"></param>
        /// <param name="power"></param>
        public override void ApplyMagic(int level, int power)
        {
            if (power != 0)
            {
                // Apply the standard armour characteristics.
                base.ApplyMagic(level, power);

                if (power > 1)
                {
                    // Robes have a chance of having the armour of permanence instead of a random characteristic.
                    if (Program.Rng.RandomLessThan(100) < 10)
                    {
                        RareItemTypeIndex = RareItemTypeEnum.ArmourOfPermanence;
                    }
                    else
                    {
                        ApplyRandomGoodRareCharacteristics();
                    }
                }
            }
        }
    }
}