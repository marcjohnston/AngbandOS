// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class SpottedMushroomPatchMonsterRace : MonsterRace
{
    protected SpottedMushroomPatchMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string SymbolName => nameof(CommaSymbol);
    public override ColorEnum Color => ColorEnum.Orange;
    public override string Name => "Spotted mushroom patch";

    public override int ArmorClass => 1;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(SporeAttack), nameof(PoisonAttackEffect), 2, 4),
    };
    public override string Description => "Yum! It looks quite tasty.";
    public override bool EmptyMind => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Spotted mushroom patch";
    public override int Hdice => 1;
    public override int Hside => 1;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 3;
    public override int Mexp => 3;
    public override bool NeverMove => true;
    public override int NoticeRange => 2;
    public override int Rarity => 1;
    public override int Sleep => 0;
    public override int Speed => 110;
    public override string SplitName1 => "  Spotted   ";
    public override string SplitName2 => "  mushroom  ";
    public override string SplitName3 => "   patch    ";
    public override bool Stupid => true;
}
