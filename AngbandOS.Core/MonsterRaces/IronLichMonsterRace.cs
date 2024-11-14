// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class IronLichMonsterRace : MonsterRace
{
    protected IronLichMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(FireBreatheBallMonsterSpell),
        nameof(BrainSmashMonsterSpell),
        nameof(CauseMortalWoundsMonsterSpell),
        nameof(ColdBallMonsterSpell),
        nameof(DrainManaMonsterSpell),
        nameof(IceBoltMonsterSpell),
        nameof(LightningBallMonsterSpell),
        nameof(WaterBallMonsterSpell),
        nameof(UndeadSummonMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperLSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    
    public override int ArmorClass => 100;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ButtAttack), nameof(ColdAttackEffect), 3, 6),
        (nameof(ButtAttack), nameof(FireAttackEffect), 3, 6),
        (nameof(ButtAttack), nameof(ElectricityAttackEffect), 3, 6),
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "It is a huge, twisted grey skull floating through the air. Its cold eyes burn with hatred towards all who live.";
    public override bool Drop60 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Iron lich";
    public override int Hdice => 28;
    public override int Hside => 100;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 42;
    public override int Mexp => 4000;
    public override int NoticeRange => 30;
    public override bool OnlyDropItem => true;
    public override bool Powerful => true;
    public override int Rarity => 4;
    public override bool Reflecting => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string? MultilineName => "Iron\nlich";
    public override bool Undead => true;
}
