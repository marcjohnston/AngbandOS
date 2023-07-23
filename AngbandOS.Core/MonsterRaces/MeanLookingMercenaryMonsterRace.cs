// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MeanLookingMercenaryMonsterRace : MonsterRace
{
    protected MeanLookingMercenaryMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerTSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightRed;
    public override string Name => "Mean looking mercenary";

    public override int ArmourClass => 20;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 10),
    };
    public override bool BashDoor => true;
    public override string Description => "No job is too low for him.";
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Mean looking mercenary";
    public override int Hdice => 5;
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
    public override string SplitName1 => "    Mean    ";
    public override string SplitName2 => "  looking   ";
    public override string SplitName3 => " mercenary  ";
    public override bool TakeItem => true;
}
