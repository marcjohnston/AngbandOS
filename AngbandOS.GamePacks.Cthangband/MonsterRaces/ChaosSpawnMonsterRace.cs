// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChaosSpawnMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(LowerESymbol);
    public override ColorEnum Color => ColorEnum.Purple;
    
    public override int ArmorClass => 50;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(GazeAttack), nameof(AttackEffectsEnum.ParalyzeAttackEffect), 0, 0),
        (nameof(GazeAttack), nameof(AttackEffectsEnum.DisenchantAttackEffect), 0, 0),
        (nameof(GazeAttack), nameof(AttackEffectsEnum.Exp40AttackEffect), 0, 0),
        (nameof(GazeAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 10, 6)
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
    public override string? MultilineName => "Chaos\nspawn";
}
