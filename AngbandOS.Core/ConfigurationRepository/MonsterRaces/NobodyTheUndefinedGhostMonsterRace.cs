// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class NobodyTheUndefinedGhostMonsterRace : MonsterRace
{
    protected NobodyTheUndefinedGhostMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperGSymbol>();
    public override string Name => "Nobody, the Undefined Ghost";

    public override int ArmourClass => 0;
    public override MonsterAttack[]? Attacks => null;
    public override string Description => "It seems strangely familiar...";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Nobody, the Undefined Ghost";
    public override int Hdice => 1;
    public override int Hside => 1;
    public override int LevelFound => 127;
    public override int Mexp => 1;
    public override bool NeverAttack => true;
    public override bool NeverMove => true;
    public override int NoticeRange => 0;
    public override int Rarity => 0;
    public override int Sleep => 0;
    public override int Speed => 0;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "   Nobody   ";
    public override bool Unique => true;
}