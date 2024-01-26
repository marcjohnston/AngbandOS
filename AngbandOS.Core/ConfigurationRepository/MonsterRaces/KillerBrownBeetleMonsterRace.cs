// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class KillerBrownBeetleMonsterRace : MonsterRace
{
    protected KillerBrownBeetleMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UpperKSymbol));
    public override ColorEnum Color => ColorEnum.Brown;
    public override string Name => "Killer brown beetle";

    public override bool Animal => true;
    public override int ArmorClass => 40;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BiteAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 3, 4),
    };
    public override bool BashDoor => true;
    public override string Description => "It is a vicious insect with a tough carapace.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Killer brown beetle";
    public override int Hdice => 13;
    public override int Hside => 8;
    public override int LevelFound => 13;
    public override int Mexp => 38;
    public override int NoticeRange => 10;
    public override int Rarity => 2;
    public override int Sleep => 30;
    public override int Speed => 110;
    public override string SplitName1 => "   Killer   ";
    public override string SplitName2 => "   brown    ";
    public override string SplitName3 => "   beetle   ";
    public override bool WeirdMind => true;
}
