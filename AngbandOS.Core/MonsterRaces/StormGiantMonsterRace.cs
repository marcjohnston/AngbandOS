// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class StormGiantMonsterRace : MonsterRace
{
    protected StormGiantMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(ConfuseMonsterSpell),
        nameof(LightningBallMonsterSpell),
        nameof(LightningBoltMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(BlinkMonsterSpell),
        nameof(TeleportToMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperPSymbol);
    public override ColorEnum Color => ColorEnum.BrightTurquoise;
    
    public override int ArmorClass => 60;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(ElectricityAttackEffect), 3, 8),
        (nameof(HitAttack), nameof(HurtAttackEffect), 3, 8),
        (nameof(HitAttack), nameof(HurtAttackEffect), 3, 8),
    };
    public override bool BashDoor => true;
    public override string Description => "It is a twenty-five foot tall giant wreathed in lighting.";
    public override bool Drop_1D2 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 8;
    public override int FreqSpell => 8;
    public override string FriendlyName => "Storm giant";
    public override bool Giant => true;
    public override int Hdice => 38;
    public override int Hside => 10;
    public override bool ImmuneCold => true;
    public override bool ImmuneLightning => true;
    public override int LevelFound => 32;
    public override bool LightningAura => true;
    public override bool Male => true;
    public override int Mexp => 1500;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 40;
    public override int Speed => 110;
    public override string? MultilineName => "Storm\ngiant";
    public override bool TakeItem => true;
}
