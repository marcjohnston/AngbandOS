// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class KillerIridescentBeetleMonsterRace : MonsterRace
{
    protected KillerIridescentBeetleMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperKSymbol>();
    public override ColourEnum Colour => ColourEnum.Pink;
    public override string Name => "Killer iridescent beetle";

    public override bool Animal => true;
    public override int ArmourClass => 60;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<ClawAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<ElectricityAttackEffect>(), 1, 12),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<ClawAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<ElectricityAttackEffect>(), 1, 12),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<GazeAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<ParalyzeAttackEffect>(), 0, 0),
    };
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override string Description => "It is a giant beetle, whose carapace shimmers with vibrant energies.";
    public override bool ForceMaxHp => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Killer iridescent beetle";
    public override int Hdice => 25;
    public override int Hside => 10;
    public override bool ImmuneLightning => true;
    public override int LevelFound => 37;
    public override bool LightningAura => true;
    public override int Mexp => 850;
    public override int NoticeRange => 16;
    public override int Rarity => 2;
    public override int Sleep => 30;
    public override int Speed => 110;
    public override string SplitName1 => "   Killer   ";
    public override string SplitName2 => " iridescent ";
    public override string SplitName3 => "   beetle   ";
    public override bool WeirdMind => true;
}