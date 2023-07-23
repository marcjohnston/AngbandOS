// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class LesserWallMonsterMonsterRace : MonsterRace
{
    protected LesserWallMonsterMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<PoundSignSymbol>();
    public override string Name => "Lesser wall monster";

    public override int ArmourClass => 75;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 2, 6),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 2, 6),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 2, 6),
    };
    public override bool BashDoor => true;
    public override bool CharMulti => true;
    public override bool ColdBlood => true;
    public override string Description => "A sentient, moving section of wall.";
    public override bool EmptyMind => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Lesser wall monster";
    public override int Hdice => 13;
    public override int Hside => 8;
    public override bool HurtByRock => true;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool KillWall => true;
    public override int LevelFound => 28;
    public override int Mexp => 600;
    public override bool Multiply => true;
    public override bool Nonliving => true;
    public override int NoticeRange => 20;
    public override bool RandomMove50 => true;
    public override int Rarity => 4;
    public override int Sleep => 40;
    public override int Speed => 110;
    public override string SplitName1 => "   Lesser   ";
    public override string SplitName2 => "    wall    ";
    public override string SplitName3 => "  monster   ";
}
