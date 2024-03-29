// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class OrfaxSonOfBoldorMonsterRace : MonsterRace
{
    protected OrfaxSonOfBoldorMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(ConfuseMonsterSpell),
        nameof(SlowMonsterSpell),
        nameof(BlinkMonsterSpell),
        nameof(HealMonsterSpell),
        nameof(SummonMonsterMonsterSpell),
        nameof(TeleportToMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerYSymbol);
    public override ColorEnum Color => ColorEnum.BrightBlue;
    
    public override bool Animal => true;
    public override int ArmorClass => 20;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 1, 9),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 1, 8),
        new MonsterAttackDefinition(nameof(InsultAttack), null, 0, 0),
        new MonsterAttackDefinition(nameof(InsultAttack), null, 0, 0)
    };
    public override bool BashDoor => true;
    public override string Description => "He's just like daddy! He knows mighty spells, but fortunately he is a yeek.";
    public override bool Drop90 => true;
    public override bool DropGood => true;
    public override bool Escorted => true;
    public override bool EscortsGroup => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "Orfax, Son of Boldor";
    public override int Hdice => 12;
    public override int Hside => 10;
    public override bool ImmuneAcid => true;
    public override int LevelFound => 10;
    public override bool Male => true;
    public override int Mexp => 80;
    public override int NoticeRange => 18;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string? MultilineName => "Orfax";
    public override bool Unique => true;
}
