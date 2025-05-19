// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FireHoundMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.FireBreatheBallMonsterSpell)
    };

    public override string SymbolName => nameof(UpperZSymbol);
    public override ColorEnum Color => ColorEnum.Red;
    
    public override bool Animal => true;
    public override int ArmorClass => 30;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(AttackEffectsEnum.FireAttackEffect), 1, 3),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.FireAttackEffect), 1, 3),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.FireAttackEffect), 1, 3),
    };
    public override bool BashDoor => true;
    public override string Description => "Flames lick at its feet and its tongue is a blade of fire. You can feel a furnace heat radiating from the creature.";
    public override bool ForceSleep => true;
    public override int FreqInate => 10;
    public override int FreqSpell => 10;
    public override string FriendlyName => "Fire hound";
    public override bool Friends => true;
    public override int Hdice => 10;
    public override int Hside => 6;
    public override bool ImmuneFire => true;
    public override int LevelFound => 18;
    public override int Mexp => 70;
    public override int NoticeRange => 30;
    public override int Rarity => 1;
    public override int Sleep => 0;
    public override int Speed => 110;
    public override string? MultilineName => "Fire\nhound";
}
