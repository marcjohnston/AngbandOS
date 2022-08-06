using Cthangband.Enumerations;
using System;

namespace Cthangband.ActivationPowers
{
    /// <summary>
    /// Make a physical attack against each adjacent monster.
    /// </summary>
    [Serializable]
    internal class WhirlwindActivationPower : ActivationPower
    {
        public override int RandomChance => 50;

        public override string PreActivationMessage => "";  // There is no message for this artifact power.

        public override int RechargeTime(Player player) => 250;

        public override bool Activate(Player player, Level level)
        {
            for (int direction = 0; direction <= 9; direction++)
            {
                int y = player.MapY + level.KeypadDirectionYOffset[direction];
                int x = player.MapX + level.KeypadDirectionXOffset[direction];
                GridTile cPtr = level.Grid[y][x];
                Monster mPtr = level.Monsters[cPtr.MonsterIndex];
                if (cPtr.MonsterIndex != 0 && (mPtr.IsVisible || level.GridPassable(y, x)))
                {
                    SaveGame.Instance.PlayerAttackMonster(y, x);
                }
            }
            return true;
        }

        public override int Value => 7500;

        public override string Description => "whirlwind attack every 250 turns";

        public override uint SpecialSustainFlag => ItemFlag2.SustInt;

        public override uint SpecialPowerFlag => ItemFlag2.ResPois;

        public override uint SpecialAbilityFlag => ItemFlag3.Telepathy;
    }
}
