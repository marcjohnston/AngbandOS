// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class PhantasmalServantScript : Script, IScript
{
    private PhantasmalServantScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        bool success = Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.ExperienceLevel.IntValue * 3 / 2, Game.SingletonRepository.Get<MonsterFilter>(nameof(PhantomMonsterFilter)), false, true);
        string msg = success ? "'Your wish, master?'" : "No-one ever turns up.";
        Game.MsgPrint(msg);
    }
}
