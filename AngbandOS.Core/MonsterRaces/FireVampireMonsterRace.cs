// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class FireVampireMonsterRace : MonsterRace
{
    protected FireVampireMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BlinkMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperASymbol);
    public override ColorEnum Color => ColorEnum.Red;
    
    public override int ArmorClass => 6;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(TouchAttack), nameof(FireAttackEffect), 1, 4),
    };
    public override bool BashDoor => true;
    public override bool Cthuloid => true;
    public override string Description => "A burning point of light, floating through the air and flickering with sinister purpose.";
    public override bool FireAura => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Fire vampire";
    public override bool Friends => true;
    public override int Hdice => 2;
    public override int Hside => 5;
    public override bool ImmuneFire => true;
    public override int LevelFound => 14;
    public override int Mexp => 23;
    public override int NoticeRange => 8;
    public override bool RandomMove50 => true;
    public override int Rarity => 2;
    public override int Sleep => 6;
    public override int Speed => 120;
    public override string? MultilineName => "Fire\nvampire";
}
