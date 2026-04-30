// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class Bonuses : IGameSerialize
{
    #region State Data
    public int AttackBonus { get; init; } = 0;
    public int DamageBonus { get; init; } = 0;
    public int DisplayedAttackBonus { get; init; } = 0;
    public int DisplayedDamageBonus { get; init; } = 0;
    public bool HasUnpriestlyWeapon { get; init; } = false;
    public bool HasHeavyBow { get; init; } = false;
    public bool HasHeavyWeapon { get; init; } = false;
    #endregion

    public GameStateBag? Serialize(SaveGameState saveGameState)
    {
        return new DictionaryGameStateBag(
            (nameof(AttackBonus), saveGameState.CreateGameStateBag(AttackBonus)),
            (nameof(DamageBonus), saveGameState.CreateGameStateBag(DamageBonus)),
            (nameof(DisplayedAttackBonus), saveGameState.CreateGameStateBag(DisplayedAttackBonus)),
            (nameof(DisplayedDamageBonus), saveGameState.CreateGameStateBag(DisplayedDamageBonus)),
            (nameof(HasUnpriestlyWeapon), saveGameState.CreateGameStateBag(HasUnpriestlyWeapon)),
            (nameof(HasHeavyBow), saveGameState.CreateGameStateBag(HasHeavyBow)),
            (nameof(HasHeavyWeapon), saveGameState.CreateGameStateBag(HasHeavyWeapon))
        );
    }

    public Bonuses() { }
    public Bonuses(Game game, RestoreGameState restoreGameState)
    {
        AttackBonus = restoreGameState.GetInt(nameof(AttackBonus));
        DamageBonus = restoreGameState.GetInt(nameof(DamageBonus));
        DisplayedAttackBonus = restoreGameState.GetInt(nameof(DisplayedAttackBonus));
        DisplayedDamageBonus = restoreGameState.GetInt(nameof(DisplayedDamageBonus));
        HasUnpriestlyWeapon = restoreGameState.GetBool(nameof(HasUnpriestlyWeapon));
        HasHeavyBow = restoreGameState.GetBool(nameof(HasHeavyBow));
        HasHeavyWeapon = restoreGameState.GetBool(nameof(HasHeavyWeapon));
    }


    public Bonuses Merge(Bonuses bonuses)
    {
        return new Bonuses()
        {
            AttackBonus = AttackBonus + bonuses.AttackBonus,
            DamageBonus = AttackBonus + bonuses.DamageBonus,
            DisplayedAttackBonus = DisplayedAttackBonus + bonuses.DisplayedAttackBonus,
            DisplayedDamageBonus = DisplayedDamageBonus + bonuses.DisplayedDamageBonus,
            HasUnpriestlyWeapon = HasUnpriestlyWeapon || bonuses.HasUnpriestlyWeapon,
            HasHeavyBow = HasHeavyBow || bonuses.HasHeavyBow,
            HasHeavyWeapon = HasHeavyWeapon || bonuses.HasHeavyWeapon,
        };
    }
}
