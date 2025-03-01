// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ShelobSpiderOfDarknessMonsterRace : MonsterRace
{
    protected ShelobSpiderOfDarknessMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(DarkBreatheBallMonsterSpell),
        nameof(BlindnessMonsterSpell),
        nameof(CauseCriticalWoundsMonsterSpell),
        nameof(CauseMortalWoundsMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(SlowMonsterSpell),
        nameof(CreateTrapsMonsterSpell),
        nameof(HealMonsterSpell),
        nameof(SpiderSummonMonsterSpell)
    };


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    protected override string SymbolName => nameof(UpperSSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    
    public override bool Animal => true;
    public override int ArmorClass => 80;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(HurtAttackEffect), 2, 10),
        (nameof(StingAttack), nameof(PoisonAttackEffect), 2, 5),
        (nameof(StingAttack), nameof(LoseStrAttackEffect), 1, 4),
        (nameof(StingAttack), nameof(PoisonAttackEffect), 2, 5)
    };
    public override bool BashDoor => true;
    public override string Description => "Shelob is an enormous bloated spider, rumored to have been one of the brood of Ungoliant the Unlight. Her poison is legendary, as is her ego, which may be her downfall. She used to guard the pass through Cirith Ungol, but has not been seen there for many eons.";
    public override bool Drop_1D2 => true;
    public override bool Drop_2D2 => true;
    public override bool DropGood => true;
    public override bool Escorted => true;
    public override bool EscortsGroup => true;
    public override bool Evil => true;
    public override bool Female => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Shelob, Spider of Darkness";
    public override int Hdice => 12;
    public override int Hside => 100;
    public override bool HurtByLight => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 32;
    public override int Mexp => 1200;
    public override int NoticeRange => 8;
    public override bool OnlyDropItem => true;
    public override int Rarity => 3;
    public override int Sleep => 80;
    public override bool Smart => true;
    public override int Speed => 110;
    public override string? MultilineName => "Shelob";
    public override bool Unique => true;
}
