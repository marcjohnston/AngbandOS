// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MangyLookingLeperMonsterRace : MonsterRace
{
    protected MangyLookingLeperMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerTSymbol>();
    public override ColourEnum Colour => ColourEnum.Brown;
    public override string Name => "Mangy looking leper";

    public override int ArmourClass => 1;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new BegAttackType(), null, 0, 0),
        new MonsterAttack(new TouchAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<LoseConAttackEffect>(), 0, 0),
    };
    public override string Description => "You feel it isn't safe to touch him.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Mangy looking leper";
    public override int Hdice => 1;
    public override int Hside => 1;
    public override int LevelFound => 0;
    public override bool Male => true;
    public override int Mexp => 0;
    public override int NoticeRange => 10;
    public override bool OpenDoor => true;
    public override bool RandomMove25 => true;
    public override int Rarity => 1;
    public override int Sleep => 50;
    public override int Speed => 110;
    public override string SplitName1 => "   Mangy    ";
    public override string SplitName2 => "  looking   ";
    public override string SplitName3 => "   leper    ";
    public override bool TakeItem => true;
}
