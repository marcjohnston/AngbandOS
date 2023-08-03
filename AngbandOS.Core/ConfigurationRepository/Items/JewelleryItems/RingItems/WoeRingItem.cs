// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal class WoeRingItem : RingItem
{
    public WoeRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<WoeRingItemFactory>()) { }
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        IdentBroken = true;
        IdentCursed = true;
        BonusArmorClass = 0 - (5 + GetBonusValue(10, level));
        TypeSpecificValue = 0 - (1 + GetBonusValue(5, level));
    }
}