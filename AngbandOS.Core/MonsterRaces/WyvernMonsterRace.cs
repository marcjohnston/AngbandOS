// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class WyvernMonsterRace : MonsterRace
{
    protected WyvernMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerDSymbol>();
    public override ColourEnum Colour => ColourEnum.Brown;
    public override string Name => "Wyvern";

    public override bool Animal => true;
    public override int ArmourClass => 65;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 2, 6),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 2, 6),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 2, 6),
        new MonsterAttack(new StingAttackType(), new PoisonAttackEffect(), 1, 6)
    };
    public override bool BashDoor => true;
    public override string Description => "A fast-moving and deadly dragonian animal. Beware its poisonous sting!";
    public override bool Dragon => true;
    public override bool Drop60 => true;
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Wyvern";
    public override int Hdice => 100;
    public override int Hside => 5;
    public override bool ImmunePoison => true;
    public override int LevelFound => 20;
    public override int Mexp => 360;
    public override bool MoveBody => true;
    public override int NoticeRange => 20;
    public override bool OnlyDropGold => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "   Wyvern   ";
}
