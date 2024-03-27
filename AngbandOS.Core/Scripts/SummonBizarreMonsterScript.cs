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
                summonType = Game.SingletonRepository.MonsterFilters.Get(nameof(Bizarre1MonsterFilter));
                break;

            case 2:
                summonType = Game.SingletonRepository.MonsterFilters.Get(nameof(Bizarre2MonsterFilter));
                break;

            case 3:
                summonType = Game.SingletonRepository.MonsterFilters.Get(nameof(Bizarre4MonsterFilter));
                break;

            case 4:
                summonType = Game.SingletonRepository.MonsterFilters.Get(nameof(Bizarre5MonsterFilter));
                break;
        }
        if (Game.DieRoll(2) == 1)
        {
            Game.MsgPrint(Game.SummonSpecific(Game.MapY.Value, Game.MapX.Value, Game.ExperienceLevel.Value, summonType)
                ? "The summoned creature gets angry!"
                : "No-one ever turns up.");
        }
        else
        {
            if (!Game.SummonSpecificFriendly(Game.MapY.Value, Game.MapX.Value, Game.ExperienceLevel.Value, summonType, false))
            {
                Game.MsgPrint("No-one ever turns up.");
            }
        }
    }
}
