// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class AncalagonTheBlackMonsterRace : MonsterRace
{
    protected AncalagonTheBlackMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(AcidBreatheBallMonsterSpell),
        nameof(BlindnessMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(SummonDragonMonsterSpell),
        nameof(SummonHiDragonMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperDSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    
    public override int ArmorClass => 125;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(HurtAttackEffect), 5, 12),
        (nameof(ClawAttack), nameof(HurtAttackEffect), 6, 12),
        (nameof(ClawAttack), nameof(HurtAttackEffect), 8, 12),
        (nameof(BiteAttack), nameof(HurtAttackEffect), 10, 14)
    };
    public override bool BashDoor => true;
    public override string Description => "'Rushing Jaws' is his name, and death is his game. No dragon of the brood of Glaurung can match him.";
    public override bool Dragon => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Ancalagon the Black";
    public override int Hdice => 75;
    public override int Hside => 100;
    public override bool ImmuneAcid => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 58;
    public override bool Male => true;
    public override int Mexp => 30000;
    public override bool MoveBody => true;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 3;
    public override int Sleep => 70;
    public override int Speed => 120;
    public override string? MultilineName => "Ancalagon\nthe\nBlack";
    public override bool Unique => true;
}
