// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GiantWhiteAntMonsterRace : MonsterRace
{
    protected GiantWhiteAntMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerASymbol);
    
    public override bool Animal => true;
    public override int ArmorClass => 16;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(HurtAttackEffect), 1, 4),
    };
    public override bool BashDoor => true;
    public override string Description => "It is about two feet long and has sharp pincers.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Giant white ant";
    public override int Hdice => 3;
    public override int Hside => 6;
    public override int LevelFound => 3;
    public override int Mexp => 7;
    public override int NoticeRange => 8;
    public override int Rarity => 1;
    public override int Sleep => 80;
    public override int Speed => 110;
    public override string? MultilineName => "Giant\nwhite\nant";
    public override bool WeirdMind => true;
}
