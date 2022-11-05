using AngbandOS.Enumerations;
using AngbandOS.Projection;
using System;
using System.Collections.Generic;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class WandDragonsBreath : WandItemCategory
    {
        public override char Character => '-';
        public override string Name => "Dragon's Breath";

        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Cost => 2400;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Dragon's Breath";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 60;
        public override int[] Locale => new int[] { 60, 0, 0, 0 };
        public override int? SubCategory => WandType.DragonBreath;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            switch (Program.Rng.RandomLessThan(5))
            {
                case 0:
                    saveGame.FireBall(new ProjectAcid(saveGame), dir, 100, -3);
                    break;
                case 1:
                    saveGame.FireBall(new ProjectElec(saveGame), dir, 80, -3);
                    break;
                case 2:
                    saveGame.FireBall(new ProjectFire(saveGame), dir, 100, -3);
                    break;
                case 3:
                    saveGame.FireBall(new ProjectCold(saveGame), dir, 80, -3);
                    break;
                case 4:
                    saveGame.FireBall(new ProjectPois(saveGame), dir, 60, -3);
                    break;
                default:
                    throw new Exception("Internal error.");
            }
            return true;
        }
        public override void ApplyMagic(Item item, int level, int power)
        {
            item.TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
        }
    }
}
