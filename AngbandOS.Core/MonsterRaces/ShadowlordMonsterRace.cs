// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ShadowlordMonsterRace : MonsterRace
{
    protected ShadowlordMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(ShriekMonsterSpell),
        nameof(BlindnessMonsterSpell),
        nameof(BrainSmashMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(DrainManaMonsterSpell),
        nameof(HoldMonsterSpell),
        nameof(NetherBallMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(DarknessMonsterSpell),
        nameof(SummonUndeadMonsterSpell),
        nameof(TeleportToMonsterSpell),
        nameof(TeleportSelfMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperGSymbol);
    public override ColorEnum Color => ColorEnum.Blue;
    
    public override int ArmorClass => 150;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(Exp40AttackEffect), 6, 6),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(Exp40AttackEffect), 6, 6),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(LoseStrAttackEffect), 4, 6),
        new MonsterAttackDefinition(nameof(GazeAttack), nameof(TerrifyAttackEffect), 4, 6)
    };
    public override bool ColdBlood => true;
    public override string Description => "An aura of hatred, cowardice and falsehood surrounds you as this cloaked figure floats towards you.";
    public override bool Drop_2D2 => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Shadowlord";
    public override int Hdice => 30;
    public override int Hside => 100;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 62;
    public override int Mexp => 22500;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool PassWall => true;
    public override int Rarity => 2;
    public override bool ResistTeleport => true;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string? MultilineName => "Shadowlord";
    public override bool TakeItem => true;
    public override bool Undead => true;
}
