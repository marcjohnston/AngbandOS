// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GiantCockroachMonsterRace : MonsterRace
{
    protected GiantCockroachMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UpperISymbol));
    public override ColourEnum Colour => ColourEnum.Brown;
    public override string Name => "Giant cockroach";

    public override bool Animal => true;
    public override int ArmourClass => 25;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<BiteAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 2),
    };
    public override bool BashDoor => true;
    public override string Description => "Oh no! They are everywhere!";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Giant cockroach";
    public override int Hdice => 2;
    public override int Hside => 2;
    public override bool ImmunePoison => true;
    public override int LevelFound => 14;
    public override int Mexp => 4;
    public override bool Multiply => true;
    public override int NoticeRange => 8;
    public override bool RandomMove25 => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 1;
    public override bool ResistDisenchant => true;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Giant    ";
    public override string SplitName3 => " cockroach  ";
    public override bool TakeItem => true;
    public override bool WeirdMind => true;
}
