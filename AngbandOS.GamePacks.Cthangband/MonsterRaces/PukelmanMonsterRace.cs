// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PukelmanMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.AcidBoltMonsterSpell),
        nameof(MonsterSpellsEnum.ConfuseMonsterSpell),
        nameof(MonsterSpellsEnum.SlowMonsterSpell)
    };

    public override string SymbolName => nameof(LowerGSymbol);
    public override ColorEnum Color => ColorEnum.Brown;
    
    public override int ArmorClass => 80;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 3, 6),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 12),
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "A stumpy figure carved from stone, with glittering eyes.";
    public override bool EmptyMind => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "Pukelman";
    public override int Hdice => 80;
    public override int Hside => 12;
    public override bool HurtByRock => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 25;
    public override int Mexp => 600;
    public override int NoticeRange => 12;
    public override int Rarity => 3;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string? MultilineName => "Pukelman";
}
