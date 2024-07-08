// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MastiffMonsterRace : MonsterRace
{
    protected MastiffMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(UpperCSymbol);
    public override ColorEnum Color => ColorEnum.Beige;
    
    public override bool Animal => true;
    public override int ArmorClass => 20;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(HurtAttackEffect), 1, 5),
        (nameof(BiteAttack), nameof(HurtAttackEffect), 1, 5),
    };
    public override string Description => "Well-trained watchdogs, obedient to death.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Mastiff";
    public override bool Friends => true;
    public override int Hdice => 8;
    public override int Hside => 9;
    public override bool ImmuneFear => true;
    public override int LevelFound => 14;
    public override int Mexp => 40;
    public override int NoticeRange => 8;
    public override int Rarity => 2;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string? MultilineName => "Mastiff";
}
