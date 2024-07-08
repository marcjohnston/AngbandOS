// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class KoboldMonsterRace : MonsterRace
{
    protected KoboldMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerKSymbol);
    public override ColorEnum Color => ColorEnum.Green;
    
    public override int ArmorClass => 16;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(HurtAttackEffect), 1, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "It is a small, dog-headed humanoid.";
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Kobold";
    public override int Hdice => 3;
    public override int Hside => 7;
    public override bool ImmunePoison => true;
    public override int LevelFound => 1;
    public override int Mexp => 5;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string? MultilineName => "Kobold";
}
