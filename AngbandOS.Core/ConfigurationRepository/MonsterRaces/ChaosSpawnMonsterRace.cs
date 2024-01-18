// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ChaosSpawnMonsterRace : MonsterRace
{
    protected ChaosSpawnMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(LowerESymbol));
    public override ColourEnum Colour => ColourEnum.Purple;
    public override string Name => "Chaos spawn";

    public override int ArmourClass => 50;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<GazeAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<ParalyzeAttackEffect>(), 0, 0),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<GazeAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<UnBonusAttackEffect>(), 0, 0),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<GazeAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<Exp40AttackEffect>(), 0, 0),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<GazeAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 10, 6)
    };
    public override bool BashDoor => true;
    public override string Description => "It has two eyestalks and a large central eye. Its gaze can kill.";
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Chaos spawn";
    public override int Hdice => 20;
    public override int Hside => 18;
    public override int LevelFound => 36;
    public override int Mexp => 600;
    public override int NoticeRange => 20;
    public override int Rarity => 2;
    public override int Sleep => 20;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Chaos    ";
    public override string SplitName3 => "   spawn    ";
}
