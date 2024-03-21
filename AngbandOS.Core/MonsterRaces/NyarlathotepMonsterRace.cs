// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class NyarlathotepMonsterRace : MonsterRace
{
    protected NyarlathotepMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(ChaosBallMonsterSpell),
        nameof(BlindnessMonsterSpell),
        nameof(BrainSmashMonsterSpell),
        nameof(CauseMortalWoundsMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(FireBallMonsterSpell),
        nameof(IceBoltMonsterSpell),
        nameof(ManaBallMonsterSpell),
        nameof(ManaBoltMonsterSpell),
        nameof(NetherBallMonsterSpell),
        nameof(PlasmaBoltMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(WaterBallMonsterSpell),
        nameof(DarknessMonsterSpell),
        nameof(DreadCurseMonsterSpell),
        nameof(ForgetMonsterSpell),
        nameof(SummonCthuloidMonsterSpell),
        nameof(SummonDemonMonsterSpell),
        nameof(SummonGreatOldOneMonsterSpell),
        nameof(SummonHiDragonMonsterSpell),
        nameof(SummonHiUndeadMonsterSpell),
        nameof(SummonMonstersMonsterSpell),
        nameof(SummonReaverMonsterSpell),
        nameof(TeleportAwayMonsterSpell),
        nameof(TeleportLevelMonsterSpell),
        nameof(TeleportToMonsterSpell),
        nameof(TeleportSelfMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperXSymbol);
    public override ColorEnum Color => ColorEnum.Red;
    public override string Name => "Nyarlathotep";

    public override int ArmorClass => 165;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(UnBonusAttackEffect), 12, 12),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(UnPowerAttackEffect), 12, 12),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(ConfuseAttackEffect), 10, 2),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(BlindAttackEffect), 3, 2)
    };
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override string Description => "The Crawling Chaos in it's most monstrous form. It will do all in its power to keep you away from its master, Azathoth.";
    public override bool Drop_2D2 => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool DropGreat => true;
    public override bool Evil => true;
    public override bool FireAura => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Nyarlathotep";
    public override bool GreatOldOne => true;
    public override int Hdice => 99;
    public override int Hside => 111;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 99;
    public override bool LightningAura => true;
    public override int Mexp => 65000;
    public override bool MoveBody => true;
    public override int NoticeRange => 100;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 1;
    public override bool Reflecting => true;
    public override bool Regenerate => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 0;
    public override bool Smart => true;
    public override int Speed => 145;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "Nyarlathotep";
    public override bool Unique => true;
}
