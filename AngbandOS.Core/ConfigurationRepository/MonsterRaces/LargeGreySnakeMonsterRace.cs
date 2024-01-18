// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class LargeGreySnakeMonsterRace : MonsterRace
{
    protected LargeGreySnakeMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UpperJSymbol));
    public override ColourEnum Colour => ColourEnum.Grey;
    public override string Name => "Large grey snake";

    public override bool Animal => true;
    public override int ArmourClass => 41;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<BiteAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 5),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<CrushAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 8),
    };
    public override bool BashDoor => true;
    public override string Description => "It is about ten feet long.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Large grey snake";
    public override int Hdice => 6;
    public override int Hside => 8;
    public override int LevelFound => 4;
    public override int Mexp => 14;
    public override int NoticeRange => 6;
    public override bool RandomMove25 => true;
    public override int Rarity => 1;
    public override int Sleep => 50;
    public override int Speed => 100;
    public override string SplitName1 => "   Large    ";
    public override string SplitName2 => "    grey    ";
    public override string SplitName3 => "   snake    ";
}
