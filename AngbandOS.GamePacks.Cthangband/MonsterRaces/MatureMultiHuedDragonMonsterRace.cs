// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MatureMultiHuedDragonMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.AcidBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.ColdBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.LightningBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.FireBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.PoisonBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.BlindnessMonsterSpell),
        nameof(MonsterSpellsEnum.ConfuseMonsterSpell),
        nameof(MonsterSpellsEnum.ScareMonsterSpell)
    };


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    public override string SymbolName => nameof(LowerDSymbol);
    public override ColorEnum Color => ColorEnum.Purple;
    
    public override int ArmorClass => 65;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 10),
        (nameof(ClawAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 10),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 12),
    };
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override string Description => "A large dragon, scales shimmering many colors.";
    public override bool Dragon => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Mature multi-hued dragon";
    public override int Hdice => 64;
    public override int Hside => 10;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 38;
    public override int Mexp => 1700;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 50;
    public override int Speed => 110;
    public override string? MultilineName => "Mature\nmulti-hued\ndragon";
}
