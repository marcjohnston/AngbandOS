// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ColbranMonsterRace : MonsterRace
{
    protected ColbranMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(LightningBoltMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerGSymbol);
    public override ColorEnum Color => ColorEnum.Blue;
    public override string Name => "Colbran";

    public override int ArmorClass => 80;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(ElectricityAttackEffect), 3, 8),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(ElectricityAttackEffect), 3, 8),
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "A man-shaped form of living lightning, sparks and shocks crackle all over this madly capering figure, as it leaps and whirls around and about you.";
    public override bool EmptyMind => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Colbran";
    public override int Hdice => 80;
    public override int Hside => 12;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 27;
    public override bool LightningAura => true;
    public override int Mexp => 900;
    public override bool Nonliving => true;
    public override int NoticeRange => 12;
    public override int Rarity => 2;
    public override bool Reflecting => true;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "  Colbran   ";
}
