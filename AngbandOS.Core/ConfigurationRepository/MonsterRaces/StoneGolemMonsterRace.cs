// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class StoneGolemMonsterRace : MonsterRace
{
    protected StoneGolemMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerGSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightBrown;
    public override string Name => "Stone golem";

    public override int ArmourClass => 75;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 10),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 10),
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "It is a massive animated statue.";
    public override bool EmptyMind => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Stone golem";
    public override int Hdice => 28;
    public override int Hside => 8;
    public override bool HurtByRock => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 19;
    public override int Mexp => 100;
    public override bool Nonliving => true;
    public override int NoticeRange => 12;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 100;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Stone    ";
    public override string SplitName3 => "   golem    ";
}