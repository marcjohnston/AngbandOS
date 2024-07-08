// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class AzathothTheDaemonSultanMonsterRace : MonsterRace
{
    protected AzathothTheDaemonSultanMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BreatheChaosMonsterSpell),
        nameof(BreatheDisintegrationMonsterSpell),
        nameof(BreatheManaMonsterSpell),
        nameof(BreatheNetherMonsterSpell),
        nameof(BreathePoisonMonsterSpell),
        nameof(BreatheRadiationMonsterSpell),
        nameof(ChaosBallMonsterSpell),
        nameof(BrainSmashMonsterSpell),
        nameof(DreadCurseMonsterSpell),
        nameof(HasteMonsterSpell),
        nameof(SummonCthuloidMonsterSpell),
        nameof(SummonGreatOldOneMonsterSpell),
        nameof(SummonHiDragonMonsterSpell),
        nameof(SummonHiUndeadMonsterSpell),
        nameof(SummonMonstersMonsterSpell),
        nameof(SummonReaverMonsterSpell),
        nameof(SummonUniqueMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperXSymbol);
    public override ColorEnum Color => ColorEnum.Pink;
    
    public override int ArmorClass => 175;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(CrushAttack), nameof(ShatterAttackEffect), 22, 10),
        new MonsterAttackDefinition(nameof(CrushAttack), nameof(ShatterAttackEffect), 20, 10),
        new MonsterAttackDefinition(nameof(TouchAttack), nameof(LoseAllAttackEffect), 10, 12),
        new MonsterAttackDefinition(nameof(TouchAttack), nameof(DrainStaffChargesAttackEffect), 0, 0),
        new MonsterAttackDefinition(nameof(TouchAttack), nameof(DrainWandChargesAttackEffect), 0, 0)
    };
    public override string Description => "'That last amorphous blight of nethermost confusion which blasphemes and bubbles at the centre of all infinity - the boundless daemon sultan Azathoth, whose name no lips dare speak aloud, and who gnaws hungrily in inconceivable, unlighted chambers beyond time amidst the muffled, maddening beating of vile drums and the thin monotonous whine of accursed flutes' - H.P.Lovecraft, 'The Dream Quest of Unknown Kadath'";
    public override bool Drop_1D2 => true;
    public override bool Drop_2D2 => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool DropGreat => true;
    public override bool EldritchHorror => true;
    public override bool Evil => true;
    public override bool FireAura => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Azathoth, The Daemon Sultan";
    public override bool GreatOldOne => true;
    public override int Hdice => 200;
    public override int Hside => 150;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool ImmuneStun => true;
    public override bool KillBody => true;
    public override bool KillWall => true;
    public override int LevelFound => 100;
    public override bool LightningAura => true;
    public override int Mexp => 66666;
    public override bool Nonliving => true;
    public override int NoticeRange => 111;
    public override bool OnlyDropItem => true;
    public override bool Powerful => true;
    public override int Rarity => 1;
    public override bool Reflecting => true;
    public override bool Regenerate => true;
    public override bool ResistNether => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 0;
    public override bool Smart => true;
    public override int Speed => 155;
    public override string? MultilineName => "Azathoth";
    public override bool Unique => true;
}
