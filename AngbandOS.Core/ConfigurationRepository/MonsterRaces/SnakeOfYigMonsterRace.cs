// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class SnakeOfYigMonsterRace : MonsterRace
{
    protected SnakeOfYigMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BreathePoisonMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperJSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightGreen;
    public override string Name => "Snake of Yig";

    public override bool Animal => true;
    public override int ArmourClass => 80;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<BiteAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<PoisonAttackEffect>(), 3, 12),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<BiteAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<PoisonAttackEffect>(), 3, 12),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<BiteAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<PoisonAttackEffect>(), 3, 12),
    };
    public override bool BashDoor => true;
    public override string Description => "It is a giant snake that drips with poison.";
    public override bool Evil => true;
    public override bool FireAura => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Snake of Yig";
    public override bool Friends => true;
    public override int Hdice => 48;
    public override int Hside => 10;
    public override bool ImmuneFire => true;
    public override int LevelFound => 83;
    public override int Mexp => 600;
    public override bool MoveBody => true;
    public override int NoticeRange => 25;
    public override bool RandomMove25 => true;
    public override int Rarity => 4;
    public override int Sleep => 30;
    public override int Speed => 120;
    public override string SplitName1 => "   Snake    ";
    public override string SplitName2 => "     of     ";
    public override string SplitName3 => "    Yig     ";
}
