// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class RedWormMassMonsterRace : MonsterRace
{
    protected RedWormMassMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerWSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightRed;
    public override string Name => "Red worm mass";

    public override bool Animal => true;
    public override int ArmourClass => 12;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<CrawlAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<FireAttackEffect>(), 1, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "It is a large slimy mass of worms.";
    public override bool EmptyMind => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Red worm mass";
    public override int Hdice => 5;
    public override int Hside => 8;
    public override bool HurtByLight => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override int LevelFound => 5;
    public override int Mexp => 6;
    public override bool Multiply => true;
    public override int NoticeRange => 7;
    public override bool RandomMove25 => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 1;
    public override int Sleep => 10;
    public override int Speed => 100;
    public override string SplitName1 => "    Red     ";
    public override string SplitName2 => "    worm    ";
    public override string SplitName3 => "    mass    ";
    public override bool Stupid => true;
}