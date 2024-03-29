// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class SlimeMoldMonsterRace : MonsterRace
{
    protected SlimeMoldMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(CommaSymbol);
    public override ColorEnum Color => ColorEnum.Green;
    
    public override int ArmorClass => 4;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(CrawlAttack), nameof(PoisonAttackEffect), 1, 4),
        new MonsterAttackDefinition(nameof(CrawlAttack), nameof(EatFoodAttackEffect), 0, 0),
        new MonsterAttackDefinition(nameof(DroolAttack), null, 0, 0),
        new MonsterAttackDefinition(nameof(DroolAttack), null, 0, 0)
    };
    public override string Description => "It is a smallish, slimy, icky, hungry creature.";
    public override bool Drop90 => true;
    public override bool EmptyMind => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Slime mold";
    public override int Hdice => 5;
    public override int Hside => 6;
    public override bool ImmunePoison => true;
    public override bool KillBody => true;
    public override int LevelFound => 2;
    public override int Mexp => 8;
    public override int NoticeRange => 14;
    public override bool RandomMove50 => true;
    public override int Rarity => 1;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string? MultilineName => "Slime\nmold";
    public override bool TakeItem => true;
}
