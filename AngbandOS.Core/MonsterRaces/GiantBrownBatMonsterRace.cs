// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GiantBrownBatMonsterRace : MonsterRace
{
    protected GiantBrownBatMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => 'b';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Giant brown bat";

    public override bool Animal => true;
    public override int ArmourClass => 15;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 3),
    };
    public override string Description => "It screeches as it attacks.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Giant brown bat";
    public override int Hdice => 3;
    public override int Hside => 8;
    public override int LevelFound => 6;
    public override int Mexp => 10;
    public override int NoticeRange => 10;
    public override bool RandomMove50 => true;
    public override int Rarity => 1;
    public override int Sleep => 30;
    public override int Speed => 130;
    public override string SplitName1 => "   Giant    ";
    public override string SplitName2 => "   brown    ";
    public override string SplitName3 => "    bat     ";
}
