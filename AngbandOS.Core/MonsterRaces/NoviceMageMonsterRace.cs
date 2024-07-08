// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class NoviceMageMonsterRace : MonsterRace
{
    protected NoviceMageMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BlindnessMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(MagicMissileMonsterSpell),
        nameof(BlinkMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerPSymbol);
    public override ColorEnum Color => ColorEnum.BrightRed;
    
    public override int ArmorClass => 6;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(HurtAttackEffect), 1, 4),
    };
    public override bool BashDoor => true;
    public override string Description => "He is leaving behind a trail of dropped spell components.";
    public override bool Drop60 => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 12;
    public override int FreqSpell => 12;
    public override string FriendlyName => "Novice mage";
    public override int Hdice => 6;
    public override int Hside => 4;
    public override int LevelFound => 2;
    public override bool Male => true;
    public override int Mexp => 7;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 5;
    public override int Speed => 110;
    public override string? MultilineName => "Novice\nmage";
}
