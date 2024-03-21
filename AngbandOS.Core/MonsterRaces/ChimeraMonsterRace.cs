// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ChimeraMonsterRace : MonsterRace
{
    protected ChimeraMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BreatheFireMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperHSymbol);
    public override ColorEnum Color => ColorEnum.Yellow;
    public override string Name => "Chimera";

    public override int ArmorClass => 15;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(HurtAttackEffect), 1, 10),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(FireAttackEffect), 1, 3),
        new MonsterAttackDefinition(nameof(ButtAttack), nameof(HurtAttackEffect), 1, 3),
    };
    public override bool BashDoor => true;
    public override string Description => "It is a strange concoction of lion, dragon and goat. It looks very odd but very avoidable.";
    public override bool ForceSleep => true;
    public override int FreqInate => 10;
    public override int FreqSpell => 10;
    public override string FriendlyName => "Chimera";
    public override int Hdice => 13;
    public override int Hside => 8;
    public override bool ImmuneFire => true;
    public override int LevelFound => 20;
    public override int Mexp => 200;
    public override int NoticeRange => 12;
    public override int Rarity => 1;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "  Chimera   ";
}
