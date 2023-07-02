// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class KascheiTheImmortalMonsterRace : MonsterRace
{
    protected KascheiTheImmortalMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new BlindnessMonsterSpell(),
        new BrainSmashMonsterSpell(),
        new CauseMortalWoundsMonsterSpell(),
        new FireBallMonsterSpell(),
        new ManaBallMonsterSpell(),
        new ManaBoltMonsterSpell(),
        new ScareMonsterSpell(),
        new DreadCurseMonsterSpell(),
        new SummonDemonMonsterSpell(),
        new SummonHiUndeadMonsterSpell(),
        new SummonMonstersMonsterSpell(),
        new TeleportSelfMonsterSpell());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperLSymbol>();
    public override Colour Colour => Colour.Purple;
    public override string Name => "Kaschei the Immortal";

    public override int ArmourClass => 100;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), new UnBonusAttackEffect(), 6, 8),
        new MonsterAttack(new HitAttackType(), new UnBonusAttackEffect(), 6, 8),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 5, 5),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 5, 5)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "A stench of corruption and decay surrounds this sorcerer, who has clearly risen from the grave to continue his foul plots and schemes.";
    public override bool Drop_2D2 => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool DropGreat => true;
    public override bool Escorted => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Kaschei the Immortal";
    public override int Hdice => 60;
    public override int Hside => 100;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 90;
    public override bool Male => true;
    public override int Mexp => 45000;
    public override int NoticeRange => 100;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override bool ResistTeleport => true;
    public override int Sleep => 0;
    public override bool Smart => true;
    public override int Speed => 130;
    public override string SplitName1 => "  Kaschei   ";
    public override string SplitName2 => "    the     ";
    public override string SplitName3 => "  Immortal  ";
    public override bool Undead => true;
    public override bool Unique => true;
}
