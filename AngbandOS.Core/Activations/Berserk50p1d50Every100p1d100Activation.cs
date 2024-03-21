// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Bless us and make us a superhero.
/// </summary>
[Serializable]
internal class Berserk50p1d50Every100p1d100Activation : Activation
{
    private Berserk50p1d50Every100p1d100Activation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 101;

    public override string? PreActivationMessage => "";

    protected override bool OnActivate(Item item)
    {
        SaveGame.SuperheroismTimer.AddTimer(SaveGame.DieRoll(50) + 50);
        SaveGame.BlessingTimer.AddTimer(SaveGame.DieRoll(50) + 50);
        return true;
    }

    public override int RechargeTime() => 100 + SaveGame.DieRoll(100);

    public override int Value => 800;

    public override string Name => "Heroism and berserk (50+d50)";

    public override string Frequency => "100+d100";
}
