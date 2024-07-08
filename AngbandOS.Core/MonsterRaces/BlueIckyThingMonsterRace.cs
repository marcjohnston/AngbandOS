// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class BlueIckyThingMonsterRace : MonsterRace
{
    protected BlueIckyThingMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BlindnessMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(ScareMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerISymbol);
    public override ColorEnum Color => ColorEnum.Blue;
    
    public override int ArmorClass => 20;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(CrawlAttack), nameof(PoisonAttackEffect), 1, 4),
        (nameof(CrawlAttack), nameof(EatFoodAttackEffect), 0, 0),
        (nameof(HitAttack), nameof(HurtAttackEffect), 1, 4),
        (nameof(HitAttack), nameof(HurtAttackEffect), 1, 4)
    };
    public override bool BashDoor => true;
    public override string Description => "It is a strange, slimy, icky creature, with rudimentary intelligence, but evil cunning. It hungers for food, and you look tasty.";
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 8;
    public override int FreqSpell => 8;
    public override string FriendlyName => "Blue icky thing";
    public override int Hdice => 10;
    public override int Hside => 6;
    public override bool ImmunePoison => true;
    public override int LevelFound => 14;
    public override int Mexp => 20;
    public override bool Multiply => true;
    public override int NoticeRange => 15;
    public override bool OpenDoor => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 4;
    public override int Sleep => 20;
    public override int Speed => 100;
    public override string? MultilineName => "Blue\nicky\nthing";
}
