// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents a script that evaluates an <see cref="IBoolValue"/> and runs a script depending on the result.
/// </summary>
[Serializable]
internal class ConditionalScript : IGetKey, IScript, IToJson
{
    protected readonly Game Game;
    public ConditionalScript(Game game, ConditionalScriptGameConfiguration gameConfiguration)
    {
        Game = game;
        Key = gameConfiguration.Key ?? gameConfiguration.GetType().Name;
        ConditionalKey = gameConfiguration.ConditionalKey;
        TrueScriptBindingKeys = gameConfiguration.TrueScriptBindingKeys;
        FalseScriptBindingKeys = gameConfiguration.FalseScriptBindingKeys;
    }
    public Conditional Conditional { get; private set; }
    private string ConditionalKey { get; }

    /// <summary>
    /// Returns the name of the widget to invalidate when the <see cref="Enabled"/> property returns true; or null, if no widget should be invalidated.  This 
    /// property is used to bind the <see cref="TrueWidgets"/> property during the bind phase.  Returns null, by default.
    /// </summary>
    protected string[]? TrueScriptBindingKeys { get; } = null;

    /// <summary>
    /// Returns the name of the widget to invalidate when the <see cref="Enabled"/> property returns false; or null, if no widget should be invalidated.  This 
    /// property is used to bind the <see cref="FalseWidgets"/> property during the bind phase.  Returns null, by default.
    /// </summary>
    protected string[]? FalseScriptBindingKeys { get; } = null;

    /// <summary>
    /// Returns the widget to invalidate when the <see cref="Enabled"/> property returns true.  This property is bound using the <see cref="TrueWidgetNames"/> property 
    /// during the bind phase.
    /// </summary>
    protected IScript[]? TrueScripts { get; private set; }

    /// <summary>
    /// Returns the widget to invalidate when the <see cref="Enabled"/> property returns false.  This property is bound using the <see cref="FalseWidgetNames"/> property 
    /// during the bind phase.
    /// </summary>
    protected IScript[]? FalseScripts { get; private set; }

    public void Bind()
    {
        Conditional = Game.SingletonRepository.Get<Conditional>(ConditionalKey);
        TrueScripts = Game.SingletonRepository.GetNullable<IScript>(TrueScriptBindingKeys);
        FalseScripts = Game.SingletonRepository.GetNullable<IScript>(FalseScriptBindingKeys);
    }

    public string ToJson()
    {
        ConditionalScriptGameConfiguration gameConfiguration = new()
        {
            Key = Key,
            ConditionalKey = ConditionalKey,
            TrueScriptBindingKeys = TrueScriptBindingKeys,
            FalseScriptBindingKeys = FalseScriptBindingKeys
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
    }

    public void ExecuteScript()
    {
        if (EvaluateEnabledExpression)
        {
            if (TrueScripts is not null)
            {
                foreach (IScript script in TrueScripts)
                {
                    script.ExecuteScript();
                }
            }
        }
        else
        {
            if (FalseScripts is not null)
            {
                foreach (IScript script in FalseScripts)
                {
                    script.ExecuteScript();
                }
            }
        }
    }

    /// <summary>
    /// Evaluates the <see cref="Enabled"/> property as a Product of Sums expression and returns true or false accordingly.
    /// </summary>
    protected bool EvaluateEnabledExpression
    {
        get
        {
            return Conditional.BoolValue;
        }
    }

    public string Key { get; }
    public string GetKey => Key;

}
