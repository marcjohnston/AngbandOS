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
    private BlinkMonsterSpell(Game game) : base(game) { }
    public override bool IsIntelligent => true;
    public override bool ProvidesEscape => true;

    public override string? VsPlayerBlindMessage => $"You hear someone blink away.";
    public override string? VsPlayerActionMessage(Monster monster) => monster.IsVisible ? $"{monster.Name} blinks away." : null;

    public override void ExecuteOnPlayer(Monster monster)
    {
        monster.TeleportAway(10);
    }

    public override void ExecuteOnMonster(Monster monster, Monster target)
    {
        monster.TeleportAway(10);
    }
}
