// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Give us protection from evil.
/// </summary>
[Serializable]
internal class ProtectionFromEvilActivation : Activation
{
    private ProtectionFromEvilActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 75;

    public override string? PreActivationMessage => "Your {0} lets out a shrill wail...";

    protected override bool OnActivate(Item item)
    {
        int k = 3 * SaveGame.ExperienceLevel;
        SaveGame.TimedProtectionFromEvil.AddTimer(SaveGame.DieRoll(25) + k);
        return true;
    }

    public override int RechargeTime() => SaveGame.RandomLessThan(225) + 225;

    public override int Value => 5000;

    public override string Name => "Protect evil (dur level*3 + d25)";

    public override string Frequency => "225+d225";
}
