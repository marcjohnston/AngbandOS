// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GreyIckyThingMonsterRace : MonsterRace
{
    protected GreyIckyThingMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string SymbolName => nameof(LowerISymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Grey icky thing";

    public override int ArmorClass => 12;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(TouchAttack), nameof(HurtAttackEffect), 1, 5),
    };
    public override string Description => "It is a smallish, slimy, icky, nasty creature.";
    public override bool EmptyMind => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Grey icky thing";
    public override int Hdice => 4;
    public override int Hside => 8;
    public override int LevelFound => 5;
    public override int Mexp => 10;
    public override int NoticeRange => 14;
    public override bool RandomMove50 => true;
    public override int Rarity => 1;
    public override int Sleep => 15;
    public override int Speed => 110;
    public override string SplitName1 => "    Grey    ";
    public override string SplitName2 => "    icky    ";
    public override string SplitName3 => "   thing    ";
}
