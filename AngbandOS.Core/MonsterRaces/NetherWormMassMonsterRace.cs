// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class NetherWormMassMonsterRace : MonsterRace
{
    protected NetherWormMassMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerWSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    
    public override bool Animal => true;
    public override int ArmorClass => 15;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(TouchAttack), nameof(Exp10AttackEffect), 0, 0),
    };
    public override bool BashDoor => true;
    public override string Description => "It is a disgusting mass of dark worms, eating each other, the floor, the air, you....";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Nether worm mass";
    public override int Hdice => 5;
    public override int Hside => 8;
    public override bool HurtByLight => true;
    public override bool ImmuneFear => true;
    public override int LevelFound => 12;
    public override int Mexp => 6;
    public override bool Multiply => true;
    public override int NoticeRange => 10;
    public override bool RandomMove25 => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 4;
    public override int Sleep => 3;
    public override int Speed => 100;
    public override string? MultilineName => "Nether\nworm\nmass";
    public override bool Stupid => true;
    public override bool WeirdMind => true;
}
