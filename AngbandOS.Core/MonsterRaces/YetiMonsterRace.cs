// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class YetiMonsterRace : MonsterRace
{
    protected YetiMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperYSymbol>();
    public override string Name => "Yeti";

    public override bool Animal => true;
    public override int ArmourClass => 24;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 3),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 3),
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 4),
    };
    public override bool BashDoor => true;
    public override string Description => "A large white figure covered in shaggy fur.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Yeti";
    public override int Hdice => 11;
    public override int Hside => 9;
    public override bool ImmuneCold => true;
    public override int LevelFound => 9;
    public override int Mexp => 30;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "    Yeti    ";
}
