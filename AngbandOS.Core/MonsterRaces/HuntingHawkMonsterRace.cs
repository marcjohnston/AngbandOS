// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class HuntingHawkMonsterRace : MonsterRace
{
    protected HuntingHawkMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperBSymbol>();
    public override ColourEnum Colour => ColourEnum.Brown;
    public override string Name => "Hunting hawk";

    public override bool Animal => true;
    public override int ArmourClass => 25;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new ClawAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 3),
        new MonsterAttack(new ClawAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 3),
        new MonsterAttack(new BiteAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 4),
    };
    public override string Description => "Trained to hunt and kill without fear.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Hunting hawk";
    public override int Hdice => 8;
    public override int Hside => 8;
    public override bool ImmuneFear => true;
    public override int LevelFound => 8;
    public override int Mexp => 22;
    public override int NoticeRange => 30;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "  Hunting   ";
    public override string SplitName3 => "    hawk    ";
}
