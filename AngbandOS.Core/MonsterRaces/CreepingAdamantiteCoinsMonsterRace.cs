// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class CreepingAdamantiteCoinsMonsterRace : MonsterRace
{
    protected CreepingAdamantiteCoinsMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<DollarSignSymbol>();
    public override Colour Colour => Colour.Chartreuse;
    public override string Name => "Creeping adamantite coins";

    public override bool Animal => true;
    public override int ArmourClass => 50;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new BiteAttackType(), new PoisonAttackEffect(), 3, 4),
        new MonsterAttack(new TouchAttackType(), new PoisonAttackEffect(), 3, 5),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 12),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 12)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "It is a pile of coins, slithering forward on thousands of tiny legs.";
    public override bool Drop_2D2 => true;
    public override bool Drop90 => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Creeping adamantite coins";
    public override int Hdice => 20;
    public override int Hside => 25;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 27;
    public override int Mexp => 45;
    public override int NoticeRange => 5;
    public override bool OnlyDropGold => true;
    public override int Rarity => 4;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string SplitName1 => "  Creeping  ";
    public override string SplitName2 => " adamantite ";
    public override string SplitName3 => "   coins    ";
}
