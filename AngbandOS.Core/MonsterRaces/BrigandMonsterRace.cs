// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class BrigandMonsterRace : MonsterRace
{
    protected BrigandMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerPSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    
    public override int ArmorClass => 32;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(HurtAttackEffect), 2, 6),
        (nameof(TouchAttack), nameof(EatGoldAttackEffect), 0, 0),
        (nameof(TouchAttack), nameof(EatItemAttackEffect), 0, 0),
    };
    public override bool BashDoor => true;
    public override string Description => "He is eyeing your purse suspiciously.";
    public override bool Drop_1D2 => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Brigand";
    public override int Hdice => 9;
    public override int Hside => 8;
    public override int LevelFound => 10;
    public override bool Male => true;
    public override int Mexp => 35;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string? MultilineName => "Brigand";
    public override bool TakeItem => true;
}
