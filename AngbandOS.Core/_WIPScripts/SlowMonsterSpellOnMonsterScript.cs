// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SlowMonsterSpellOnMonsterScript : Script, IScriptMonsterMonster
{
    private SlowMonsterSpellOnMonsterScript(Game game) : base(game) { }
    public void ExecuteScriptMonsterMonster(Monster monster, Monster target)
    {
        int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        bool blind = Game.BlindnessTimer.Value != 0;
        bool seeTarget = !blind && target.IsVisible;
        MonsterRace targetRace = target.Race;
        string targetName = target.Name;

        if (targetRace.Unique)
        {
            if (seeTarget)
            {
                Game.MsgPrint($"{targetName} is unaffected.");
            }
        }
        else if (targetRace.Level > base.Game.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
        {
            if (seeTarget)
            {
                Game.MsgPrint($"{targetName} is unaffected.");
            }
        }
        else
        {
            target.Speed -= 10;
            if (seeTarget)
            {
                Game.MsgPrint($"{targetName} starts moving slower.");
            }
        }
    }
}
