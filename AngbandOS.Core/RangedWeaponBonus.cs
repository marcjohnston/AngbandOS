// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class RangedWeaponBonus : IGetKey, IToJson
{
    private readonly Game Game;
    public RangedWeaponBonus(Game game, RangedWeaponBonusGameConfiguration missileAttacksPerRoundGameConfiguration)
    {
        Game = game;
        CharacterClassBindingKey = missileAttacksPerRoundGameConfiguration.CharacterClassBindingKey;
        ItemClassBindingKey = missileAttacksPerRoundGameConfiguration.ItemClassBindingKey;
        ExperienceLevel = missileAttacksPerRoundGameConfiguration.ExperienceLevel;
        BonusMissileAttacksPerRound = missileAttacksPerRoundGameConfiguration.BonusMissileAttacksPerRound;
    }
    public virtual string? CharacterClassBindingKey { get; } = null;
    public virtual string? ItemClassBindingKey { get; } = null;
    public virtual int? ExperienceLevel { get; } = null;
    public virtual int BonusMissileAttacksPerRound { get; } = 0;

    public string GetKey => Game.GetCompositeKey(CharacterClassBindingKey, ItemClassBindingKey, ExperienceLevel == null ? null : ExperienceLevel.Value.ToString());

    public void Bind() { }
    public string ToJson()
    {
        RangedWeaponBonusGameConfiguration classSpellDefinition = new()
        {
            CharacterClassBindingKey = CharacterClassBindingKey,
            ItemClassBindingKey = ItemClassBindingKey,
            ExperienceLevel = ExperienceLevel,
            BonusMissileAttacksPerRound = BonusMissileAttacksPerRound,
        };
        return JsonSerializer.Serialize(classSpellDefinition, Game.GetJsonSerializerOptions());
    }
}
