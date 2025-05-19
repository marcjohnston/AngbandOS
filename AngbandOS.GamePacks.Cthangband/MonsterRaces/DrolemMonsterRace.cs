// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DrolemMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.Arrow5D6MonsterSpell),
        nameof(MonsterSpellsEnum.PoisonBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.BlindnessMonsterSpell),
        nameof(MonsterSpellsEnum.ConfuseMonsterSpell),
        nameof(MonsterSpellsEnum.SlowMonsterSpell)
    };

    public override string SymbolName => nameof(LowerGSymbol);
    public override ColorEnum Color => ColorEnum.Green;
    
    public override int ArmorClass => 130;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 5, 8),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 5, 8),
        (nameof(ClawAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 3, 3),
        (nameof(ClawAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 3, 3)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "A constructed dragon, the drolem has massive strength. Powerful spells weaved during its creation make it a fearsome adversary. Its eyes show little intelligence, but it has been instructed to destroy all it meets.";
    public override bool Dragon => true;
    public override bool EmptyMind => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Drolem";
    public override int Hdice => 30;
    public override int Hside => 100;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 44;
    public override int Mexp => 12000;
    public override bool Nonliving => true;
    public override int NoticeRange => 25;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override bool ResistTeleport => true;
    public override int Sleep => 30;
    public override int Speed => 120;
    public override string? MultilineName => "Drolem";
}
