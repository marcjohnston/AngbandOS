// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class DraconicQuylthulgMonsterRace : MonsterRace
{
    protected DraconicQuylthulgMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BlinkMonsterSpell),
        nameof(SummonDragonMonsterSpell),
        nameof(TeleportSelfMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperQSymbol);
    public override ColorEnum Color => ColorEnum.BrightGreen;
    public override string Name => "Draconic quylthulg";

    public override bool Animal => true;
    public override int ArmorClass => 1;
    public override string Description => "It looks like it was once a dragon corpse, now deeply infected with magical bacteria that make it pulse in a foul and degrading way.";
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Draconic quylthulg";
    public override int Hdice => 72;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 55;
    public override int Mexp => 5500;
    public override bool NeverAttack => true;
    public override bool NeverMove => true;
    public override int NoticeRange => 20;
    public override int Rarity => 3;
    public override int Sleep => 0;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "  Draconic  ";
    public override string SplitName3 => " quylthulg  ";
}
