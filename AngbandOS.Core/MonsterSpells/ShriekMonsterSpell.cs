// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class ShriekMonsterSpell : MonsterSpell
{
    private ShriekMonsterSpell(SaveGame saveGame) : base(saveGame) { }
    public override bool IsInnate => true;
    public override bool Annoys => true;

    public override string? VsPlayerBlindMessage => "You hear a shriek.";

    public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} makes a high pitched shriek.";
    public override string? VsMonsterSeenMessage(Monster monster, Monster target) => $"{monster.Name} shrieks at {target.Name}.";


    public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
    {
        saveGame.AggravateMonsters(monster);
    }

    public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
    {
        // No additional processing needed.  It only wakes the monster.
    }
}
