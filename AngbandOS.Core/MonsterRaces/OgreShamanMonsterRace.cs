// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class OgreShamanMonsterRace : MonsterRace
{
    protected OgreShamanMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(CauseSeriousWoundsMonsterSpell),
        nameof(FireBoltMonsterSpell),
        nameof(HoldMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(CreateTrapsMonsterSpell),
        nameof(MonsterSummonMonsterSpell),
        nameof(TeleportSelfMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperOSymbol);
    public override ColorEnum Color => ColorEnum.Blue;
    
    public override int ArmorClass => 55;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(HurtAttackEffect), 3, 6),
        (nameof(HitAttack), nameof(HurtAttackEffect), 3, 6),
        (nameof(HitAttack), nameof(HurtAttackEffect), 3, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "It is an ogre wrapped in furs and covered in grotesque body paints.";
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Ogre shaman";
    public override bool Giant => true;
    public override int Hdice => 14;
    public override int Hside => 10;
    public override int LevelFound => 32;
    public override int Mexp => 250;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 30;
    public override int Speed => 110;
    public override string? MultilineName => "Ogre\nshaman";
}
