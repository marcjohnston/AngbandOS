// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GrandMasterThiefMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.CreateTrapsMonsterSpell)
    };

    public override string SymbolName => nameof(LowerPSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    
    public override int ArmorClass => 90;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 3, 6),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.EatGoldAttackEffect), 5, 5),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.EatItemAttackEffect), 5, 5),
    };
    public override bool BashDoor => true;
    public override string Description => "A furtive figure who makes you want to hide all your valuables.";
    public override bool Drop_1D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Grand master thief";
    public override int Hdice => 25;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 52;
    public override bool Male => true;
    public override int Mexp => 20000;
    public override int NoticeRange => 40;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override bool ResistTeleport => true;
    public override int Sleep => 0;
    public override int Speed => 140;
    public override string? MultilineName => "Grand\nmaster\nthief";
    public override bool TakeItem => true;
}
