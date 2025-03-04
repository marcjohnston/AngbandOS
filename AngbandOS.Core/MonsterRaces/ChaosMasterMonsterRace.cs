// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ChaosMasterMonsterRace : MonsterRace
{
    protected ChaosMasterMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(ChaosBallMonsterSpell),
        nameof(HealMonsterSpell),
        nameof(DemonSummonMonsterSpell),
        nameof(SpiderSummonMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerPSymbol);
    public override ColorEnum Color => ColorEnum.Purple;
    
    public override int ArmorClass => 50;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(HurtAttackEffect), 10, 2),
        (nameof(KickAttack), nameof(HurtAttackEffect), 10, 2),
        (nameof(PunchAttack), nameof(HurtAttackEffect), 10, 2),
        (nameof(KickAttack), nameof(HurtAttackEffect), 10, 2)
    };
    public override bool AttrAny => true;
    public override bool BashDoor => true;
    public override string Description => "An adept of chaos, feared for his skill of invoking raw chaos.";
    public override bool Drop_1D2 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Chaos master";
    public override int Hdice => 30;
    public override int Hside => 10;
    public override bool ImmuneAcid => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 33;
    public override bool Male => true;
    public override int Mexp => 550;
    public override int NoticeRange => 30;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override int Sleep => 5;
    public override int Speed => 120;
    public override string? MultilineName => "Chaos\nmaster";
}
