// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class DholeMonsterRace : MonsterRace
{
    protected DholeMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheAcidMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperASymbol>();
    public override ColourEnum Colour => ColourEnum.Beige;
    public override string Name => "Dhole";

    public override bool Animal => true;
    public override int ArmourClass => 64;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<SpitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<AcidAttackEffect>(), 1, 8),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<EngulfAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<AcidAttackEffect>(), 2, 8),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<CrushAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 4, 8),
    };
    public override bool Cthuloid => true;
    public override string Description => "A gigantic worm dripping with acid.";
    public override bool EldritchHorror => true;
    public override bool Evil => true;
    public override int FreqInate => 9;
    public override int FreqSpell => 9;
    public override string FriendlyName => "Dhole";
    public override int Hdice => 65;
    public override int Hside => 8;
    public override bool ImmuneAcid => true;
    public override bool KillWall => true;
    public override int LevelFound => 29;
    public override int Mexp => 500;
    public override int NoticeRange => 14;
    public override int Rarity => 4;
    public override int Sleep => 25;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "   Dhole    ";
}
