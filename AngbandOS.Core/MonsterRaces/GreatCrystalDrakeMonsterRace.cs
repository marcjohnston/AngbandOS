// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GreatCrystalDrakeMonsterRace : MonsterRace
{
    protected GreatCrystalDrakeMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BreatheShardsMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(SlowMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperDSymbol);
    public override ColorEnum Color => ColorEnum.Diamond;
    
    public override int ArmorClass => 100;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(HurtAttackEffect), 4, 9),
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(HurtAttackEffect), 4, 9),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(HurtAttackEffect), 5, 12),
    };
    public override bool BashDoor => true;
    public override string Description => "A huge crystalline dragon. Its claws could cut you to shreds and its teeth are razor sharp. Strange colors ripple through it as it moves in the light.";
    public override bool Dragon => true;
    public override bool Drop_2D2 => true;
    public override bool Drop_4D2 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Great crystal drake";
    public override int Hdice => 15;
    public override int Hside => 100;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 40;
    public override int Mexp => 3500;
    public override bool MoveBody => true;
    public override int NoticeRange => 25;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 2;
    public override bool Reflecting => true;
    public override int Sleep => 30;
    public override int Speed => 120;
    public override string? MultilineName => "Great\ncrystal\ndrake";
}
