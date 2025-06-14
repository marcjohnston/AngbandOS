﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class ProjectileWeightedRandom : WeightedRandom<ProjectileScript>, IGetKey, IUniversalScript // DO NOT ADD MORE INTERFACES HERE, ADD IT TO THE IPROJECTILE
{
    public ProjectileWeightedRandom(Game game, ProjectileWeightedRandomGameConfiguration projectileWeightedRandomGameConfiguration) : base(game)
    {
        Key = projectileWeightedRandomGameConfiguration.Key ?? projectileWeightedRandomGameConfiguration.GetType().Name;
        NameAndWeightBindings = projectileWeightedRandomGameConfiguration.NameAndWeightBindings;
        LearnedDetails = LearnedDetails;
    }

    /// <summary>
    /// Returns the nullable names and weights.  Names can be null to support non-action weights.
    /// </summary>
    protected (string name, int weight)[] NameAndWeightBindings { get; }

    public virtual string Key { get; }

    public string GetKey => Key;

    public void Bind()
    {
        foreach ((string name, int weight) in NameAndWeightBindings)
        {
            Add(weight, Game.SingletonRepository.Get<ProjectileScript>(name));
        }
    }

    public UsedResult ExecuteDirectionalActivationScript(Item item, int direction)
    {
        return Choose().ExecuteDirectionalActivationScript(item, direction);
    }

    public IdentifiedResult ExecuteEatOrQuaffScript()
    {
        return Choose().ExecuteEatOrQuaffScript();
    }

    public IdentifiedResult ExecuteAimWandScript(int dir)
    {
        return Choose().ExecuteAimWandScript(dir);
    }

    public IdentifiedAndUsedResult ExecuteZapRodScript(Item item, int dir)
    {
        return Choose().ExecuteZapRodScript(item, dir);
    }

    public void ExecuteScript()
    {
        Choose().ExecuteScript();
    }

    public IdentifiedAndUsedResult ExecuteReadScrollOrUseStaffScript()
    {
        return Choose().ExecuteReadScrollOrUseStaffScript();
    }

    public UsedResult ExecuteActivateItemScript(Item item)
    {
        return Choose().ExecuteActivateItemScript(item);
    }

    public bool ExecuteSuccessByChanceScript()
    {
        return Choose().ExecuteSuccessByChanceScript();
    }

    public void ExecuteCastSpellScript(Spell spell)
    {
        Choose().ExecuteCastSpellScript(spell);
    }

    public string ToJson()
    {
        ProjectileWeightedRandomGameConfiguration definition = new()
        {
            Key = Key,
            NameAndWeightBindings = NameAndWeightBindings,
            LearnedDetails = LearnedDetails,
        };
        return JsonSerializer.Serialize(definition, Game.GetJsonSerializerOptions());
    }

    /// <summary>
    /// Returns information about the spell, or blank if there is no detailed information.  Returns blank, by default.  Returns blank, by default.
    /// </summary>
    public virtual string LearnedDetails { get; } = "";
}
