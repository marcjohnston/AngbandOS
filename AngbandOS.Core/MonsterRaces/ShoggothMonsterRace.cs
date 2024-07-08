// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ShoggothMonsterRace : MonsterRace
{
    protected ShoggothMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(UpperASymbol);
    public override ColorEnum Color => ColorEnum.Black;
    
    public override int ArmorClass => 80;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(CrushAttack), nameof(AcidAttackEffect), 5, 6),
        (nameof(CrushAttack), nameof(AcidAttackEffect), 5, 6),
        (nameof(CrushAttack), nameof(AcidAttackEffect), 5, 6),
        (nameof(CrushAttack), nameof(HurtAttackEffect), 6, 6)
    };
    public override bool BashDoor => true;
    public override bool Cthuloid => true;
    public override string Description => "A nightmarish fetid, black irididescence oozing towards you.";
    public override bool Drop_2D2 => true;
    public override bool Drop60 => true;
    public override bool Drop90 => true;
    public override bool EldritchHorror => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Shoggoth";
    public override int Hdice => 50;
    public override int Hside => 20;
    public override bool HurtByLight => true;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool KillBody => true;
    public override bool KillItem => true;
    public override int LevelFound => 41;
    public override int Mexp => 2500;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool Powerful => true;
    public override int Rarity => 2;
    public override bool Regenerate => true;
    public override bool ResistPlasma => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 20;
    public override int Speed => 140;
    public override string? MultilineName => "Shoggoth";
}
