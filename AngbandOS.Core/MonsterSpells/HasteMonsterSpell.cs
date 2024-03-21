// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class HasteMonsterSpell : MonsterSpell
{
    private HasteMonsterSpell(Game game) : base(game) { }
    public override bool IsIntelligent => true;
    public override bool Hastens => true;

    public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} concentrates on {monster.PossessiveName} body.";

    public override void ExecuteOnPlayer(Game game, Monster monster)
    {
        string monsterName = monster.Name;

        if (monster.Speed < monster.Race.Speed + 10)
        {
            game.MsgPrint($"{monsterName} starts moving faster.");
            monster.Speed += 10;
        }
        else if (monster.Speed < monster.Race.Speed + 20)
        {
            game.MsgPrint($"{monsterName} starts moving faster.");
            monster.Speed += 2;
        }
    }

    public override void ExecuteOnMonster(Game game, Monster monster, Monster target)
    {
        bool blind = game.BlindnessTimer.Value != 0;
        bool seen = !blind && monster.IsVisible;
        MonsterRace targetRace = target.Race;

        if (monster.Speed < monster.Race.Speed + 10)
        {
            if (seen)
            {
                game.MsgPrint($"{monster.Name} starts moving faster.");
            }
            monster.Speed += 10;
        }
        else if (monster.Speed < monster.Race.Speed + 20)
        {
            if (seen)
            {
                game.MsgPrint($"{monster.Name} starts moving faster.");
            }
            monster.Speed += 2;
        }
    }
}
