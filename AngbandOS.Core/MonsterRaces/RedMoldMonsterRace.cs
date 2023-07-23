// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class RedMoldMonsterRace : MonsterRace
{
    protected RedMoldMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerMSymbol>();
    public override ColourEnum Colour => ColourEnum.Red;
    public override string Name => "Red mold";

    public override int ArmourClass => 16;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new TouchAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<FireAttackEffect>(), 4, 4),
    };
    public override string Description => "It is a strange red growth on the dungeon floor; it seems to burn with flame.";
    public override bool EmptyMind => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Red mold";
    public override int Hdice => 17;
    public override int Hside => 8;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 19;
    public override int Mexp => 64;
    public override bool NeverMove => true;
    public override int NoticeRange => 2;
    public override int Rarity => 1;
    public override int Sleep => 70;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "    Red     ";
    public override string SplitName3 => "    mold    ";
    public override bool Stupid => true;
}
