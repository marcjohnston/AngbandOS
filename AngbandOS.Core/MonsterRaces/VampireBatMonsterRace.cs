// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class VampireBatMonsterRace : MonsterRace
{
    protected VampireBatMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerBSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    
    public override bool Animal => true;
    public override int ArmorClass => 40;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(Exp40AttackEffect), 1, 4),
        (nameof(BiteAttack), nameof(Exp40AttackEffect), 1, 4),
    };
    public override bool ColdBlood => true;
    public override string Description => "An undead bat that flies at your neck hungrily.";
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Vampire bat";
    public override int Hdice => 9;
    public override int Hside => 10;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 24;
    public override int Mexp => 150;
    public override int NoticeRange => 12;
    public override bool RandomMove50 => true;
    public override int Rarity => 2;
    public override bool Regenerate => true;
    public override int Sleep => 50;
    public override int Speed => 120;
    public override string? MultilineName => "Vampire\nbat";
    public override bool Undead => true;
}
