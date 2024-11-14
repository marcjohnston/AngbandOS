// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class DracolichMonsterRace : MonsterRace
{
    protected DracolichMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(ColdBreatheBallMonsterSpell),
        nameof(NetherBreatheBallMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(ScareMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperDSymbol);
    public override ColorEnum Color => ColorEnum.BrightBeige;
    
    public override int ArmorClass => 120;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(HurtAttackEffect), 4, 12),
        (nameof(ClawAttack), nameof(HurtAttackEffect), 4, 12),
        (nameof(BiteAttack), nameof(Exp80AttackEffect), 3, 6),
        (nameof(BiteAttack), nameof(Exp80AttackEffect), 3, 6)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "The skeletal form of a once-great dragon, enchanted by magic most perilous. Its animated form strikes with speed and drains life from its prey to satisfy its hunger.";
    public override bool Dragon => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Dracolich";
    public override int Hdice => 35;
    public override int Hside => 100;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 46;
    public override int Mexp => 18000;
    public override bool MoveBody => true;
    public override int NoticeRange => 25;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 2;
    public override bool ResistTeleport => true;
    public override int Sleep => 30;
    public override int Speed => 120;
    public override string? MultilineName => "Dracolich";
    public override bool TakeItem => true;
    public override bool Undead => true;
}
