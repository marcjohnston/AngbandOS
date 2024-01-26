// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GiantArmyAntMonsterRace : MonsterRace
{
    protected GiantArmyAntMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(LowerASymbol));
    public override ColorEnum Color => ColorEnum.Orange;
    public override string Name => "Giant army ant";

    public override bool Animal => true;
    public override int ArmorClass => 40;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BiteAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 2, 12),
    };
    public override bool BashDoor => true;
    public override string Description => "An armored form moving with purpose. Powerful on its own, flee when hordes of them march.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Giant army ant";
    public override bool Friends => true;
    public override int Hdice => 19;
    public override int Hside => 6;
    public override bool KillBody => true;
    public override int LevelFound => 30;
    public override int Mexp => 90;
    public override int NoticeRange => 10;
    public override bool RandomMove25 => true;
    public override int Rarity => 3;
    public override int Sleep => 40;
    public override int Speed => 120;
    public override string SplitName1 => "   Giant    ";
    public override string SplitName2 => "    army    ";
    public override string SplitName3 => "    ant     ";
    public override bool WeirdMind => true;
}
