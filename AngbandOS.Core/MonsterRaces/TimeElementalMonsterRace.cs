// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class TimeElementalMonsterRace : MonsterRace
{
    protected TimeElementalMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BreatheTimeMonsterSpell),
        nameof(SlowMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperESymbol);
    public override ColorEnum Color => ColorEnum.BrightGreen;
    
    public override int ArmorClass => 70;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(TouchAttack), nameof(LoseAllAttackEffect), 3, 4),
        new MonsterAttackDefinition(nameof(TouchAttack), nameof(Exp40AttackEffect), 3, 4),
        new MonsterAttackDefinition(nameof(TouchAttack), nameof(LoseAllAttackEffect), 3, 4),
        new MonsterAttackDefinition(nameof(TouchAttack), nameof(Exp40AttackEffect), 3, 4)
    };
    public override string Description => "You have not seen it yet.";
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override int FreqInate => 7;
    public override int FreqSpell => 7;
    public override string FriendlyName => "Time elemental";
    public override int Hdice => 35;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool KillItem => true;
    public override int LevelFound => 37;
    public override int Mexp => 1000;
    public override bool Nonliving => true;
    public override int NoticeRange => 90;
    public override bool PassWall => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string? MultilineName => "Time\nelemental";
}
