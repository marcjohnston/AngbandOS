// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class TeleportSelfMonsterSpell : MonsterSpell
{
    public override bool IsIntelligent => true;
    public override bool ProvidesEscape => true;

    /// <summary>
    /// Returns null, because a blind player cannot see or hear this action.
    /// </summary>
    public override string? VsPlayerBlindMessage => null;

    /// <summary>
    /// Returns a message indicating that the player noticed the monster teleported away.
    /// </summary>
    /// <param name="monster"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} teleports away.";

    public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
    {
        monster.TeleportAway(saveGame, (Constants.MaxSight * 2) + 5);
    }

    public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
    {
        monster.TeleportAway(saveGame, (Constants.MaxSight * 2) + 5);
    }
}
