// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class CrystalDrakeMonsterRace : MonsterRace
{
    protected CrystalDrakeMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(ShardsBreatheBallMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(SlowMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerDSymbol);
    public override ColorEnum Color => ColorEnum.Diamond;
    
    public override int ArmorClass => 100;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(HurtAttackEffect), 1, 4),
        (nameof(ClawAttack), nameof(HurtAttackEffect), 1, 4),
        (nameof(BiteAttack), nameof(HurtAttackEffect), 2, 5),
    };
    public override bool BashDoor => true;
    public override string Description => "A dragon of strange crystalline form. Light shines through it, dazzling your eyes with spectrums of color.";
    public override bool Dragon => true;
    public override bool Drop_4D2 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Crystal drake";
    public override int Hdice => 50;
    public override int Hside => 10;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 37;
    public override int Mexp => 1500;
    public override int NoticeRange => 25;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override bool Reflecting => true;
    public override int Sleep => 30;
    public override int Speed => 120;
    public override string? MultilineName => "Crystal\ndrake";
}
