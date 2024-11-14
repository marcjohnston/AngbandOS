// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GiantGoldDragonFlyMonsterRace : MonsterRace
{
    protected GiantGoldDragonFlyMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(SoundBreatheBallMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperFSymbol);
    public override ColorEnum Color => ColorEnum.Gold;
    
    public override bool Animal => true;
    public override int ArmorClass => 20;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(HurtAttackEffect), 1, 3),
    };
    public override bool BashDoor => true;
    public override string Description => "Large beating wings support this dazzling insect. A loud buzzing noise pervades the air.";
    public override bool ForceSleep => true;
    public override int FreqInate => 9;
    public override int FreqSpell => 9;
    public override string FriendlyName => "Giant gold dragon fly";
    public override int Hdice => 3;
    public override int Hside => 8;
    public override bool ImmuneFire => true;
    public override int LevelFound => 19;
    public override int Mexp => 78;
    public override int NoticeRange => 12;
    public override bool RandomMove25 => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 2;
    public override int Sleep => 50;
    public override int Speed => 120;
    public override string? MultilineName => "Giant gold\ndragon\nfly";
    public override bool WeirdMind => true;
}
