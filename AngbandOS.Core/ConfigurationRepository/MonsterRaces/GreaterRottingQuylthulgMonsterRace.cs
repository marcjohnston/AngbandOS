// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GreaterRottingQuylthulgMonsterRace : MonsterRace
{
    protected GreaterRottingQuylthulgMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BlinkMonsterSpell),
        nameof(SummonHiUndeadMonsterSpell),
        nameof(TeleportToMonsterSpell)
    };

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UpperQSymbol));
    public override ColorEnum Color => ColorEnum.Brown;
    public override string Name => "Greater rotting quylthulg";

    public override bool Animal => true;
    public override int ArmorClass => 1;
    public override MonsterAttack[]? Attacks => null;
    public override string Description => "A massive pile of rotting flesh. A disgusting stench fills the air as it throbs and writhes.";
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Greater rotting quylthulg";
    public override int Hdice => 15;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 71;
    public override int Mexp => 10500;
    public override bool NeverAttack => true;
    public override bool NeverMove => true;
    public override int NoticeRange => 20;
    public override int Rarity => 3;
    public override bool ResistTeleport => true;
    public override int Sleep => 0;
    public override int Speed => 120;
    public override string SplitName1 => "  Greater   ";
    public override string SplitName2 => "  rotting   ";
    public override string SplitName3 => " quylthulg  ";
}
