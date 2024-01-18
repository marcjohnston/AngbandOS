// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class BlackOgreMonsterRace : MonsterRace
{
    protected BlackOgreMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UpperOSymbol));
    public override ColourEnum Colour => ColourEnum.Black;
    public override string Name => "Black ogre";

    public override int ArmourClass => 33;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(HitAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 2, 8),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(HitAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 2, 8),
    };
    public override bool BashDoor => true;
    public override string Description => "A massive orc-like figure with black skin and powerful arms.";
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Black ogre";
    public override bool Friends => true;
    public override bool Giant => true;
    public override int Hdice => 20;
    public override int Hside => 9;
    public override int LevelFound => 15;
    public override int Mexp => 75;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override bool RandomMove25 => true;
    public override int Rarity => 2;
    public override int Sleep => 30;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Black    ";
    public override string SplitName3 => "    ogre    ";
}
