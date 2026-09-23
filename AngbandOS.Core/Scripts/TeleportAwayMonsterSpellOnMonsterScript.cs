// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

internal class TeleportAwayMonsterSpellOnMonsterScript : Script, IScriptMonsterMonster
{
    private TeleportAwayMonsterSpellOnMonsterScript(Game game) : base(game) { }
    public void ExecuteScriptMonsterMonster(Monster monster, Monster target)
    {
        bool resistsTele = false;
        string targetName = target.Name;
        bool blind = Game.BlindnessTimer.Value != 0;
        bool seeTarget = !blind && target.IsVisible;
        MonsterRace targetRace = target.Race;

        if (targetRace.ResistTeleport)
        {
            if (targetRace.Unique)
            {
                if (seeTarget)
                {
                    targetRace.Knowledge.Characteristics.ResistTeleport = true;
                    Game.MsgPrint($"{targetName} is unaffected!");
                }
                resistsTele = true;
            }
            else if (targetRace.Level > base.Game.DieRoll(100))
            {
                if (seeTarget)
                {
                    targetRace.Knowledge.Characteristics.ResistTeleport = true;
                    Game.MsgPrint($"{targetName} resists!");
                }
                resistsTele = true;
            }
        }
        if (!resistsTele)
        {
            target.TeleportAway((Constants.MaxSight * 2) + 5);
        }
    }
}
