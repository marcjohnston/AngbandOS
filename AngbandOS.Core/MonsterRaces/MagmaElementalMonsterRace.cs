// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MagmaElementalMonsterRace : MonsterRace
{
    protected MagmaElementalMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new FireBallMonsterSpell(),
        new PlasmaBoltMonsterSpell());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperESymbol>();
    public override Colour Colour => Colour.Orange;
    public override string Name => "Magma elemental";

    public override int ArmourClass => 70;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 4, 6),
        new MonsterAttack(new HitAttackType(), new FireAttackEffect(), 3, 7),
        new MonsterAttack(new HitAttackType(), new FireAttackEffect(), 3, 7),
    };
    public override string Description => "It is a towering glowing form of molten hate.";
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override bool FireAura => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 7;
    public override int FreqSpell => 7;
    public override string FriendlyName => "Magma elemental";
    public override int Hdice => 35;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool KillBody => true;
    public override bool KillItem => true;
    public override int LevelFound => 37;
    public override int Mexp => 950;
    public override int NoticeRange => 10;
    public override bool PassWall => true;
    public override bool Powerful => true;
    public override int Rarity => 2;
    public override int Sleep => 90;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Magma    ";
    public override string SplitName3 => " elemental  ";
}
