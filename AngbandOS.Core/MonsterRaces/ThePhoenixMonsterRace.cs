// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ThePhoenixMonsterRace : MonsterRace
{
    protected ThePhoenixMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(FireBreatheBallMonsterSpell),
        nameof(LightBreatheBallMonsterSpell),
        nameof(PlasmaBreatheBallMonsterSpell),
        nameof(FireBallMonsterSpell),
        nameof(FireBoltMonsterSpell),
        nameof(PlasmaBoltMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperBSymbol);
    public override ColorEnum Color => ColorEnum.Red;
    
    public override bool Animal => true;
    public override int ArmorClass => 130;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(FireAttackEffect), 12, 6),
        (nameof(BiteAttack), nameof(FireAttackEffect), 12, 6),
        (nameof(HitAttack), nameof(FireAttackEffect), 9, 12),
        (nameof(HitAttack), nameof(FireAttackEffect), 9, 12)
    };
    public override bool BashDoor => true;
    public override string Description => "A massive glowing eagle bathed in flames. The searing heat chars your skin and melts your armor.";
    public override bool Drop_2D2 => true;
    public override bool DropGood => true;
    public override bool FireAura => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "The Phoenix";
    public override bool Good => true;
    public override int Hdice => 36;
    public override int Hside => 100;
    public override bool ImmuneAcid => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 54;
    public override int Mexp => 40000;
    public override int NoticeRange => 60;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override bool ResistPlasma => true;
    public override int Sleep => 0;
    public override int Speed => 120;
    public override string? MultilineName => "The\nPhoenix";
    public override bool Unique => true;
}
