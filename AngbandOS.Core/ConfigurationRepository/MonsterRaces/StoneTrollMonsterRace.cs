// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class StoneTrollMonsterRace : MonsterRace
{
    protected StoneTrollMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperTSymbol>();
    public override ColourEnum Colour => ColourEnum.Black;
    public override string Name => "Stone troll";

    public override int ArmourClass => 40;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 6),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 6),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<BiteAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 3, 4),
    };
    public override bool BashDoor => true;
    public override string Description => "He is a giant troll with scabrous black skin.";
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Stone troll";
    public override bool Friends => true;
    public override int Hdice => 23;
    public override int Hside => 10;
    public override bool HurtByLight => true;
    public override bool HurtByRock => true;
    public override int LevelFound => 25;
    public override bool Male => true;
    public override int Mexp => 85;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 50;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Stone    ";
    public override string SplitName3 => "   troll    ";
    public override bool Troll => true;
}