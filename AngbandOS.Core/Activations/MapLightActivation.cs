// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Map the local area.
/// </summary>
[Serializable]
internal class MapLightActivation : Activation
{
    private MapLightActivation(Game game) : base(game) { }
    public override int RandomChance => 101;

    public override string? PreActivationMessage => "Your {0} shines brightly...";

    protected override bool OnActivate(Item item)
    {
        Game.RunScript(nameof(MapAreaScript));
        Game.LightArea(Game.DiceRoll(2, 15), 3);
        return true;
    }

    public override int RechargeTime() => Game.RandomLessThan(50) + 50;

    public override int Value => 500;

    public override string Name => "Light (dam 2d15) & map area";

    public override string Frequency => "50+d50";
}
