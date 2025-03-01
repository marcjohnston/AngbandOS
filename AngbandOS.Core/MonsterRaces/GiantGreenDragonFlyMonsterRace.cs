// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GiantGreenDragonFlyMonsterRace : MonsterRace
{
    protected GiantGreenDragonFlyMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(PoisonBreatheBallMonsterSpell)
    };


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    protected override string SymbolName => nameof(UpperFSymbol);
    public override ColorEnum Color => ColorEnum.BrightGreen;
    
    public override bool Animal => true;
    public override int ArmorClass => 20;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(PoisonAttackEffect), 1, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "A vast, foul-smelling dragonfly.";
    public override bool ForceSleep => true;
    public override int FreqInate => 10;
    public override int FreqSpell => 10;
    public override string FriendlyName => "Giant green dragon fly";
    public override int Hdice => 3;
    public override int Hside => 8;
    public override bool ImmunePoison => true;
    public override int LevelFound => 16;
    public override int Mexp => 70;
    public override int NoticeRange => 12;
    public override bool RandomMove25 => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 2;
    public override int Sleep => 50;
    public override int Speed => 110;
    public override string? MultilineName => "Giant green\ndragon\nfly";
    public override bool WeirdMind => true;
}
