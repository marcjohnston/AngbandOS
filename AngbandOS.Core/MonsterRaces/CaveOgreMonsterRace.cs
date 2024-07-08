// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class CaveOgreMonsterRace : MonsterRace
{
    protected CaveOgreMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(UpperOSymbol);
    public override ColorEnum Color => ColorEnum.Brown;
    
    public override int ArmorClass => 33;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(HurtAttackEffect), 3, 8),
        (nameof(HitAttack), nameof(HurtAttackEffect), 3, 8),
    };
    public override bool BashDoor => true;
    public override string Description => "A giant orc-like figure with an awesomely muscled frame.";
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Cave ogre";
    public override bool Friends => true;
    public override bool Giant => true;
    public override int Hdice => 30;
    public override int Hside => 9;
    public override int LevelFound => 26;
    public override int Mexp => 42;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 30;
    public override int Speed => 110;
    public override string? MultilineName => "Cave\nogre";
}
