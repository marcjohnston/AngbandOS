// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class BlackHarpyMonsterRace : MonsterRace
{
    protected BlackHarpyMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(UpperHSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    
    public override bool Animal => true;
    public override int ArmorClass => 22;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(HurtAttackEffect), 1, 2),
        (nameof(ClawAttack), nameof(HurtAttackEffect), 1, 2),
        (nameof(BiteAttack), nameof(HurtAttackEffect), 1, 3),
    };
    public override string Description => "A woman's face on the body of a vicious black bird.";
    public override bool Evil => true;
    public override bool Female => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Black harpy";
    public override int Hdice => 3;
    public override int Hside => 8;
    public override int LevelFound => 9;
    public override int Mexp => 19;
    public override int NoticeRange => 16;
    public override bool RandomMove25 => true;
    public override int Rarity => 1;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string? MultilineName => "Black\nharpy";
}
