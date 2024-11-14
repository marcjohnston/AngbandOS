// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class FlyingPolypMonsterRace : MonsterRace
{
    protected FlyingPolypMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(ConfuseMonsterSpell),
        nameof(ManaBoltMonsterSpell),
        nameof(PlasmaBoltMonsterSpell),
        nameof(HasteMonsterSpell),
        nameof(HealMonsterSpell),
        nameof(MonstersSummonMonsterSpell),
        nameof(TeleportAwayMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperASymbol);
    public override ColorEnum Color => ColorEnum.Diamond;
    
    public override int ArmorClass => 68;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(HurtAttackEffect), 4, 6),
    };
    public override bool BashDoor => true;
    public override bool Cthuloid => true;
    public override string Description => "'A horrible elder race of half polypous, utterly alien entities... Suggestions of monstrous plasticity and... lapses of visibility.' H.P.Lovecraft - 'The Shadow Out of Time'";
    public override bool Drop_1D2 => true;
    public override bool Drop_2D2 => true;
    public override bool EldritchHorror => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 11;
    public override int FreqSpell => 11;
    public override string FriendlyName => "Flying polyp";
    public override int Hdice => 50;
    public override int Hside => 10;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 38;
    public override int Mexp => 1800;
    public override bool MoveBody => true;
    public override int NoticeRange => 30;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 6;
    public override bool Reflecting => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 255;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string? MultilineName => "Flying\npolyp";
    public override bool TakeItem => true;
    public override bool WeirdMind => true;
}
