// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class CauseLightWoundsMonsterSpell : CauseWoundsMonsterSpell
{
    private CauseLightWoundsMonsterSpell(SaveGame saveGame) : base(saveGame) { }
    protected override int CurseEquipmentChance => 33;
    protected override int HeavyCurseEquipmentChance => 0;
    protected override int Damage => Program.Rng.DiceRoll(3, 8);
    public override string? VsMonsterSeenMessage(Monster monster, Monster target) => $"{monster.Name} points at {target.Name} and curses horribly.";
}
