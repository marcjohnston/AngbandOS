// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class WerewormMonsterRace : MonsterRace
{
    protected WerewormMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(LowerWSymbol));
    public override ColourEnum Colour => ColourEnum.Brown;
    public override string Name => "Wereworm";

    public override bool Animal => true;
    public override int ArmourClass => 70;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(GazeAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(Exp20AttackEffect)), 0, 0),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(CrawlAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(AcidAttackEffect)), 2, 4),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BiteAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 1, 10),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BiteAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(PoisonAttackEffect)), 1, 6)
    };
    public override bool BashDoor => true;
    public override string Description => "A huge wormlike shape dripping acid, twisted by evil sorcery into a foul monster that breeds on death.";
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Wereworm";
    public override int Hdice => 100;
    public override int Hside => 11;
    public override bool ImmuneAcid => true;
    public override int LevelFound => 25;
    public override int Mexp => 300;
    public override int NoticeRange => 15;
    public override int Rarity => 3;
    public override int Sleep => 20;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "  Wereworm  ";
}
