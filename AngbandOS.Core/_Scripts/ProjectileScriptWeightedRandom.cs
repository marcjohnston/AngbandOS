// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class ProjectileScriptWeightedRandom : WeightedRandom<ProjectileScript>, IGetKey, IUniversalScript, IToJson // DO NOT ADD MORE INTERFACES HERE, ADD IT TO THE IPROJECTILE
{
    public ProjectileScriptWeightedRandom(Game game, ProjectileScriptWeightedRandomGameConfiguration projectileWeightedRandomGameConfiguration) : base(game)
    {
        Key = projectileWeightedRandomGameConfiguration.Key ?? projectileWeightedRandomGameConfiguration.GetType().Name;
        NameAndWeightBindings = projectileWeightedRandomGameConfiguration.NameAndWeightBindings;
        LearnedDetails = projectileWeightedRandomGameConfiguration.LearnedDetails;
        LearnedDetailsMode = projectileWeightedRandomGameConfiguration.LearnedDetailsMode;
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

    public IdentifiedResultEnum ExecuteEatOrQuaffScript()
    {
        return Choose().ExecuteEatOrQuaffScript();
    }

    public IdentifiedResultEnum ExecuteAimWandScript(int dir)
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

    public UsedResultEnum ExecuteActivateItemScript(Item item)
    {
        return Choose().ExecuteActivateItemScript(item);
    }


    public void ExecuteCastSpellScript(Spell spell)
    {
        Choose().ExecuteCastSpellScript(spell);
    }

    public string ToJson()
    {
        ProjectileScriptWeightedRandomGameConfiguration definition = new()
        {
            Key = Key,
            NameAndWeightBindings = NameAndWeightBindings,
            LearnedDetails = LearnedDetails,
            LearnedDetailsMode = LearnedDetailsMode,
        };
        return JsonSerializer.Serialize(definition, Game.GetJsonSerializerOptions());
    }

    UsedResultEnum IActivateItemScript.ExecuteActivateItemScript(Item item)
    {
        throw new NotImplementedException();
    }

    IdentifiedResultEnum IAimWandScript.ExecuteAimWandScript(int dir)
    {
        throw new NotImplementedException();
    }

    IdentifiedAndUsedResult IZapRodScript.ExecuteZapRodScript(Item item, int dir)
    {
        throw new NotImplementedException();
    }

    void IScript.ExecuteScript()
    {
        throw new NotImplementedException();
    }

    IdentifiedAndUsedResult IReadScrollOrUseStaffScript.ExecuteReadScrollOrUseStaffScript()
    {
        throw new NotImplementedException();
    }

    void ICastSpellScript.ExecuteCastSpellScript(Spell spell)
    {
        throw new NotImplementedException();
    }

    IdentifiedResultEnum IEatOrQuaffScript.ExecuteEatOrQuaffScript()
    {
        throw new NotImplementedException();
    }

    public virtual LearnedDetailsWeightedRandomEnum LearnedDetailsMode { get; }

    /// <summary>
    /// Returns information about the spell, or blank if there is no detailed information.  Returns blank, by default.  Returns blank, by default.
    /// </summary>
    public virtual string LearnedDetails { get; } = "";

    string ICastSpellScript.LearnedDetails
    {
        get
        {
            switch (LearnedDetailsMode)
            {
                case LearnedDetailsWeightedRandomEnum.InheritFromFirstDefined:
                    if (Count > 0)
                    {
                        return Items[0].LearnedDetails;
                    }
                    break;
            }
            return LearnedDetails;
        }
    }
}

