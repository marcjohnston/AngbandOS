// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MandorMasterOfChaosMonsterRace : MonsterRace
{
    protected MandorMasterOfChaosMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(ChaosBallMonsterSpell),
        nameof(ColdBoltMonsterSpell),
        nameof(FireBoltMonsterSpell),
        nameof(HoldMonsterSpell),
        nameof(IceBoltMonsterSpell),
        nameof(ManaBoltMonsterSpell),
        nameof(PlasmaBoltMonsterSpell),
        nameof(CreateTrapsMonsterSpell),
        nameof(HealMonsterSpell),
        nameof(SummonMonsterMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerPSymbol);
    public override ColorEnum Color => ColorEnum.Purple;
    public override string Name => "Mandor, Master of Chaos";

    public override int ArmorClass => 90;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 5, 5),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 5, 5),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(UnPowerAttackEffect), 5, 5),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(UnBonusAttackEffect), 5, 5)
    };
    public override bool BashDoor => true;
    public override string Description => "Mandor is one of the greatest chaos Masters, a formidable magician.";
    public override bool Drop_2D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Mandor, Master of Chaos";
    public override int Hdice => 88;
    public override int Hside => 11;
    public override int LevelFound => 38;
    public override bool Male => true;
    public override int Mexp => 1600;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 5;
    public override bool ResistTeleport => true;
    public override int Sleep => 40;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "   Mandor   ";
    public override bool TakeItem => true;
    public override bool Unique => true;
}
