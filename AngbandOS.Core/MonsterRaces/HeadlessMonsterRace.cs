// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class HeadlessMonsterRace : MonsterRace
{
    protected HeadlessMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(ScareMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperHSymbol);
    public override ColorEnum Color => ColorEnum.BrightGreen;
    
    public override int ArmorClass => 50;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(HurtAttackEffect), 1, 8),
        (nameof(HitAttack), nameof(HurtAttackEffect), 1, 8),
    };
    public override bool BashDoor => true;
    public override string Description => "Headless humanoid abominations created by a magical mutation.";
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Headless";
    public override bool Friends => true;
    public override int Hdice => 21;
    public override int Hside => 12;
    public override int LevelFound => 27;
    public override int Mexp => 175;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 40;
    public override int Speed => 110;
    public override string? MultilineName => "Headless";
}
