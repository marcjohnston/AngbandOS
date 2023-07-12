// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GravityHoundMonsterRace : MonsterRace
{
    protected GravityHoundMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new BreatheGravityMonsterSpell());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperZSymbol>();
    public override ColourEnum Colour => ColourEnum.Turquoise;
    public override string Name => "Gravity hound";

    public override bool Animal => true;
    public override int ArmourClass => 30;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 2, 12),
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 2, 12),
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 2, 12),
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 3, 3)
    };
    public override bool BashDoor => true;
    public override string Description => "Unfettered by the usual constraints of gravity, these unnatural creatures are walking on the walls and even the ceiling! The earth suddenly feels rather less solid as you see gravity warp all round the monsters.";
    public override bool ForceSleep => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Gravity hound";
    public override bool Friends => true;
    public override int Hdice => 35;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 35;
    public override int Mexp => 500;
    public override int NoticeRange => 30;
    public override int Rarity => 2;
    public override int Sleep => 0;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "  Gravity   ";
    public override string SplitName3 => "   hound    ";
}
