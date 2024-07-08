// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class NightwalkerMonsterRace : MonsterRace
{
    protected NightwalkerMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BlindnessMonsterSpell),
        nameof(BrainSmashMonsterSpell),
        nameof(ManaBoltMonsterSpell),
        nameof(NetherBallMonsterSpell),
        nameof(NetherBoltMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(SummonUndeadMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerZSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    
    public override int ArmorClass => 175;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(DisenchantAttackEffect), 10, 10),
        (nameof(HitAttack), nameof(DisenchantAttackEffect), 10, 10),
        (nameof(HitAttack), nameof(DisenchantAttackEffect), 7, 7),
        (nameof(HitAttack), nameof(DisenchantAttackEffect), 7, 7)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "A huge giant garbed in black, more massive than a titan and stronger than a dragon. With terrible blows, it breaks your armor from your back, leaving you defenseless against its evil wrath. It can smell your fear, and you in turn smell the awful stench of death as this ghastly figure strides towards you menacingly.";
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "Nightwalker";
    public override int Hdice => 50;
    public override int Hside => 65;
    public override bool HurtByLight => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 59;
    public override int Mexp => 15000;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 4;
    public override bool ResistTeleport => true;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 130;
    public override string? MultilineName => "Nightwalker";
    public override bool Undead => true;
}
