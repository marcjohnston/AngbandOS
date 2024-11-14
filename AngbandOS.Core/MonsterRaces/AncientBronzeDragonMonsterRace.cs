// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class AncientBronzeDragonMonsterRace : MonsterRace
{
    protected AncientBronzeDragonMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(ConfusionBreatheBallMonsterSpell),
        nameof(BlindnessMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(ScareMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperDSymbol);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    
    public override int ArmorClass => 100;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(HurtAttackEffect), 4, 8),
        (nameof(ClawAttack), nameof(HurtAttackEffect), 4, 8),
        (nameof(BiteAttack), nameof(ColdAttackEffect), 5, 10),
    };
    public override bool BashDoor => true;
    public override string Description => "A huge draconic form enveloped in a cascade of color.";
    public override bool Dragon => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Ancient bronze dragon";
    public override int Hdice => 73;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 38;
    public override int Mexp => 1700;
    public override bool MoveBody => true;
    public override int NoticeRange => 20;
    public override bool Powerful => true;
    public override int Rarity => 2;
    public override int Sleep => 200;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string? MultilineName => "Ancient\nbronze\ndragon";
}
