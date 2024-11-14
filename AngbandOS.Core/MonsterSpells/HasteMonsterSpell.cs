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

    public override string? VsPlayerActionMessage => "{0} concentrates on {1} body.";

    public override void ExecuteOnPlayer(Monster monster)
    {
        string monsterName = monster.Name;

        if (monster.Speed < monster.Race.Speed + 10)
        {
            Game.MsgPrint($"{monsterName} starts moving faster.");
            monster.Speed += 10;
        }
        else if (monster.Speed < monster.Race.Speed + 20)
        {
            Game.MsgPrint($"{monsterName} starts moving faster.");
            monster.Speed += 2;
        }
    }

    public override void ExecuteOnMonster(Monster monster, Monster target)
    {
        bool blind = Game.BlindnessTimer.Value != 0;
        bool seen = !blind && monster.IsVisible;
        MonsterRace targetRace = target.Race;

        if (monster.Speed < monster.Race.Speed + 10)
        {
            if (seen)
            {
                Game.MsgPrint($"{monster.Name} starts moving faster.");
            }
            monster.Speed += 10;
        }
        else if (monster.Speed < monster.Race.Speed + 20)
        {
            if (seen)
            {
                Game.MsgPrint($"{monster.Name} starts moving faster.");
            }
            monster.Speed += 2;
        }
    }
}
