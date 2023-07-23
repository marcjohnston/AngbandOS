// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MiGoMonsterRace : MonsterRace
{
    protected MiGoMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<ConfuseMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonCthuloidMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonMonsterMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperASymbol>();
    public override ColourEnum Colour => ColourEnum.BrightPink;
    public override string Name => "Mi-Go";

    public override bool Animal => true;
    public override int ArmourClass => 30;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new StingAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<PoisonAttackEffect>(), 1, 4),
        new MonsterAttack(new BiteAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<LoseStrAttackEffect>(), 1, 2),
    };
    public override bool ColdBlood => true;
    public override bool Cthuloid => true;
    public override string Description => "Five feet long pinkish insectoids with a multitude of antennae, with a buzzing voice.";
    public override bool Evil => true;
    public override int FreqInate => 8;
    public override int FreqSpell => 8;
    public override string FriendlyName => "Mi-Go";
    public override int Hdice => 13;
    public override int Hside => 8;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 15;
    public override int Mexp => 80;
    public override int NoticeRange => 20;
    public override int Rarity => 2;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "   Mi-Go    ";
}
