// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GapingMawMonsterRace : MonsterRace
{
    protected GapingMawMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<PeriodSymbol>();
    public override string Name => "Gaping Maw";

    public override int ArmourClass => 14;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<TerrifyAttackEffect>(), 1, 4),
    };
    public override string Description => "A hole in the fabric of reality, leading to who knows what plane... ";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Gaping Maw";
    public override int Hdice => 21;
    public override int Hside => 8;
    public override bool ImmuneAcid => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 8;
    public override int Mexp => 28;
    public override bool Nonliving => true;
    public override int NoticeRange => 30;
    public override bool PassWall => true;
    public override int Rarity => 2;
    public override int Sleep => 20;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Gaping   ";
    public override string SplitName3 => "    Maw     ";
}