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
            int y = SaveGame.MapY + SaveGame.Level.KeypadDirectionYOffset[direction];
            int x = SaveGame.MapX + SaveGame.Level.KeypadDirectionXOffset[direction];
            GridTile cPtr = SaveGame.Level.Grid[y][x];
            Monster mPtr = SaveGame.Level.Monsters[cPtr.MonsterIndex];
            if (cPtr.MonsterIndex != 0 && (mPtr.IsVisible || SaveGame.Level.GridPassable(y, x)))
            {
                SaveGame.PlayerAttackMonster(y, x);
            }
        }
        return true;
    }

    public override int Value => 7500;

    public override string Description => "whirlwind attack every 250 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustInt = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResPois = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Telepathy = true;
}
