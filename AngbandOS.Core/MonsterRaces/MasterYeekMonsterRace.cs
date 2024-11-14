// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MasterYeekMonsterRace : MonsterRace
{
    protected MasterYeekMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BlindnessMonsterSpell),
        nameof(PoisonBallMonsterSpell),
        nameof(SlowMonsterSpell),
        nameof(BlinkMonsterSpell),
        nameof(MonsterSummonMonsterSpell),
        nameof(TeleportSelfMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerYSymbol);
    public override ColorEnum Color => ColorEnum.Green;
    
    public override bool Animal => true;
    public override int ArmorClass => 24;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(HurtAttackEffect), 1, 8),
    };
    public override bool BashDoor => true;
    public override string Description => "A small humanoid that radiates some power.";
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "Master yeek";
    public override int Hdice => 12;
    public override int Hside => 9;
    public override bool ImmuneAcid => true;
    public override int LevelFound => 12;
    public override int Mexp => 28;
    public override int NoticeRange => 18;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string? MultilineName => "Master\nyeek";
}
