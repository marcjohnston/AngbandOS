// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class SingingHappyDrunkMonsterRace : MonsterRace
{
    protected SingingHappyDrunkMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerTSymbol);
    public override ColorEnum Color => ColorEnum.Yellow;
    
    public override int ArmorClass => 1;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BegAttack), null, 0, 0),
    };
    public override bool BashDoor => true;
    public override string Description => "He makes you glad to be sober.";
    public override bool Drop60 => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Singing, happy drunk";
    public override int Hdice => 2;
    public override int Hside => 3;
    public override int LevelFound => 0;
    public override bool Male => true;
    public override int Mexp => 0;
    public override int NoticeRange => 10;
    public override bool OnlyDropGold => true;
    public override bool OpenDoor => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 1;
    public override int Sleep => 0;
    public override int Speed => 110;
    public override string? MultilineName => "Singing";
    public override bool TakeItem => true;
}
