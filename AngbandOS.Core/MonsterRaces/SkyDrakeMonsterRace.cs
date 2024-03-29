// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class SkyDrakeMonsterRace : MonsterRace
{
    protected SkyDrakeMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BreatheLightningMonsterSpell),
        nameof(BreatheGravityMonsterSpell),
        nameof(BreatheLightMonsterSpell),
        nameof(BlindnessMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(SummonDragonMonsterSpell),
        nameof(SummonHiDragonMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperDSymbol);
    public override ColorEnum Color => ColorEnum.BrightBlue;
    
    public override int ArmorClass => 200;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(HurtAttackEffect), 8, 12),
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(HurtAttackEffect), 8, 12),
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(HurtAttackEffect), 8, 12),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(ElectricityAttackEffect), 9, 15)
    };
    public override bool BashDoor => true;
    public override string Description => "The mightiest elemental dragon of air, it can destroy you with ease.";
    public override bool Dragon => true;
    public override bool Drop_2D2 => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Sky Drake";
    public override bool Good => true;
    public override int Hdice => 60;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneLightning => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 69;
    public override bool LightningAura => true;
    public override int Mexp => 31000;
    public override bool MoveBody => true;
    public override int NoticeRange => 40;
    public override bool OnlyDropItem => true;
    public override bool Powerful => true;
    public override int Rarity => 4;
    public override bool ResistTeleport => true;
    public override int Sleep => 255;
    public override int Speed => 130;
    public override string? MultilineName => "Sky\nDrake";
}
