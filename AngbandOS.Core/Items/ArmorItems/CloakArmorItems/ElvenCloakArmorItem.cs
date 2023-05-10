namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ElvenCloakArmorItem : CloakArmorItem
    {
        public ElvenCloakArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<CloakElven>()) { }

        protected override void ApplyMagic(int level, int power, Store? store)
        {
            if (power != 0)
            {
                // Apply the standard armour characteristics.
                base.ApplyMagic(level, power, null);

                TypeSpecificValue = Program.Rng.DieRoll(4);
                if (power > 1)
                {
                    if (Program.Rng.DieRoll(20) == 1)
                    {
                        CreateRandart(false);
                    }
                    else
                    {
                        ApplyRandomGoodRareCharacteristics();
                    }
                }
                else if (power < -1)
                {
                    ApplyRandomPoorRareCharacteristics();
                }
            }
        }
    }
}