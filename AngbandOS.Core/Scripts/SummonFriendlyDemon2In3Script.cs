// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SummonFriendlyDemon2In3Script : Script, IActivateItemScript
{
    private SummonFriendlyDemon2In3Script(Game game) : base(game) { }

    public bool ExecuteActivateItemScript(Item item) // This is run by an item activation
    {
        if (Game.DieRoll(3) == 1)
        {
            if (Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, (int)(Game.ExperienceLevel.IntValue * 1.5), Game.SingletonRepository.Get<MonsterFilter>(nameof(DemonMonsterFilter)), true, false))
            {
                Game.MsgPrint("The area fills with a stench of sulphur and brimstone.");
                Game.MsgPrint("'NON SERVIAM! Wretch! I shall feast on thy mortal soul!'");
            }
        }
        else
        {
            if (Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, (int)(Game.ExperienceLevel.IntValue * 1.5), Game.SingletonRepository.Get<MonsterFilter>(nameof(DemonMonsterFilter)), Game.ExperienceLevel.IntValue == 50, true))
            {
                Game.MsgPrint("The area fills with a stench of sulphur and brimstone.");
                Game.MsgPrint("'What is thy bidding... Master?'");
            }
        }
        return true;
    }
}
