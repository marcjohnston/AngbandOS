// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class LargeBrownSnakeMonsterRace : MonsterRace
{
    protected LargeBrownSnakeMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UpperJSymbol));
    public override ColourEnum Colour => ColourEnum.Brown;
    public override string Name => "Large brown snake";

    public override bool Animal => true;
    public override int ArmourClass => 35;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BiteAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 1, 3),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(CrushAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 1, 4),
    };
    public override bool BashDoor => true;
    public override string Description => "It is about eight feet long.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Large brown snake";
    public override int Hdice => 4;
    public override int Hside => 6;
    public override int LevelFound => 1;
    public override int Mexp => 3;
    public override int NoticeRange => 4;
    public override bool RandomMove25 => true;
    public override int Rarity => 1;
    public override int Sleep => 99;
    public override int Speed => 100;
    public override string SplitName1 => "   Large    ";
    public override string SplitName2 => "   brown    ";
    public override string SplitName3 => "   snake    ";
}
