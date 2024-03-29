// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ShadowDemonMonsterRace : MonsterRace
{
    protected ShadowDemonMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(NetherBoltMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperGSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    
    public override int ArmorClass => 30;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(TouchAttack), nameof(Exp80AttackEffect), 0, 0),
        new MonsterAttackDefinition(nameof(TouchAttack), nameof(Exp40AttackEffect), 0, 0),
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(LoseIntAttackEffect), 1, 10),
        new MonsterAttackDefinition(nameof(ClawAttack), nameof(LoseWisAttackEffect), 1, 10)
    };
    public override bool ColdBlood => true;
    public override bool Demon => true;
    public override string Description => "A mighty spirit of darkness of vaguely humanoid form. Razor-edged claws reach out to end your life as it glides towards you, seeking to suck the energy from your soul to feed its power.";
    public override bool Drop_1D2 => true;
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 8;
    public override int FreqSpell => 8;
    public override string FriendlyName => "Shadow demon";
    public override bool Friends => true;
    public override int Hdice => 10;
    public override int Hside => 20;
    public override bool HurtByLight => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 42;
    public override int Mexp => 425;
    public override int NoticeRange => 30;
    public override bool OnlyDropItem => true;
    public override bool PassWall => true;
    public override bool Powerful => true;
    public override int Rarity => 3;
    public override bool Regenerate => true;
    public override bool ResistNether => true;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string? MultilineName => "Shadow\ndemon";
    public override bool Undead => true;
}
