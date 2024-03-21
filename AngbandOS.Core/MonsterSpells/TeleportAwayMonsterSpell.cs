// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class TeleportAwayMonsterSpell : MonsterSpell
{
    private TeleportAwayMonsterSpell(Game game) : base(game) { }
    public override bool IsIntelligent => true;

    public override bool ProvidesEscape => true;

    public override string? VsPlayerBlindMessage => $"Someone teleports you away.";
    public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} teleports you away.";
    public override string? VsMonsterSeenMessage(Monster monster, Monster target) => $"{monster.Name} teleports {target.Name} away.";
    public override string? VsMonsterUnseenMessage => null;

    public override void ExecuteOnPlayer(Game game, Monster monster)
    {
        Game.RunScriptInt(nameof(TeleportSelfScript), 100);
    }

    public override void ExecuteOnMonster(Game game, Monster monster, Monster target)
    {
        bool resistsTele = false;
        string targetName = target.Name;
        bool blind = game.BlindnessTimer.Value != 0;
        bool seeTarget = !blind && target.IsVisible;
        MonsterRace targetRace = target.Race;

        if (targetRace.ResistTeleport)
        {
            if (targetRace.Unique)
            {
                if (seeTarget)
                {
                    targetRace.Knowledge.Characteristics.ResistTeleport = true;
                    game.MsgPrint($"{targetName} is unaffected!");
                }
                resistsTele = true;
            }
            else if (targetRace.Level > Game.DieRoll(100))
            {
                if (seeTarget)
                {
                    targetRace.Knowledge.Characteristics.ResistTeleport = true;
                    game.MsgPrint($"{targetName} resists!");
                }
                resistsTele = true;
            }
        }
        if (!resistsTele)
        {
            target.TeleportAway(game, (Constants.MaxSight * 2) + 5);
        }
    }
}
