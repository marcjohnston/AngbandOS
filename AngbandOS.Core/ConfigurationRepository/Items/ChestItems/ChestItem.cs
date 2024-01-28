// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal abstract class ChestItem : Item
{
    public ChestItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }

    public override string GetDetailedDescription()
    {
        string s = string.Empty;
        if (!IsKnown())
        {
        }
        else if (TypeSpecificValue == 0)
        {
            s += " (empty)";
        }
        else if (TypeSpecificValue < 0)
        {
            if (SaveGame.SingletonRepository.ChestTrapConfigurations[-TypeSpecificValue].IsTrapped)
            {
                s += " (disarmed)";
            }
            else
            {
                s += " (unlocked)";
            }
        }
        else
        {
            s += $" {SaveGame.SingletonRepository.ChestTrapConfigurations[TypeSpecificValue].Description}";
        }

        // Chests do not have Mods, Damage or Bonus.  We are omitting the description for those features.
        return s;
    }

    public override bool IsStompable()
    {
        if (!IsKnown())
        {
            return false;
        }
        else if (TypeSpecificValue == 0)
        {
            return Factory.Stompable[StompableType.Broken];
        }
        else if (TypeSpecificValue < 0)
        {
            return Factory.Stompable[StompableType.Average];
        }
        else
        {
            if (SaveGame.SingletonRepository.ChestTrapConfigurations[TypeSpecificValue].Traps.Length == 0)
            {
                return Factory.Stompable[StompableType.Good];
            }
            else
            {
                return Factory.Stompable[StompableType.Excellent];
            }
        }
    }
}