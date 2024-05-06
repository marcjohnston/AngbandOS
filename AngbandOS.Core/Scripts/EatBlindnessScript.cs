// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EatBlindnessScript : Script, IIdentifableScript
{
    private EatBlindnessScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteIdentifableScript()
    {
        Game.PlaySound(SoundEffectEnum.Eat);
        if (!Game.HasBlindnessResistance)
        {
            if (Game.BlindnessTimer.AddTimer(Game.RandomLessThan(200) + 200))
            {
                return true;
            }
        }
        return false;
    }
}

[Serializable]
internal class EatConfusionScript : Script, IIdentifableScript
{
    private EatConfusionScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteIdentifableScript()
    {
        Game.PlaySound(SoundEffectEnum.Eat);
        if (!Game.HasConfusionResistance)
        {
            if (Game.ConfusedTimer.AddTimer(Game.RandomLessThan(10) + 10))
            {
                return true;
            }
        }
        return false;
    }
}

[Serializable]
internal class EatCureBlindnessScript : Script, IIdentifableScript
{
    private EatCureBlindnessScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteIdentifableScript()
    {
        Game.PlaySound(SoundEffectEnum.Eat);
        if (Game.BlindnessTimer.ResetTimer())
        {
            return true;
        }
        return false;
    }
}

[Serializable]
internal class EatCureConfusionScript : Script, IIdentifableScript
{
    private EatCureConfusionScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteIdentifableScript()
    {
        Game.PlaySound(SoundEffectEnum.Eat);
        if (Game.ConfusedTimer.ResetTimer())
        {
            return true;
        }
        return false;
    }
}

[Serializable]
internal class EatCureParanoiaScript : Script, IIdentifableScript
{
    private EatCureParanoiaScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteIdentifableScript()
    {
        Game.PlaySound(SoundEffectEnum.Eat);
        if (Game.FearTimer.ResetTimer())
        {
            return true;
        }
        return false;
    }
}


[Serializable]
internal class EatCurePoisonScript : Script, IIdentifableScript
{
    private EatCurePoisonScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteIdentifableScript()
    {
        Game.PlaySound(SoundEffectEnum.Eat);
        if (Game.PoisonTimer.ResetTimer())
        {
            return true;
        }
        return false;
    }
}

[Serializable]
internal class EatCureSeriousWoundsScript : Script, IIdentifableScript
{
    private EatCureSeriousWoundsScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteIdentifableScript()
    {
        Game.PlaySound(SoundEffectEnum.Eat);
        if (Game.RestoreHealth(Game.DiceRoll(4, 8)))
        {
            return true;
        }
        return false;
    }
}

