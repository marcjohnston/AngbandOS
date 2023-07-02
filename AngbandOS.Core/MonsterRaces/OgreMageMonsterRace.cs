// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class OgreMageMonsterRace : MonsterRace
{
    protected OgreMageMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new ColdBallMonsterSpell(),
        new HoldMonsterSpell(),
        new CreateTrapsMonsterSpell(),
        new HealMonsterSpell(),
        new SummonMonsterMonsterSpell());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperOSymbol>();
    public override Colour Colour => Colour.Orange;
    public override string Name => "Ogre mage";

    public override int ArmourClass => 40;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 8),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 8),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 8),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 8)
    };
    public override bool BashDoor => true;
    public override string Description => "A hideous ogre wrapped in black sorcerous robes.";
    public override bool Drop_1D2 => true;
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "Ogre mage";
    public override bool Giant => true;
    public override int Hdice => 30;
    public override int Hside => 12;
    public override int LevelFound => 27;
    public override int Mexp => 300;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 30;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "    Ogre    ";
    public override string SplitName3 => "    mage    ";
}
