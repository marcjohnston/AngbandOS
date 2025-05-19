// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class KavlaxTheManyHeadedMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.AcidBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.ColdBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.ConfusionBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.LightningBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.FireBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.GravityBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.NexusBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.ShardsBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.SoundBreatheBallMonsterSpell)
    };


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    public override string SymbolName => nameof(LowerDSymbol);
    public override ColorEnum Color => ColorEnum.Purple;
    
    public override int ArmorClass => 85;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 12),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 12),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 12),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 12)
    };
    public override bool AttrAny => true;
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override string Description => "A large dragon with a selection of heads, all shouting and arguing as they look for prey, but each with its own deadly breath weapon.";
    public override bool Dragon => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "Kavlax the Many-Headed";
    public override int Hdice => 13;
    public override int Hside => 100;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 39;
    public override bool Male => true;
    public override int Mexp => 3000;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 3;
    public override bool ResistNexus => true;
    public override int Sleep => 30;
    public override int Speed => 120;
    public override string? MultilineName => "Kavlax\nthe\nMany-Headed";
    public override bool Unique => true;
}
