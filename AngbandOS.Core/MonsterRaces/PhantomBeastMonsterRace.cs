// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class PhantomBeastMonsterRace : MonsterRace
{
    protected PhantomBeastMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperGSymbol>();
    public override Colour Colour => Colour.Turquoise;
    public override string Name => "Phantom beast";

    public override int ArmourClass => 10;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 2, 34),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 2, 34),
    };
    public override bool ColdBlood => true;
    public override string Description => "A creature that is half real, half illusion.";
    public override bool EmptyMind => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Phantom beast";
    public override int Hdice => 9;
    public override int Hside => 9;
    public override bool ImmuneFear => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 24;
    public override int Mexp => 100;
    public override bool Nonliving => true;
    public override int NoticeRange => 20;
    public override bool PassWall => true;
    public override int Rarity => 1;
    public override bool ResistTeleport => true;
    public override int Sleep => 40;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "  Phantom   ";
    public override string SplitName3 => "   beast    ";
}
