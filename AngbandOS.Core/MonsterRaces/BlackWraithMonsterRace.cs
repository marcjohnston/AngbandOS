// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class BlackWraithMonsterRace : MonsterRace
{
    protected BlackWraithMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BlindnessMonsterSpell),
        nameof(CauseCriticalWoundsMonsterSpell),
        nameof(HoldMonsterSpell),
        nameof(NetherBoltMonsterSpell),
        nameof(ScareMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperWSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    
    public override int ArmorClass => 55;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(HurtAttackEffect), 1, 12),
        (nameof(HitAttack), nameof(HurtAttackEffect), 1, 12),
        (nameof(TouchAttack), nameof(Exp40AttackEffect), 0, 0),
        (nameof(TouchAttack), nameof(Exp40AttackEffect), 0, 0)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "A figure that seems made of void, its strangely human shape is cloaked in shadow. It reaches out at you.";
    public override bool Drop_1D2 => true;
    public override bool Drop_2D2 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 7;
    public override int FreqSpell => 7;
    public override string FriendlyName => "Black wraith";
    public override int Hdice => 50;
    public override int Hside => 10;
    public override bool HurtByLight => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 38;
    public override int Mexp => 1700;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string? MultilineName => "Black\nwraith";
    public override bool Undead => true;
}
