// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GrooTheWandererMonsterRace : MonsterRace
{
    protected GrooTheWandererMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerPSymbol);
    public override ColorEnum Color => ColorEnum.BrightOrange;
    
    public override int ArmorClass => 70;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(HurtAttackEffect), 5, 5),
        (nameof(HitAttack), nameof(HurtAttackEffect), 5, 5),
        (nameof(HitAttack), nameof(HurtAttackEffect), 6, 1),
    };
    public override bool BashDoor => true;
    public override string Description => "He who laughs at Groo's brains will find there is nothing to laugh about... erm, nobody laughs at Groo and lives.";
    public override bool Drop_1D2 => true;
    public override bool DropGood => true;
    public override bool DropGreat => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Groo the Wanderer";
    public override int Hdice => 11;
    public override int Hside => 100;
    public override bool ImmuneCold => true;
    public override bool ImmunePoison => true;
    public override int LevelFound => 33;
    public override bool Male => true;
    public override int Mexp => 2000;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 7;
    public override int Sleep => 50;
    public override int Speed => 110;
    public override string? MultilineName => "Groo\nthe\nWanderer";
    public override bool Troll => true;
    public override bool Unique => true;
    public override bool WeirdMind => true;
}
