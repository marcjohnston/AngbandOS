// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class SarumanOfManyColorsMonsterRace : MonsterRace
{
    protected SarumanOfManyColorsMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(AcidBallMonsterSpell),
        nameof(BlindnessMonsterSpell),
        nameof(CauseMortalWoundsMonsterSpell),
        nameof(ColdBallMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(FireBallMonsterSpell),
        nameof(IceBoltMonsterSpell),
        nameof(MindBlastMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(WaterBallMonsterSpell),
        nameof(CreateTrapsMonsterSpell),
        nameof(ForgetMonsterSpell),
        nameof(HasteMonsterSpell),
        nameof(HealMonsterSpell),
        nameof(SummonDemonMonsterSpell),
        nameof(SummonDragonMonsterSpell),
        nameof(SummonUndeadMonsterSpell),
        nameof(TeleportAwayMonsterSpell),
        nameof(TeleportSelfMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerPSymbol);
    public override ColorEnum Color => ColorEnum.Purple;
    
    public override int ArmorClass => 100;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(DisenchantAttackEffect), 6, 8),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(DisenchantAttackEffect), 6, 8),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 5, 5),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 5, 5)
    };
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override string Description => "Originally known as the White, Saruman fell prey to Sauron's wiles. He searches forever for the One Ring, to become a mighty Sorcerer-King of the world.";
    public override bool Drop_2D2 => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Saruman of Many Colors";
    public override int Hdice => 50;
    public override int Hside => 100;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 60;
    public override bool Male => true;
    public override int Mexp => 35000;
    public override int NoticeRange => 100;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override bool Reflecting => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 0;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string? MultilineName => "Saruman\nof Many\nColors";
    public override bool Unique => true;
}
