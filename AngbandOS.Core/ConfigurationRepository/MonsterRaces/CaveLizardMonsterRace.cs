// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class CaveLizardMonsterRace : MonsterRace
{
    protected CaveLizardMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UpperRSymbol));
    public override ColorEnum Color => ColorEnum.Brown;
    public override string Name => "Cave lizard";

    public override bool Animal => true;
    public override int ArmorClass => 16;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BiteAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 1, 5),
    };
    public override string Description => "It is an armored lizard with a powerful bite.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Cave lizard";
    public override int Hdice => 3;
    public override int Hside => 6;
    public override int LevelFound => 4;
    public override int Mexp => 8;
    public override int NoticeRange => 8;
    public override int Rarity => 1;
    public override int Sleep => 80;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "    Cave    ";
    public override string SplitName3 => "   lizard   ";
}
