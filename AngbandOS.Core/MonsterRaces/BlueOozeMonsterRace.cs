// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class BlueOozeMonsterRace : MonsterRace
{
    protected BlueOozeMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerJSymbol);
    public override ColorEnum Color => ColorEnum.BrightBlue;
    
    public override int ArmorClass => 16;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(CrawlAttack), nameof(ColdAttackEffect), 1, 4),
    };
    public override string Description => "It's blue and it's oozing.";
    public override bool Drop60 => true;
    public override bool EmptyMind => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Blue ooze";
    public override int Hdice => 3;
    public override int Hside => 4;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 5;
    public override int Mexp => 7;
    public override int NoticeRange => 8;
    public override bool RandomMove25 => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 1;
    public override int Sleep => 80;
    public override int Speed => 110;
    public override string? MultilineName => "Blue\nooze";
    public override bool Stupid => true;
}
