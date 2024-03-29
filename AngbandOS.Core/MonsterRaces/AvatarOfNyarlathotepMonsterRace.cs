// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class AvatarOfNyarlathotepMonsterRace : MonsterRace
{
    protected AvatarOfNyarlathotepMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerPSymbol);
    public override ColorEnum Color => ColorEnum.BrightRed;
    
    public override int ArmorClass => 70;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 5, 5),
        new MonsterAttackDefinition(nameof(HitAttack), nameof(HurtAttackEffect), 5, 5),
    };
    public override bool BashDoor => true;
    public override bool Cthuloid => true;
    public override string Description => "The Crawling Chaos with 1000 forms. Nyarlathotep is amused at yourpuny attempts to kill him, and will keep coming back for another go, until he gets bored with the game.";
    public override bool EldritchHorror => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Avatar of Nyarlathotep";
    public override int Hdice => 25;
    public override int Hside => 25;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 45;
    public override bool Male => true;
    public override int Mexp => 500;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override bool Shapechanger => true;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string? MultilineName => "Avatar\nof\nNyarlathotep";
}
