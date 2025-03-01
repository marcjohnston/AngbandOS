// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GreatWyrmOfBalanceMonsterRace : MonsterRace
{
    protected GreatWyrmOfBalanceMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(ChaosBreatheBallMonsterSpell),
        nameof(DisenchantBreatheBallMonsterSpell),
        nameof(ShardsBreatheBallMonsterSpell),
        nameof(SoundBreatheBallMonsterSpell),
        nameof(BlindnessMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(DragonSummonMonsterSpell),
        nameof(HiDragonSummonMonsterSpell)
    };


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    protected override string SymbolName => nameof(UpperDSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    
    public override int ArmorClass => 170;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(HurtAttackEffect), 5, 12),
        (nameof(ClawAttack), nameof(HurtAttackEffect), 5, 12),
        (nameof(ClawAttack), nameof(HurtAttackEffect), 5, 12),
        (nameof(BiteAttack), nameof(HurtAttackEffect), 8, 14)
    };
    public override bool AttrAny => true;
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override string Description => "A massive dragon, it is thousands of years old and seeks to maintain the Cosmic Balance. It sees you as an upstart troublemaker without the wisdom to control your actions. ";
    public override bool Dragon => true;
    public override bool Drop_2D2 => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Great Wyrm of Balance";
    public override int Hdice => 49;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 67;
    public override int Mexp => 31000;
    public override bool MoveBody => true;
    public override int NoticeRange => 40;
    public override bool OnlyDropItem => true;
    public override bool Powerful => true;
    public override int Rarity => 4;
    public override bool ResistDisenchant => true;
    public override int Sleep => 255;
    public override int Speed => 120;
    public override string? MultilineName => "Great\nWyrm of\nBalance";
}
