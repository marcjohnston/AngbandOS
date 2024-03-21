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
    private HasteMonsterSpell(SaveGame saveGame) : base(saveGame) { }
    public override bool IsIntelligent => true;
    public override bool Hastens => true;

    public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} concentrates on {monster.PossessiveName} body.";

    public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
    {
        string monsterName = monster.Name;

        if (monster.Speed < monster.Race.Speed + 10)
        {
            saveGame.MsgPrint($"{monsterName} starts moving faster.");
            monster.Speed += 10;
        }
        else if (monster.Speed < monster.Race.Speed + 20)
        {
            saveGame.MsgPrint($"{monsterName} starts moving faster.");
            monster.Speed += 2;
        }
    }

    public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
    {
        bool blind = saveGame.BlindnessTimer.Value != 0;
        bool seen = !blind && monster.IsVisible;
        MonsterRace targetRace = target.Race;

        if (monster.Speed < monster.Race.Speed + 10)
        {
            if (seen)
            {
                saveGame.MsgPrint($"{monster.Name} starts moving faster.");
            }
            monster.Speed += 10;
        }
        else if (monster.Speed < monster.Race.Speed + 20)
        {
            if (seen)
            {
                saveGame.MsgPrint($"{monster.Name} starts moving faster.");
            }
            monster.Speed += 2;
        }
    }
}
