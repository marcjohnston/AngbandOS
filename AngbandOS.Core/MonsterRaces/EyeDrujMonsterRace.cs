// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class EyeDrujMonsterRace : MonsterRace
{
    protected EyeDrujMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(ManaBoltMonsterSpell),
        nameof(NetherBallMonsterSpell),
        nameof(NetherBoltMonsterSpell),
        nameof(UndeadSummonMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerSSymbol);
    public override ColorEnum Color => ColorEnum.BrightGrey;
    
    public override int ArmorClass => 90;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(GazeAttack), nameof(Exp80AttackEffect), 0, 0),
        (nameof(GazeAttack), nameof(Exp80AttackEffect), 0, 0),
    };
    public override bool ColdBlood => true;
    public override string Description => "A bloodshot eyeball floating in the air, you'd be forgiven for assuming it harmless.";
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 1;
    public override int FreqSpell => 1;
    public override string FriendlyName => "Eye druj";
    public override int Hdice => 10;
    public override int Hside => 100;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 55;
    public override int Mexp => 24000;
    public override bool NeverMove => true;
    public override int NoticeRange => 20;
    public override int Rarity => 4;
    public override bool ResistTeleport => true;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 130;
    public override string? MultilineName => "Eye\ndruj";
    public override bool Undead => true;
}
