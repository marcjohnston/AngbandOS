// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class StoneGiantMonsterRace : MonsterRace
{
    protected StoneGiantMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperPSymbol>();
    public override ColourEnum Colour => ColourEnum.Grey;
    public override string Name => "Stone giant";

    public override int ArmourClass => 75;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 8),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 8),
    };
    public override bool BashDoor => true;
    public override string Description => "It is eighteen feet tall and looking at you.";
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Stone giant";
    public override bool Giant => true;
    public override int Hdice => 24;
    public override int Hside => 8;
    public override int LevelFound => 18;
    public override bool Male => true;
    public override int Mexp => 90;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 50;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Stone    ";
    public override string SplitName3 => "   giant    ";
    public override bool TakeItem => true;
}
