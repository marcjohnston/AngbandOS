// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MageMonsterRace : MonsterRace
{
    protected MageMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new BlindnessMonsterSpell(),
        new ColdBoltMonsterSpell(),
        new ConfuseMonsterSpell(),
        new FireBoltMonsterSpell(),
        new LightningBoltMonsterSpell(),
        new HasteMonsterSpell(),
        new SummonMonsterMonsterSpell(),
        new TeleportToMonsterSpell(),
        new TeleportSelfMonsterSpell());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerPSymbol>();
    public override ColourEnum Colour => ColourEnum.Red;
    public override string Name => "Mage";

    public override int ArmourClass => 40;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 2, 5),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 2, 5),
    };
    public override bool BashDoor => true;
    public override string Description => "A fat mage with glasses.";
    public override bool Drop_1D2 => true;
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Mage";
    public override int Hdice => 15;
    public override int Hside => 8;
    public override int LevelFound => 28;
    public override bool Male => true;
    public override int Mexp => 150;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "    Mage    ";
}
