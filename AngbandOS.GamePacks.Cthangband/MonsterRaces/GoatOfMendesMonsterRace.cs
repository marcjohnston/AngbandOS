// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GoatOfMendesMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.BlindnessMonsterSpell),
        nameof(MonsterSpellsEnum.BrainSmashMonsterSpell),
        nameof(MonsterSpellsEnum.CauseMortalWoundsMonsterSpell),
        nameof(MonsterSpellsEnum.ColdBallMonsterSpell),
        nameof(MonsterSpellsEnum.ConfuseMonsterSpell),
        nameof(MonsterSpellsEnum.DrainManaMonsterSpell),
        nameof(MonsterSpellsEnum.NetherBallMonsterSpell),
        nameof(MonsterSpellsEnum.ScareMonsterSpell),
        nameof(MonsterSpellsEnum.ForgetMonsterSpell),
        nameof(MonsterSpellsEnum.DemonSummonMonsterSpell),
        nameof(MonsterSpellsEnum.UndeadSummonMonsterSpell)
    };

    public override string SymbolName => nameof(LowerQSymbol);
    public override ColorEnum Color => ColorEnum.Red;
    
    public override int ArmorClass => 66;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(GazeAttack), nameof(AttackEffectsEnum.TerrifyAttackEffect), 0, 0),
        (nameof(ButtAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 6, 6),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.Exp40AttackEffect), 0, 0),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.LoseConAttackEffect), 0, 0)
    };
    public override bool BashDoor => true;
    public override bool Demon => true;
    public override string Description => "It is a demonic creature from the lowest hell, vaguely resembling a large black he-goat.";
    public override bool Drop_2D2 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "Goat of Mendes";
    public override int Hdice => 18;
    public override int Hside => 111;
    public override bool HurtByLight => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 50;
    public override int Mexp => 6666;
    public override bool MoveBody => true;
    public override bool Nonliving => true;
    public override int NoticeRange => 30;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 3;
    public override int Sleep => 40;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string? MultilineName => "Goat\nof\nMendes";
}
