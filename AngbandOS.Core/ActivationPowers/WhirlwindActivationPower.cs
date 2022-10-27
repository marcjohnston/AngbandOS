using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ActivationPowers
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

        public override bool Activate(SaveGame saveGame)
        {
            for (int direction = 0; direction <= 9; direction++)
            {
                int y = saveGame.Player.MapY + saveGame.Level.KeypadDirectionYOffset[direction];
                int x = saveGame.Player.MapX + saveGame.Level.KeypadDirectionXOffset[direction];
                GridTile cPtr = saveGame.Level.Grid[y][x];
                Monster mPtr = saveGame.Level.Monsters[cPtr.MonsterIndex];
                if (cPtr.MonsterIndex != 0 && (mPtr.IsVisible || saveGame.Level.GridPassable(y, x)))
                {
                    saveGame.PlayerAttackMonster(y, x);
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
