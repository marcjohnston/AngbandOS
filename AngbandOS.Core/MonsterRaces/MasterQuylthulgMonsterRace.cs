// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MasterQuylthulgMonsterRace : MonsterRace
{
    protected MasterQuylthulgMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(SummonDragonMonsterSpell),
        nameof(SummonHiDragonMonsterSpell),
        nameof(SummonHiUndeadMonsterSpell),
        nameof(SummonMonsterMonsterSpell),
        nameof(SummonMonstersMonsterSpell),
        nameof(SummonUndeadMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperQSymbol);
    public override ColorEnum Color => ColorEnum.Blue;
    
    public override bool Animal => true;
    public override int ArmorClass => 1;
    public override string Description => "A pulsating mound of flesh, shining with silver pulses of throbbing light.";
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Master quylthulg";
    public override int Hdice => 20;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 71;
    public override int Mexp => 12000;
    public override bool NeverAttack => true;
    public override bool NeverMove => true;
    public override int NoticeRange => 20;
    public override int Rarity => 3;
    public override bool ResistTeleport => true;
    public override int Sleep => 0;
    public override int Speed => 120;
    public override string? MultilineName => "Master\nquylthulg";
}
