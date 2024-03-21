// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ForestTrollMonsterRace : MonsterRace
{
    protected ForestTrollMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(UpperTSymbol);
    public override ColorEnum Color => ColorEnum.BrightGreen;
    public override string Name => "Forest troll";

    public override int ArmorClass => 50;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 1, 4),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 1, 4),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(HurtAttackEffect), 1, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "He is green skinned and ugly.";
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Forest troll";
    public override bool Friends => true;
    public override int Hdice => 20;
    public override int Hside => 10;
    public override bool HurtByLight => true;
    public override int LevelFound => 17;
    public override bool Male => true;
    public override int Mexp => 70;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 40;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Forest   ";
    public override string SplitName3 => "   troll    ";
    public override bool Troll => true;
}
