// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChaosGhostMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.BlindnessMonsterSpell),
        nameof(MonsterSpellsEnum.DrainManaMonsterSpell),
        nameof(MonsterSpellsEnum.HoldMonsterSpell),
        nameof(MonsterSpellsEnum.ForgetMonsterSpell)
    };

    public override string SymbolName => nameof(UpperGSymbol);
    public override ColorEnum Color => ColorEnum.Purple;
    
    public override int ArmorClass => 30;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(WailAttack), nameof(AttackEffectsEnum.TerrifyAttackEffect), 0, 0),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.Exp40AttackEffect), 0, 0),
        (nameof(ClawAttack), nameof(AttackEffectsEnum.LoseIntAttackEffect), 1, 10),
    };
    public override bool AttrAny => true;
    public override bool AttrMulti => true;
    public override bool ColdBlood => true;
    public override string Description => "An almost life-like creature which is nothing more than a phantom created by the chaos.";
    public override bool Drop_2D2 => true;
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 16;
    public override int FreqSpell => 16;
    public override string FriendlyName => "Chaos ghost";
    public override int Hdice => 14;
    public override int Hside => 20;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 33;
    public override int Mexp => 350;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool PassWall => true;
    public override bool RandomMove25 => true;
    public override int Rarity => 3;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string? MultilineName => "Chaos\nghost";
    public override bool TakeItem => true;
    public override bool Undead => true;
}
