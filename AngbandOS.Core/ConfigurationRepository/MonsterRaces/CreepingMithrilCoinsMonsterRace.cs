// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class CreepingMithrilCoinsMonsterRace : MonsterRace
{
    protected CreepingMithrilCoinsMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<DollarSignSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightBlue;
    public override string Name => "Creeping mithril coins";

    public override bool Animal => true;
    public override int ArmourClass => 50;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 2, 5),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<TouchAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<PoisonAttackEffect>(), 3, 5),
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "It is a pile of coins, shambling forward on thousands of tiny legs.";
    public override bool Drop_2D2 => true;
    public override bool Drop90 => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Creeping mithril coins";
    public override int Hdice => 20;
    public override int Hside => 8;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 13;
    public override int Mexp => 45;
    public override int NoticeRange => 5;
    public override bool OnlyDropGold => true;
    public override int Rarity => 4;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string SplitName1 => "  Creeping  ";
    public override string SplitName2 => "  mithril   ";
    public override string SplitName3 => "   coins    ";
}