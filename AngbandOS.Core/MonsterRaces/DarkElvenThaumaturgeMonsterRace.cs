// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class DarkElvenThaumaturgeMonsterRace : MonsterRace
{
    protected DarkElvenThaumaturgeMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(AcidBoltMonsterSpell),
        nameof(BlindnessMonsterSpell),
        nameof(CauseCriticalWoundsMonsterSpell),
        nameof(ColdBallMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(FireBallMonsterSpell),
        nameof(MagicMissileMonsterSpell),
        nameof(BlinkMonsterSpell),
        nameof(DarknessMonsterSpell),
        nameof(HealMonsterSpell),
        nameof(DemonSummonMonsterSpell),
        nameof(MonsterSummonMonsterSpell),
        nameof(UndeadSummonMonsterSpell),
        nameof(TeleportToMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerHSymbol);
    public override ColorEnum Color => ColorEnum.Red;
    
    public override int ArmorClass => 70;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(HurtAttackEffect), 2, 8),
        (nameof(HitAttack), nameof(HurtAttackEffect), 2, 8),
        (nameof(HitAttack), nameof(HurtAttackEffect), 2, 8),
    };
    public override bool BashDoor => true;
    public override string Description => "A dark elven figure, dressed in deepest black. Power seems to crackle from her slender frame.";
    public override bool Drop_4D2 => true;
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override bool Female => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Dark elven thaumaturge";
    public override int Hdice => 80;
    public override int Hside => 10;
    public override bool HurtByLight => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 41;
    public override int Mexp => 3000;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 130;
    public override string? MultilineName => "Dark\nelven\nthaumaturge";
}
