// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MaulotaurMonsterRace : MonsterRace
{
    protected MaulotaurMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new FireBallMonsterSpell(),
        new FireBoltMonsterSpell(),
        new PlasmaBoltMonsterSpell());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperHSymbol>();
    public override Colour Colour => Colour.Brown;
    public override string Name => "Maulotaur";

    public override int ArmourClass => 50;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new ButtAttackType(), new HurtAttackEffect(), 4, 6),
        new MonsterAttack(new ButtAttackType(), new HurtAttackEffect(), 4, 6),
        new MonsterAttack(new HitAttackType(), new ShatterAttackEffect(), 5, 6),
        new MonsterAttack(new HitAttackType(), new ShatterAttackEffect(), 5, 6)
    };
    public override bool BashDoor => true;
    public override string Description => "It is a belligrent minotaur with some destructive magical arsenal, armed with a hammer.";
    public override bool Drop60 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Maulotaur";
    public override int Hdice => 250;
    public override int Hside => 10;
    public override bool ImmuneFire => true;
    public override int LevelFound => 50;
    public override int Mexp => 4500;
    public override int NoticeRange => 13;
    public override bool OnlyDropItem => true;
    public override int Rarity => 2;
    public override bool ResistTeleport => true;
    public override int Sleep => 10;
    public override int Speed => 130;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => " Maulotaur  ";
    public override bool Stupid => true;
}
