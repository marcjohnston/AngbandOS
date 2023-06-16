// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class BlinkMonsterSpell : MonsterSpell
{
    public override bool IsIntelligent => true;
    public override bool ProvidesEscape => true;

    public override string? VsPlayerBlindMessage => $"You hear someone blink away.";
    public override string? VsPlayerActionMessage(Monster monster) => monster.IsVisible ? $"{monster.Name} blinks away." : null;

    public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
    {
        monster.TeleportAway(saveGame, 10);
    }

    public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
    {
        monster.TeleportAway(saveGame, 10);
    }
}
