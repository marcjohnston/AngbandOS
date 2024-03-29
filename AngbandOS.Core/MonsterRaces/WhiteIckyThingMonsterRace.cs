// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class WhiteIckyThingMonsterRace : MonsterRace
{
    protected WhiteIckyThingMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerISymbol);
    
    public override int ArmorClass => 7;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(TouchAttack), nameof(HurtAttackEffect), 1, 2),
    };
    public override string Description => "It is a smallish, slimy, icky creature.";
    public override bool EmptyMind => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "White icky thing";
    public override int Hdice => 3;
    public override int Hside => 5;
    public override int LevelFound => 1;
    public override int Mexp => 2;
    public override int NoticeRange => 12;
    public override bool RandomMove25 => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 1;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string? MultilineName => "White\nicky\nthing";
}
