// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class CultistMonsterRace : MonsterRace
{
    protected CultistMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(CauseSeriousWoundsMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(HealMonsterSpell),
        nameof(SummonMonsterMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerPSymbol);
    public override ColorEnum Color => ColorEnum.Turquoise;
    
    public override int ArmorClass => 22;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(HurtAttackEffect), 2, 3),
        (nameof(HitAttack), nameof(HurtAttackEffect), 2, 3),
    };
    public override bool BashDoor => true;
    public override string Description => "A robed humanoid dedicated to his outer god.";
    public override bool Drop_1D2 => true;
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Cultist";
    public override bool Good => true;
    public override int Hdice => 12;
    public override int Hside => 8;
    public override int LevelFound => 12;
    public override bool Male => true;
    public override int Mexp => 36;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 40;
    public override bool Smart => true;
    public override int Speed => 110;
    public override string? MultilineName => "Cultist";
}
