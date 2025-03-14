// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ShuddeMellMonsterRace : MonsterRace
{
    protected ShuddeMellMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BrainSmashMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(HoldMonsterSpell),
        nameof(MindBlastMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(ForgetMonsterSpell),
        nameof(HasteMonsterSpell),
        nameof(HealMonsterSpell),
        nameof(CthuloidSummonMonsterSpell)
    };


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    protected override string SymbolName => nameof(UpperXSymbol);
    public override ColorEnum Color => ColorEnum.Brown;
    
    public override int ArmorClass => 90;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(CrushAttack), nameof(ShatterAttackEffect), 3, 11),
        (nameof(CrushAttack), nameof(ShatterAttackEffect), 3, 11),
        (nameof(TouchAttack), nameof(LoseConAttackEffect), 1, 2),
        (nameof(TouchAttack), nameof(LoseConAttackEffect), 1, 2)
    };
    public override bool Cthuloid => true;
    public override string Description => "The largest of the cthonians and leader of his kind.";
    public override bool Drop_2D2 => true;
    public override bool Drop_4D2 => true;
    public override bool EldritchHorror => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Shudde M'ell";
    public override int Hdice => 100;
    public override int Hside => 10;
    public override bool ImmuneCold => true;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override bool KillWall => true;
    public override int LevelFound => 56;
    public override int Mexp => 2300;
    public override int NoticeRange => 20;
    public override bool OnlyDropGold => true;
    public override int Rarity => 2;
    public override bool ResistPlasma => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string? MultilineName => "Shudde\nM'ell";
    public override bool Unique => true;
}
