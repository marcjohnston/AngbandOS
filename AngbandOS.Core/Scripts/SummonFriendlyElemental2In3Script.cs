// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SummonFriendlyElemental2In3Script : Script, ICancellableScriptItem
{
    private SummonFriendlyElemental2In3Script(Game game) : base(game) { }

    public bool ExecuteCancellableScriptItem(Item item) // This is run by an item activation
    {
        if (Game.DieRoll(3) == 1)
        {
            if (Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, (int)(Game.ExperienceLevel.IntValue * 1.5), Game.SingletonRepository.Get<MonsterFilter>(nameof(ElementalMonsterFilter))))
            {
                Game.MsgPrint("An elemental materializes...");
                Game.MsgPrint("You fail to control it!");
            }
        }
        else
        {
            if (Game.SummonSpecificFriendly(Game.MapY.IntValue, Game.MapX.IntValue, (int)(Game.ExperienceLevel.IntValue * 1.5), Game.SingletonRepository.Get<MonsterFilter>(nameof(ElementalMonsterFilter)), Game.ExperienceLevel.IntValue == 50))
            {
                Game.MsgPrint("An elemental materializes...");
                Game.MsgPrint("It seems obedient to you.");
            }
        }
        return true;
    }
}
