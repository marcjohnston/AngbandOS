// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class BrigandMonsterRace : MonsterRace
{
    protected BrigandMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerPSymbol>();
    public override ColourEnum Colour => ColourEnum.Black;
    public override string Name => "Brigand";

    public override int ArmourClass => 32;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 2, 6),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<TouchAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<EatGoldAttackEffect>(), 0, 0),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<TouchAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<EatItemAttackEffect>(), 0, 0),
    };
    public override bool BashDoor => true;
    public override string Description => "He is eyeing your purse suspiciously.";
    public override bool Drop_1D2 => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Brigand";
    public override int Hdice => 9;
    public override int Hside => 8;
    public override int LevelFound => 10;
    public override bool Male => true;
    public override int Mexp => 35;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "  Brigand   ";
    public override bool TakeItem => true;
}