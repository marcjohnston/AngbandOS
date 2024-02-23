// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Shoot a frost ball that does 48 damage.
/// </summary>
[Serializable]
internal class BaCold1Activation : DirectionalActivation
{
    private BaCold1Activation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 85;

    public override string? PreActivationMessage => "Your {0} is covered in frost...";

    public override int RechargeTime() => 400;

    protected override bool Activate(int direction)
    {
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(ColdProjectile)), direction, 48, 2);
        return true;
    }

    public override int Value => 750;
    public override string Name => "Ball of cold (48)";

    public override string Description => $"{Name.ToLower()} every 400 turns";
}
