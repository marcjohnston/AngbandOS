// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class RavingLunaticMonsterRace : MonsterRace
{
    protected RavingLunaticMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerTSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightGreen;
    public override string Name => "Raving lunatic";

    public override int ArmourClass => 1;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<DroolAttack>(), null, 0, 0),
    };
    public override string Description => "Drooling and comical, but then, what do you expect?";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Raving lunatic";
    public override int Hdice => 4;
    public override int Hside => 4;
    public override int LevelFound => 0;
    public override bool Male => true;
    public override int Mexp => 0;
    public override int NoticeRange => 6;
    public override bool RandomMove25 => true;
    public override int Rarity => 1;
    public override int Sleep => 0;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Raving   ";
    public override string SplitName3 => "  lunatic   ";
    public override bool TakeItem => true;
}