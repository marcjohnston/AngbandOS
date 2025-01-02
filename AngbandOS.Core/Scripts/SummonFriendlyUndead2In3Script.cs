// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SummonFriendlyUndead2In3Script : Script, IActivateItemScript
{
    private SummonFriendlyUndead2In3Script(Game game) : base(game) { }

    public bool ExecuteActivateItemScript(Item item) // This is run by an item activation
    {
        if (Game.DieRoll(3) == 1)
        {
            if (Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, (int)(Game.ExperienceLevel.IntValue * 1.5), Game.ExperienceLevel.IntValue > 47 ? Game.SingletonRepository.Get<MonsterFilter>(nameof(HiUndeadMonsterFilter)) : Game.SingletonRepository.Get<MonsterFilter>(nameof(UndeadMonsterFilter)), true, false))
            {
                Game.MsgPrint("Cold winds begin to Attack around you, carrying with them the stench of decay...");
                Game.MsgPrint("'The dead arise... to punish you for disturbing them!'");
            }
        }
        else
        {
            if (Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, (int)(Game.ExperienceLevel.IntValue * 1.5), Game.ExperienceLevel.IntValue > 47 ? Game.SingletonRepository.Get<MonsterFilter>(nameof(HiUndeadNoUniquesMonsterFilter)) : Game.SingletonRepository.Get<MonsterFilter>(nameof(UndeadMonsterFilter)), Game.ExperienceLevel.IntValue > 24 && Game.DieRoll(3) == 1, true))
            {
                Game.MsgPrint("Cold winds begin to Attack around you, carrying with them the stench of decay...");
                Game.MsgPrint("Ancient, long-dead forms arise from the ground to serve you!");
            }
        }
        return true;
    }
}
