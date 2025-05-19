// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TheLerneanHydraMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.FireBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.PoisonBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.FireBallMonsterSpell),
        nameof(MonsterSpellsEnum.FireBoltMonsterSpell),
        nameof(MonsterSpellsEnum.PlasmaBoltMonsterSpell),
        nameof(MonsterSpellsEnum.PoisonBallMonsterSpell),
        nameof(MonsterSpellsEnum.ScareMonsterSpell),
        nameof(MonsterSpellsEnum.HydraSummonMonsterSpell)
    };

    public override string SymbolName => nameof(UpperMSymbol);
    public override ColorEnum Color => ColorEnum.BrightTurquoise;
    
    public override bool Animal => true;
    public override int ArmorClass => 140;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 8, 6),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 8, 6),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.FireAttackEffect), 12, 6),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.FireAttackEffect), 12, 6)
    };
    public override bool BashDoor => true;
    public override string Description => "A massive legendary hydra. It has twelve powerful heads. Its many eyes stare at you as clouds of smoke and poisonous vapour rise from its seething form.";
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "The Lernean Hydra";
    public override int Hdice => 45;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool KillBody => true;
    public override int LevelFound => 55;
    public override int Mexp => 20000;
    public override int NoticeRange => 20;
    public override bool OnlyDropGold => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 2;
    public override int Sleep => 20;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string? MultilineName => "The\nLernean\nHydra";
    public override bool Unique => true;
}
