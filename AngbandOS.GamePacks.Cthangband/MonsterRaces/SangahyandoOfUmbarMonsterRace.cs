// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SangahyandoOfUmbarMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.SlowMonsterSpell),
        nameof(MonsterSpellsEnum.ForgetMonsterSpell)
    };

    public override string SymbolName => nameof(LowerPSymbol);
    public override ColorEnum Color => ColorEnum.Orange;
    
    public override int ArmorClass => 80;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 4, 6),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 4, 6),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 4, 6),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 4, 6)
    };
    public override bool BashDoor => true;
    public override string Description => "A Black Numenorean with a blacker heart.";
    public override bool Drop_1D2 => true;
    public override bool Drop90 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "Sangahyando of Umbar";
    public override int Hdice => 80;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 24;
    public override bool Male => true;
    public override int Mexp => 400;
    public override int NoticeRange => 25;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 25;
    public override int Speed => 110;
    public override string? MultilineName => "Sangahyando\nof\nUmbar";
    public override bool Unique => true;
}
