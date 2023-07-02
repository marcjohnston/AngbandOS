// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ShriekerMushroomPatchMonsterRace : MonsterRace
{
    protected ShriekerMushroomPatchMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new ShriekMonsterSpell());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<CommaSymbol>();
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "Shrieker mushroom patch";

    public override int ArmourClass => 1;
    public override MonsterAttack[]? Attacks => null;
    public override string Description => "Yum! These look quite tasty.";
    public override bool EmptyMind => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "Shrieker mushroom patch";
    public override int Hdice => 1;
    public override int Hside => 1;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 2;
    public override int Mexp => 1;
    public override bool NeverAttack => true;
    public override bool NeverMove => true;
    public override int NoticeRange => 4;
    public override int Rarity => 1;
    public override int Sleep => 0;
    public override int Speed => 110;
    public override string SplitName1 => "  Shrieker  ";
    public override string SplitName2 => "  mushroom  ";
    public override string SplitName3 => "   patch    ";
    public override bool Stupid => true;
}
