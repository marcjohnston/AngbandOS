// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class PoltergeistMonsterRace : MonsterRace
{
    protected PoltergeistMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BlinkMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperGSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    
    public override int ArmorClass => 15;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(TouchAttack), nameof(TerrifyAttackEffect), 0, 0),
    };
    public override bool ColdBlood => true;
    public override string Description => "It is a ghastly, ghostly form.";
    public override bool Drop60 => true;
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override int FreqInate => 16;
    public override int FreqSpell => 16;
    public override string FriendlyName => "Poltergeist";
    public override int Hdice => 2;
    public override int Hside => 5;
    public override bool HurtByLight => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 3;
    public override int Mexp => 8;
    public override int NoticeRange => 8;
    public override bool PassWall => true;
    public override bool RandomMove25 => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 1;
    public override int Sleep => 10;
    public override int Speed => 130;
    public override string? MultilineName => "Poltergeist";
    public override bool TakeItem => true;
    public override bool Undead => true;
}
