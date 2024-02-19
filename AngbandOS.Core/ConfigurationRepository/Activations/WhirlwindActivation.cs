// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Make a physical attack against each adjacent monster.
/// </summary>
[Serializable]
internal class WhirlwindActivation : Activation
{
    private WhirlwindActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 50;

    public override string? PreActivationMessage => "";  // There is no message for this artifact power.

    public override int RechargeTime() => 250;

    public override bool Activate()
    {
        for (int direction = 0; direction <= 9; direction++)
        {
            int y = SaveGame.MapY + SaveGame.KeypadDirectionYOffset[direction];
            int x = SaveGame.MapX + SaveGame.KeypadDirectionXOffset[direction];
            GridTile cPtr = SaveGame.Grid[y][x];
            Monster mPtr = SaveGame.Monsters[cPtr.MonsterIndex];
            if (cPtr.MonsterIndex != 0 && (mPtr.IsVisible || SaveGame.GridPassable(y, x)))
            {
                SaveGame.PlayerAttackMonster(y, x);
            }
        }
        return true;
    }

    public override int Value => 7500;

    public override string Name => "whirlwind attack";

    public override string Description => $"{Name} every 250 turns";
}
