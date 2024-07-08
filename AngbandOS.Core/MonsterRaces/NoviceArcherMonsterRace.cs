// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class NoviceArcherMonsterRace : MonsterRace
{
    protected NoviceArcherMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(Arrow1D6MonsterSpell)
    };

    protected override string SymbolName => nameof(LowerPSymbol);
    public override ColorEnum Color => ColorEnum.BrightGreen;
    
    public override int ArmorClass => 10;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(HurtAttackEffect), 1, 4),
        (nameof(HitAttack), nameof(HurtAttackEffect), 1, 4),
    };
    public override bool BashDoor => true;
    public override string Description => "A nasty little fellow with a bow and arrow.";
    public override bool Drop_1D2 => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Novice archer";
    public override int Hdice => 6;
    public override int Hside => 8;
    public override int LevelFound => 6;
    public override bool Male => true;
    public override int Mexp => 20;
    public override int NoticeRange => 20;
    public override bool OnlyDropGold => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 5;
    public override int Speed => 120;
    public override string? MultilineName => "Novice\narcher";
}
