// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class KingRatMonsterRace : MonsterRace
{
    protected KingRatMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerRSymbol>();
    public override ColourEnum Colour => ColourEnum.Brown;
    public override string Name => "King Rat";

    public override bool Animal => true;
    public override int ArmourClass => 30;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<ClawAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 2),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<ClawAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 3),
    };
    public override bool BashDoor => true;
    public override string Description => "A large brown rat. He's the leader of the pack.";
    public override bool Escorted => true;
    public override bool EscortsGroup => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "King Rat";
    public override int Hdice => 5;
    public override int Hside => 5;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 2;
    public override int Mexp => 32;
    public override int NoticeRange => 30;
    public override int Rarity => 1;
    public override int Sleep => 0;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "    King    ";
    public override string SplitName3 => "    Rat     ";
    public override bool Unique => true;
}