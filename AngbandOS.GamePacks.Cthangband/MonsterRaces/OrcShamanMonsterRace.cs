// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class OrcShamanMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.CauseLightWoundsMonsterSpell),
        nameof(MonsterSpellsEnum.MagicMissileMonsterSpell),
        nameof(MonsterSpellsEnum.BlinkMonsterSpell)
    };

    public override string SymbolName => nameof(LowerOSymbol);
    public override ColorEnum Color => ColorEnum.Blue;
    
    public override int ArmorClass => 15;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 6),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "An orc dressed in skins who gestures wildly.";
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 8;
    public override int FreqSpell => 8;
    public override string FriendlyName => "Orc shaman";
    public override int Hdice => 9;
    public override int Hside => 8;
    public override bool HurtByLight => true;
    public override int LevelFound => 9;
    public override bool Male => true;
    public override int Mexp => 30;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override bool Orc => true;
    public override int Rarity => 1;
    public override int Sleep => 20;
    public override int Speed => 110;
    public override string? MultilineName => "Orc\nshaman";
}
