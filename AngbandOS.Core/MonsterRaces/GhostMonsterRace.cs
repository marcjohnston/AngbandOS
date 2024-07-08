// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GhostMonsterRace : MonsterRace
{
    protected GhostMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BlindnessMonsterSpell),
        nameof(DrainManaMonsterSpell),
        nameof(HoldMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperGSymbol);
    
    public override int ArmorClass => 30;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(WailAttack), nameof(TerrifyAttackEffect), 0, 0),
        (nameof(TouchAttack), nameof(Exp20AttackEffect), 0, 0),
        (nameof(ClawAttack), nameof(LoseIntAttackEffect), 1, 6),
        (nameof(ClawAttack), nameof(LoseWisAttackEffect), 1, 6)
    };
    public override bool ColdBlood => true;
    public override string Description => "You don't believe in them.";
    public override bool Drop_1D2 => true;
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 16;
    public override int FreqSpell => 16;
    public override string FriendlyName => "Ghost";
    public override int Hdice => 13;
    public override int Hside => 8;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 31;
    public override int Mexp => 350;
    public override int NoticeRange => 20;
    public override bool PassWall => true;
    public override bool RandomMove25 => true;
    public override int Rarity => 1;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string? MultilineName => "Ghost";
    public override bool TakeItem => true;
    public override bool Undead => true;
}
