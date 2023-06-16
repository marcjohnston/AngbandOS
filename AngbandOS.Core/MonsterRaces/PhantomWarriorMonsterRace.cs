// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class PhantomWarriorMonsterRace : MonsterRace
{
    protected PhantomWarriorMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => 'G';
    public override Colour Colour => Colour.BrightTurquoise;
    public override string Name => "Phantom warrior";

    public override int ArmourClass => 10;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 11),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 11),
    };
    public override bool ColdBlood => true;
    public override string Description => "Creatures that are half real, half illusion.";
    public override bool EmptyMind => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Phantom warrior";
    public override bool Friends => true;
    public override int Hdice => 5;
    public override int Hside => 5;
    public override bool ImmuneFear => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 8;
    public override int Mexp => 15;
    public override bool Nonliving => true;
    public override int NoticeRange => 20;
    public override bool PassWall => true;
    public override int Rarity => 1;
    public override int Sleep => 40;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "  Phantom   ";
    public override string SplitName3 => "  warrior   ";
}
