// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.Items;

[Serializable]
internal class ElvenCloakArmorItem : CloakArmorItem
{
    public ElvenCloakArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ElvenCloakArmorItemFactory>()) { }

    protected override void ApplyMagic(int level, int power, Store? store)
    {
        if (power != 0)
        {
            // Apply the standard armour characteristics.
            base.ApplyMagic(level, power, null);

            TypeSpecificValue = SaveGame.Rng.DieRoll(4);
            if (power > 1)
            {
                if (SaveGame.Rng.DieRoll(20) == 1)
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