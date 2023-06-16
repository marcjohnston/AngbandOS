namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class TeleportToMonsterSpell : MonsterSpell
{
    public override bool Annoys => true;

    public override string? VsPlayerBlindMessage => $"Someone commands you to return.";
    public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} commands you to return.";

    public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
    {
        saveGame.TeleportPlayerTo(monster.MapY, monster.MapX);
    }

    public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
    {
    }
}
