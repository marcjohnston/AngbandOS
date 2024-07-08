// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class BlackKnightMonsterRace : MonsterRace
{
    protected BlackKnightMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BlindnessMonsterSpell),
        nameof(CauseCriticalWoundsMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(DarknessMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerPSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    
    public override int ArmorClass => 70;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(HurtAttackEffect), 5, 5),
        (nameof(HitAttack), nameof(HurtAttackEffect), 5, 5),
        (nameof(HitAttack), nameof(HurtAttackEffect), 5, 5),
    };
    public override bool BashDoor => true;
    public override string Description => "He is a figure encased in deep black plate armor; he looks at you menacingly.";
    public override bool Drop_1D2 => true;
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 8;
    public override int FreqSpell => 8;
    public override string FriendlyName => "Black knight";
    public override int Hdice => 30;
    public override int Hside => 10;
    public override int LevelFound => 28;
    public override bool Male => true;
    public override int Mexp => 240;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string? MultilineName => "Black\nknight";
}
