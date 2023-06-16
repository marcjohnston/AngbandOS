// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

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
