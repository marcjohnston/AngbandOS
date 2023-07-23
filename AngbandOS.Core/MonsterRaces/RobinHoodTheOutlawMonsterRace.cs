// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class RobinHoodTheOutlawMonsterRace : MonsterRace
{
    protected RobinHoodTheOutlawMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<Arrow3D6MonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<CreateTrapsMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<HealMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerPSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightChartreuse;
    public override string Name => "Robin Hood, the Outlaw";

    public override int ArmourClass => 30;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 5),
        new MonsterAttack(new HitAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 5),
        new MonsterAttack(new TouchAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<EatGoldAttackEffect>(), 0, 0),
        new MonsterAttack(new TouchAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<EatItemAttackEffect>(), 0, 0)
    };
    public override bool BashDoor => true;
    public override string Description => "The legendary archer steals from the rich (you qualify). ";
    public override bool Drop_1D2 => true;
    public override bool DropGood => true;
    public override bool DropGreat => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Robin Hood, the Outlaw";
    public override int Hdice => 14;
    public override int Hside => 12;
    public override int LevelFound => 8;
    public override bool Male => true;
    public override int Mexp => 150;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Robin    ";
    public override string SplitName3 => "    Hood    ";
    public override bool TakeItem => true;
    public override bool Unique => true;
}
