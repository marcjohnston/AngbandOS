// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class FilthyStreetUrchinMonsterRace : MonsterRace
{
    protected FilthyStreetUrchinMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerTSymbol);
    public override ColorEnum Color => ColorEnum.BrightGrey;
    
    public override int ArmorClass => 1;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BegAttack), null, 0, 0),
        (nameof(TouchAttack), nameof(EatGoldAttackEffect), 0, 0),
    };
    public override string Description => "He looks squalid and thoroughly revolting.";
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Filthy street urchin";
    public override bool Friends => true;
    public override int Hdice => 1;
    public override int Hside => 4;
    public override int LevelFound => 0;
    public override bool Male => true;
    public override int Mexp => 0;
    public override int NoticeRange => 4;
    public override bool OpenDoor => true;
    public override bool RandomMove25 => true;
    public override int Rarity => 2;
    public override int Sleep => 40;
    public override int Speed => 110;
    public override string? MultilineName => "Filthy\nstreet\nurchin";
    public override bool TakeItem => true;
}
