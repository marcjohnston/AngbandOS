// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LawDrakeMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.ShardsBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.SoundBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.ConfuseMonsterSpell),
        nameof(MonsterSpellsEnum.ScareMonsterSpell),
        nameof(MonsterSpellsEnum.SlowMonsterSpell)
    };


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    public override string SymbolName => nameof(LowerDSymbol);
    public override ColorEnum Color => ColorEnum.Silver;
    
    public override int ArmorClass => 100;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 8),
        (nameof(ClawAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 8),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "This dragon is clever and cunning. It laughs at your puny efforts to disturb it.";
    public override bool Dragon => true;
    public override bool Drop_2D2 => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Law drake";
    public override bool Good => true;
    public override int Hdice => 55;
    public override int Hside => 10;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 33;
    public override int Mexp => 700;
    public override int NoticeRange => 25;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override int Sleep => 30;
    public override int Speed => 110;
    public override string? MultilineName => "Law\ndrake";
}
