// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GorgimeraMonsterRace : MonsterRace
{
    protected GorgimeraMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheFireMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperHSymbol>();
    public override ColourEnum Colour => ColourEnum.Chartreuse;
    public override string Name => "Gorgimera";

    public override int ArmourClass => 55;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new BiteAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<FireAttackEffect>(), 1, 3),
        new MonsterAttack(new BiteAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 10),
        new MonsterAttack(new GazeAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<ParalyzeAttackEffect>(), 2, 4),
        new MonsterAttack(new ButtAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 3)
    };
    public override bool BashDoor => true;
    public override string Description => "It has 3 heads - gorgon, goat and dragon - all attached to a lion's body.";
    public override bool ForceSleep => true;
    public override int FreqInate => 8;
    public override int FreqSpell => 8;
    public override string FriendlyName => "Gorgimera";
    public override int Hdice => 25;
    public override int Hside => 20;
    public override bool ImmuneFire => true;
    public override int LevelFound => 27;
    public override int Mexp => 200;
    public override int NoticeRange => 12;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => " Gorgimera  ";
}
