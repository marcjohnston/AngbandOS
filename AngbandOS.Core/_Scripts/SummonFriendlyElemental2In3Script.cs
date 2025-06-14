﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SummonFriendlyElemental2In3Script : Script, IActivateItemScript
{
    private SummonFriendlyElemental2In3Script(Game game) : base(game) { }

    public UsedResult ExecuteActivateItemScript(Item item) // This is run by an item activation
    {
        if (Game.DieRoll(3) == 1)
        {
            if (Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, (int)(Game.ExperienceLevel.IntValue * 1.5), Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(ElementalMonsterRaceFilter)), true, false))
            {
                Game.MsgPrint("An elemental materializes...");
                Game.MsgPrint("You fail to control it!");
            }
        }
        else
        {
            if (Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, (int)(Game.ExperienceLevel.IntValue * 1.5), Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(ElementalMonsterRaceFilter)), Game.ExperienceLevel.IntValue == 50, true))
            {
                Game.MsgPrint("An elemental materializes...");
                Game.MsgPrint("It seems obedient to you.");
            }
        }
        return new UsedResult(true);
    }
}
