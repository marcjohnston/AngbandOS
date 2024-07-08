// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GiantWhiteCentipedeMonsterRace : MonsterRace
{
    protected GiantWhiteCentipedeMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerCSymbol);
    
    public override bool Animal => true;
    public override int ArmorClass => 10;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(HurtAttackEffect), 1, 2),
        (nameof(StingAttack), nameof(HurtAttackEffect), 1, 2),
    };
    public override bool BashDoor => true;
    public override string Description => "It is about four feet long and carnivorous.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Giant white centipede";
    public override int Hdice => 3;
    public override int Hside => 5;
    public override int LevelFound => 1;
    public override int Mexp => 2;
    public override int NoticeRange => 7;
    public override bool RandomMove50 => true;
    public override int Rarity => 1;
    public override int Sleep => 40;
    public override int Speed => 110;
    public override string? MultilineName => "Giant\nwhite\ncentipede";
    public override bool WeirdMind => true;
}
