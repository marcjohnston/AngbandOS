// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Threading;

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class AntSummonMonsterSpell : SummonMonsterSpell
{
    private AntSummonMonsterSpell(Game game) : base(game) { }
    protected override MonsterFilter? MonsterSelector(Monster monster) => Game.SingletonRepository.Get<MonsterFilter>(nameof(AntMonsterFilter));
    public override string? VsPlayerActionMessage => "{0} magically summons ants!";
}
