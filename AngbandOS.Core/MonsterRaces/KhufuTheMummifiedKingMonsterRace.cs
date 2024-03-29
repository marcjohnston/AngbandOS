// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class KhufuTheMummifiedKingMonsterRace : MonsterRace
{
    protected KhufuTheMummifiedKingMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(CauseCriticalWoundsMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(SlowMonsterSpell),
        nameof(CreateTrapsMonsterSpell),
        nameof(DarknessMonsterSpell),
        nameof(SummonKinMonsterSpell),
        nameof(SummonUndeadMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerZSymbol);
    public override ColorEnum Color => ColorEnum.Gold;
    
    public override int ArmorClass => 40;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(GazeAttack), nameof(TerrifyAttackEffect), 0, 0),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(PoisonAttackEffect), 6, 6),
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(LoseConAttackEffect), 0, 0),
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(LoseConAttackEffect), 0, 0)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "He is out to have a revenge on you who have desecrated his tomb.";
    public override bool Drop90 => true;
    public override bool DropGood => true;
    public override bool Escorted => true;
    public override bool EscortsGroup => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Khufu the mummified King";
    public override int Hdice => 85;
    public override int Hside => 11;
    public override bool ImmuneCold => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override int LevelFound => 26;
    public override bool Male => true;
    public override int Mexp => 500;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 4;
    public override bool ResistTeleport => true;
    public override int Sleep => 40;
    public override int Speed => 110;
    public override string? MultilineName => "Khufu the\nmummified\nKing";
    public override bool Undead => true;
    public override bool Unique => true;
}
