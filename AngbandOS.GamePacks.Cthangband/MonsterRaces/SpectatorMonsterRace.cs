// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpectatorMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.CauseSeriousWoundsMonsterSpell),
        nameof(MonsterSpellsEnum.HoldMonsterSpell),
        nameof(MonsterSpellsEnum.SlowMonsterSpell),
        nameof(MonsterSpellsEnum.ForgetMonsterSpell)
    };

    public override string SymbolName => nameof(LowerESymbol);
    public override ColorEnum Color => ColorEnum.BrightGreen;
    
    public override int ArmorClass => 1;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(GazeAttack), nameof(AttackEffectsEnum.ParalyzeAttackEffect), 1, 4),
        (nameof(GazeAttack), nameof(AttackEffectsEnum.ConfuseAttackEffect), 1, 4),
        (nameof(GazeAttack), nameof(AttackEffectsEnum.DisenchantAttackEffect), 0, 0),
    };
    public override string Description => "It has three small eyestalks and a large central eye.";
    public override bool EmptyMind => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Spectator";
    public override int Hdice => 10;
    public override int Hside => 13;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 32;
    public override int Mexp => 150;
    public override int NoticeRange => 30;
    public override int Rarity => 3;
    public override int Sleep => 5;
    public override int Speed => 110;
    public override string? MultilineName => "Spectator";
    public override bool Stupid => true;
}
