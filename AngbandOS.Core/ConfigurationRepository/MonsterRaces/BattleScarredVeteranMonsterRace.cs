// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class BattleScarredVeteranMonsterRace : MonsterRace
{
    protected BattleScarredVeteranMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerTSymbol>();
    public override ColourEnum Colour => ColourEnum.Red;
    public override string Name => "Battle scarred veteran";

    public override int ArmourClass => 30;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 2, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "He doesn't take to strangers kindly.";
    public override bool Drop90 => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Battle scarred veteran";
    public override int Hdice => 7;
    public override int Hside => 8;
    public override int LevelFound => 0;
    public override bool Male => true;
    public override int Mexp => 0;
    public override int NoticeRange => 10;
    public override bool OpenDoor => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 1;
    public override int Sleep => 250;
    public override int Speed => 110;
    public override string SplitName1 => "   Battle   ";
    public override string SplitName2 => "  scarred   ";
    public override string SplitName3 => "  veteran   ";
    public override bool TakeItem => true;
}
