// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class SangahyandoOfUmbarMonsterRace : MonsterRace
{
    protected SangahyandoOfUmbarMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<SlowMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ForgetMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerPSymbol>();
    public override ColourEnum Colour => ColourEnum.Orange;
    public override string Name => "Sangahyando of Umbar";

    public override int ArmourClass => 80;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 4, 6),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 4, 6),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 4, 6),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 4, 6)
    };
    public override bool BashDoor => true;
    public override string Description => "A Black Numenorean with a blacker heart.";
    public override bool Drop_1D2 => true;
    public override bool Drop90 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "Sangahyando of Umbar";
    public override int Hdice => 80;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 24;
    public override bool Male => true;
    public override int Mexp => 400;
    public override int NoticeRange => 25;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 25;
    public override int Speed => 110;
    public override string SplitName1 => "Sangahyando ";
    public override string SplitName2 => "     of     ";
    public override string SplitName3 => "   Umbar    ";
    public override bool Unique => true;
}
