// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GiantSalamanderMonsterRace : MonsterRace
{
    protected GiantSalamanderMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheFireMonsterSpell)));
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UpperRSymbol));
    public override ColourEnum Colour => ColourEnum.Red;
    public override string Name => "Giant salamander";

    public override bool Animal => true;
    public override int ArmourClass => 40;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BiteAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(FireAttackEffect)), 3, 6),
    };
    public override string Description => "A large black and yellow lizard. You'd better run away!";
    public override bool ForceSleep => true;
    public override int FreqInate => 9;
    public override int FreqSpell => 9;
    public override string FriendlyName => "Giant salamander";
    public override int Hdice => 6;
    public override int Hside => 7;
    public override bool ImmuneFire => true;
    public override int LevelFound => 8;
    public override int Mexp => 50;
    public override int NoticeRange => 6;
    public override bool RandomMove25 => true;
    public override int Rarity => 1;
    public override int Sleep => 1;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Giant    ";
    public override string SplitName3 => " salamander ";
}
