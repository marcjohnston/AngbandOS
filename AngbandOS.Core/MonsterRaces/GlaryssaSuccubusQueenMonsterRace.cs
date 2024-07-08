// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GlaryssaSuccubusQueenMonsterRace : MonsterRace
{
    protected GlaryssaSuccubusQueenMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(AcidBoltMonsterSpell),
        nameof(BlindnessMonsterSpell),
        nameof(CauseCriticalWoundsMonsterSpell),
        nameof(HoldMonsterSpell),
        nameof(MindBlastMonsterSpell),
        nameof(NetherBoltMonsterSpell),
        nameof(DarknessMonsterSpell),
        nameof(ForgetMonsterSpell),
        nameof(SummonDemonMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperUSymbol);
    public override ColorEnum Color => ColorEnum.BrightPink;
    
    public override int ArmorClass => 60;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(HurtAttackEffect), 5, 5),
        (nameof(ClawAttack), nameof(HurtAttackEffect), 5, 5),
        (nameof(HitAttack), nameof(LoseStrAttackEffect), 4, 4),
        (nameof(TouchAttack), nameof(Exp80AttackEffect), 8, 1)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override bool Demon => true;
    public override string Description => "Drop dead gorgeous - literally.";
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Glaryssa, Succubus Queen";
    public override int Hdice => 12;
    public override int Hside => 100;
    public override bool ImmuneCold => true;
    public override bool ImmunePoison => true;
    public override int LevelFound => 41;
    public override int Mexp => 8000;
    public override bool MoveBody => true;
    public override bool Nonliving => true;
    public override int NoticeRange => 90;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool PassWall => true;
    public override int Rarity => 3;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string? MultilineName => "Glaryssa";
    public override bool Unique => true;
}
