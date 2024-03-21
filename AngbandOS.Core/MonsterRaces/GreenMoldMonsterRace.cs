// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GreenMoldMonsterRace : MonsterRace
{
    protected GreenMoldMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string SymbolName => nameof(LowerMSymbol);
    public override ColorEnum Color => ColorEnum.Green;
    public override string Name => "Green mold";

    public override int ArmorClass => 14;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(TerrifyAttackEffect), 1, 4),
    };
    public override string Description => "It is a strange growth on the dungeon floor.";
    public override bool EmptyMind => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Green mold";
    public override int Hdice => 21;
    public override int Hside => 8;
    public override bool ImmuneAcid => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 8;
    public override int Mexp => 28;
    public override bool NeverMove => true;
    public override int NoticeRange => 2;
    public override int Rarity => 2;
    public override int Sleep => 75;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Green    ";
    public override string SplitName3 => "    mold    ";
    public override bool Stupid => true;
}
