// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class HardenedWarriorMonsterRace : MonsterRace
{
    protected HardenedWarriorMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerPSymbol>();
    public override ColourEnum Colour => ColourEnum.Brown;
    public override string Name => "Hardened warrior";

    public override int ArmourClass => 40;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 3, 5),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 3, 5),
    };
    public override bool BashDoor => true;
    public override string Description => "A scarred warrior who moves with confidence.";
    public override bool Drop_1D2 => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Hardened warrior";
    public override int Hdice => 15;
    public override int Hside => 11;
    public override int LevelFound => 23;
    public override bool Male => true;
    public override int Mexp => 60;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 40;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "  Hardened  ";
    public override string SplitName3 => "  warrior   ";
    public override bool TakeItem => true;
}