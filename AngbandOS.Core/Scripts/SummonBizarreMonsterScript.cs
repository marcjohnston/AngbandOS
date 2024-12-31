// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SummonBizarreMonsterScript : Script, IScript
{
    private SummonBizarreMonsterScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        MonsterFilter? summonType = null;
        Game.MsgPrint("You concentrate on the Fool card...");
        switch (Game.DieRoll(4))
        {
            case 1:
                summonType = Game.SingletonRepository.Get<MonsterFilter>(nameof(Bizarre1MonsterFilter));
                break;

            case 2:
                summonType = Game.SingletonRepository.Get<MonsterFilter>(nameof(Bizarre2MonsterFilter));
                break;

            case 3:
                summonType = Game.SingletonRepository.Get<MonsterFilter>(nameof(Bizarre4MonsterFilter));
                break;

            case 4:
                summonType = Game.SingletonRepository.Get<MonsterFilter>(nameof(Bizarre5MonsterFilter));
                break;
        }
        if (Game.DieRoll(2) == 1)
        {
            Game.MsgPrint(Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.ExperienceLevel.IntValue, summonType, true, false)
                ? "The summoned creature gets angry!"
                : "No-one ever turns up.");
        }
        else
        {
            if (!Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.ExperienceLevel.IntValue, summonType, false, true))
            {
                Game.MsgPrint("No-one ever turns up.");
            }
        }
    }
}
