// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class AgentOfTheBlackMarketMonsterRace : MonsterRace
{
    protected AgentOfTheBlackMarketMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string SymbolName => nameof(LowerTSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "Agent of the black market";

    public override int ArmorClass => 8;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 1, 6),
        new MonsterAttackDefinition(nameof(TouchAttack), nameof(EatItemAttackEffect), 0, 0),
    };
    public override bool BashDoor => true;
    public override string Description => "He 'finds' new wares for the Black Market. From unwary adventurers...";
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Agent of the black market";
    public override int Hdice => 2;
    public override int Hside => 8;
    public override int LevelFound => 0;
    public override bool Male => true;
    public override int Mexp => 0;
    public override int NoticeRange => 10;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 99;
    public override int Speed => 110;
    public override string SplitName1 => "  Agent of  ";
    public override string SplitName2 => " the black  ";
    public override string SplitName3 => "   market   ";
    public override bool TakeItem => true;
}
