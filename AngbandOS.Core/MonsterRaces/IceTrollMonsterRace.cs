// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class IceTrollMonsterRace : MonsterRace
{
    protected IceTrollMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(UpperTSymbol);
    
    public override int ArmorClass => 56;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(HurtAttackEffect), 1, 5),
        (nameof(BiteAttack), nameof(ColdAttackEffect), 3, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "He is a white troll with powerfully clawed hands.";
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Ice troll";
    public override bool Friends => true;
    public override int Hdice => 24;
    public override int Hside => 10;
    public override bool HurtByLight => true;
    public override bool ImmuneCold => true;
    public override int LevelFound => 28;
    public override bool Male => true;
    public override int Mexp => 160;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 50;
    public override int Speed => 110;
    public override string? MultilineName => "Ice\ntroll";
    public override bool Troll => true;
}
