// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class SoldierAntMonsterRace : MonsterRace
{
    protected SoldierAntMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerASymbol>();
    public override ColourEnum Colour => ColourEnum.Brown;
    public override string Name => "Soldier ant";

    public override bool Animal => true;
    public override int ArmourClass => 3;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<BiteAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 2),
    };
    public override bool BashDoor => true;
    public override string Description => "A large ant with powerful mandibles.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Soldier ant";
    public override int Hdice => 2;
    public override int Hside => 5;
    public override int LevelFound => 1;
    public override int Mexp => 3;
    public override int NoticeRange => 10;
    public override int Rarity => 1;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "  Soldier   ";
    public override string SplitName3 => "    ant     ";
    public override bool WeirdMind => true;
}
