// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class NetherWraithMonsterRace : MonsterRace
{
    protected NetherWraithMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BlindnessMonsterSpell),
        nameof(CauseCriticalWoundsMonsterSpell),
        nameof(MindBlastMonsterSpell),
        nameof(NetherBoltMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(DarknessMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperWSymbol);
    public override ColorEnum Color => ColorEnum.BrightRed;
    
    public override int ArmorClass => 55;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(HurtAttackEffect), 1, 12),
        (nameof(HitAttack), nameof(HurtAttackEffect), 1, 12),
        (nameof(TouchAttack), nameof(Exp80AttackEffect), 0, 0),
        (nameof(TouchAttack), nameof(Exp80AttackEffect), 0, 0)
    };
    public override bool ColdBlood => true;
    public override string Description => "A form that hurts the eye, death permeates the air around it. As it nears you, a coldness saps your soul.";
    public override bool Drop_4D2 => true;
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Nether wraith";
    public override int Hdice => 48;
    public override int Hside => 10;
    public override bool HurtByLight => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 39;
    public override int Mexp => 1700;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool PassWall => true;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string? MultilineName => "Nether\nwraith";
    public override bool Undead => true;
}
