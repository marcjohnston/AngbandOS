// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class SilverJellyMonsterRace : MonsterRace
{
    protected SilverJellyMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(DrainManaMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerJSymbol);
    public override ColorEnum Color => ColorEnum.Silver;
    public override string Name => "Silver jelly";

    public override int ArmorClass => 1;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(TouchAttack), nameof(EatLightAttackEffect), 1, 3),
        new MonsterAttackDefinition(nameof(TouchAttack), nameof(EatLightAttackEffect), 1, 3),
    };
    public override string Description => "It is a large pile of silver flesh that sucks all light from its surroundings.";
    public override bool EmptyMind => true;
    public override int FreqInate => 16;
    public override int FreqSpell => 16;
    public override string FriendlyName => "Silver jelly";
    public override int Hdice => 10;
    public override int Hside => 8;
    public override bool HurtByLight => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 3;
    public override int Mexp => 12;
    public override bool NeverMove => true;
    public override int NoticeRange => 2;
    public override int Rarity => 2;
    public override int Sleep => 99;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Silver   ";
    public override string SplitName3 => "   jelly    ";
    public override bool Stupid => true;
}
