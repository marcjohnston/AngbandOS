// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ShamblerMonsterRace : MonsterRace
{
    protected ShamblerMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BreatheLightningMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperESymbol);
    public override ColorEnum Color => ColorEnum.BrightWhite;
    
    public override int ArmorClass => 150;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(HurtAttackEffect), 3, 12),
        (nameof(ClawAttack), nameof(HurtAttackEffect), 3, 12),
        (nameof(CrushAttack), nameof(HurtAttackEffect), 8, 12),
        (nameof(CrushAttack), nameof(HurtAttackEffect), 8, 12)
    };
    public override bool BashDoor => true;
    public override string Description => "This elemental creature is power incarnate; it looks like a huge polar bear with a huge gaping maw instead of a head.";
    public override bool Drop_1D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Shambler";
    public override int Hdice => 50;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 67;
    public override int Mexp => 22500;
    public override bool MoveBody => true;
    public override int NoticeRange => 40;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 4;
    public override bool ResistTeleport => true;
    public override int Sleep => 50;
    public override int Speed => 130;
    public override string? MultilineName => "Shambler";
}
