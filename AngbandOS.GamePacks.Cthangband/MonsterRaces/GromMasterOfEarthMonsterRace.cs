// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GromMasterOfEarthMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.AcidBallMonsterSpell),
        nameof(MonsterSpellsEnum.AcidBoltMonsterSpell)
    };

    public override string SymbolName => nameof(UpperESymbol);
    public override ColorEnum Color => ColorEnum.Brown;
    
    public override int ArmorClass => 97;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 6, 6),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 6, 6),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 6, 6),
        (nameof(HitAttack), nameof(AttackEffectsEnum.ShatterAttackEffect), 10, 10)
    };
    public override bool ColdBlood => true;
    public override string Description => "A towering stone elemental stands before you. The walls and ceiling are reduced to rubble as Grom advances.";
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Grom, Master of Earth";
    public override int Hdice => 18;
    public override int Hside => 100;
    public override bool HurtByRock => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool KillBody => true;
    public override bool KillItem => true;
    public override bool KillWall => true;
    public override int LevelFound => 43;
    public override bool Male => true;
    public override int Mexp => 6000;
    public override int NoticeRange => 10;
    public override bool PassWall => true;
    public override bool Powerful => true;
    public override int Rarity => 4;
    public override int Sleep => 90;
    public override int Speed => 110;
    public override string? MultilineName => "Grom";
    public override bool Unique => true;
}
