// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class Arrow5D6MonsterSpell : ArrowProjectileMonsterSpell
{
    protected override string ActionName => "fires a missile";
    protected override int Damage(Monster monster) => Program.Rng.DiceRoll(5, 6);
}
