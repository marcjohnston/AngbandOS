// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShadowCreatureMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(LowerHSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    
    public override int ArmorClass => 12;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 7),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 7),
    };
    public override bool BashDoor => true;
    public override string Description => "A humanoid creature with extra joints in its extremities.";
    public override bool Drop60 => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Shadow creature";
    public override bool Friends => true;
    public override int Hdice => 9;
    public override int Hside => 8;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 10;
    public override bool Male => true;
    public override int Mexp => 35;
    public override int NoticeRange => 12;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 16;
    public override int Speed => 110;
    public override string? MultilineName => "Shadow\ncreature";
}
