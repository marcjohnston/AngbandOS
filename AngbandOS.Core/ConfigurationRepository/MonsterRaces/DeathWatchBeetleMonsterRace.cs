// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class DeathWatchBeetleMonsterRace : MonsterRace
{
    protected DeathWatchBeetleMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperKSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightBrown;
    public override string Name => "Death watch beetle";

    public override bool Animal => true;
    public override int ArmourClass => 60;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<BiteAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 5, 4),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<WailAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<TerrifyAttackEffect>(), 5, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "It is a giant beetle that produces a chilling sound.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Death watch beetle";
    public override int Hdice => 25;
    public override int Hside => 12;
    public override int LevelFound => 31;
    public override int Mexp => 190;
    public override int NoticeRange => 16;
    public override int Rarity => 3;
    public override int Sleep => 30;
    public override int Speed => 110;
    public override string SplitName1 => "   Death    ";
    public override string SplitName2 => "   watch    ";
    public override string SplitName3 => "   beetle   ";
    public override bool WeirdMind => true;
}