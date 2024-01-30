// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class XornMonsterRace : MonsterRace
{
    protected XornMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string SymbolName => nameof(LowerXSymbol);
    public override ColorEnum Color => ColorEnum.Orange;
    public override string Name => "Xorn";

    public override int ArmorClass => 80;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 1, 6),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 1, 6),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 1, 6),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 1, 6)
    };
    public override bool ColdBlood => true;
    public override string Description => "A huge creature of the element Earth. Able to merge with its element, it has four huge arms protruding from its enormous torso.";
    public override bool EmptyMind => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Xorn";
    public override int Hdice => 16;
    public override int Hside => 10;
    public override bool HurtByRock => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool KillItem => true;
    public override int LevelFound => 36;
    public override int Mexp => 650;
    public override int NoticeRange => 20;
    public override bool PassWall => true;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "    Xorn    ";
}
