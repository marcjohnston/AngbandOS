// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GlaurungFatherOfTheDragonsMonsterRace : MonsterRace
{
    protected GlaurungFatherOfTheDragonsMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BreatheFireMonsterSpell),
        nameof(CauseCriticalWoundsMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(SummonDragonMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperDSymbol);
    public override ColorEnum Color => ColorEnum.Orange;
    public override string Name => "Glaurung, Father of the Dragons";

    public override int ArmorClass => 120;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(HurtAttackEffect), 7, 12),
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(HurtAttackEffect), 7, 12),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(HurtAttackEffect), 8, 14),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(HurtAttackEffect), 8, 14)
    };
    public override bool BashDoor => true;
    public override string Description => "Glaurung is the father of all dragons, and was for a long time the most powerful. Nevertheless, he still has full command over his brood and can command them to appear whenever he so wishes. He is the definition of dragonfire.";
    public override bool Dragon => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Glaurung, Father of the Dragons";
    public override int Hdice => 28;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 48;
    public override bool Male => true;
    public override int Mexp => 25000;
    public override bool MoveBody => true;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool Powerful => true;
    public override int Rarity => 2;
    public override int Sleep => 70;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "  Glaurung  ";
    public override bool Unique => true;
}
