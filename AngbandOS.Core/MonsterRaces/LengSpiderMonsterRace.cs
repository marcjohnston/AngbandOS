// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class LengSpiderMonsterRace : MonsterRace
{
    protected LengSpiderMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BlindnessMonsterSpell),
        nameof(MindBlastMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(SlowMonsterSpell),
        nameof(HasteMonsterSpell),
        nameof(HealMonsterSpell),
        nameof(SpiderSummonMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperSSymbol);
    public override ColorEnum Color => ColorEnum.Purple;
    
    public override int ArmorClass => 68;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(HurtAttackEffect), 4, 3),
        (nameof(BiteAttack), nameof(PoisonAttackEffect), 3, 10),
    };
    public override bool BashDoor => true;
    public override bool Cthuloid => true;
    public override string Description => "'There were scenes of old wars, wherein Leng's almost-humans fought with the bloated purple spiders of neighbouring vales.' H.P.Lovecraft - 'The Dream Quest of Unknown Kadath'";
    public override bool Drop_1D2 => true;
    public override bool Drop_2D2 => true;
    public override bool EldritchHorror => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Leng spider";
    public override int Hdice => 45;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 33;
    public override int Mexp => 400;
    public override bool MoveBody => true;
    public override int NoticeRange => 30;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 6;
    public override bool Reflecting => true;
    public override int Sleep => 255;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string? MultilineName => "Leng\nspider";
    public override bool TakeItem => true;
}
