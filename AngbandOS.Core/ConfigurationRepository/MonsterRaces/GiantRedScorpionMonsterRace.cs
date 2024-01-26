// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GiantRedScorpionMonsterRace : MonsterRace
{
    protected GiantRedScorpionMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UpperSSymbol));
    public override ColorEnum Color => ColorEnum.BrightRed;
    public override string Name => "Giant red scorpion";

    public override bool Animal => true;
    public override int ArmorClass => 44;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BiteAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 2, 4),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(StingAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(LoseStrAttackEffect)), 1, 7),
    };
    public override bool BashDoor => true;
    public override string Description => "It is fast and poisonous.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Giant red scorpion";
    public override int Hdice => 11;
    public override int Hside => 8;
    public override int LevelFound => 17;
    public override int Mexp => 62;
    public override int NoticeRange => 12;
    public override int Rarity => 1;
    public override int Sleep => 20;
    public override int Speed => 110;
    public override string SplitName1 => "   Giant    ";
    public override string SplitName2 => "    red     ";
    public override string SplitName3 => "  scorpion  ";
    public override bool WeirdMind => true;
}
