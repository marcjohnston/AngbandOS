// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.Items;

[Serializable]
internal class DragonHelmArmorItem : HelmArmorItem
{
    public DragonHelmArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<HelmDragonHelm>()) { }

    /// <summary>
    /// Applies special magic to this dragon helm.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="level"></param>
    /// <param name="power"></param>
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        // Apply the standard armour characteristics, regardless of the power.
        base.ApplyMagic(level, power, null);

        SaveGame.TreasureRating += 5;
        ApplyDragonscaleResistance();
    }
}