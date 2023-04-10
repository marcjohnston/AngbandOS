namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class StaffItem : Item
    {
        public StaffItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 15;
        public override int? GetBonusRealValue(int value)
        {
            return value / 20 * TypeSpecificValue;
        }

        public override void ApplyMagic(int level, int power)
        {
            switch (ItemSubCategory)
            {
                case StaffType.Darkness:
                    TypeSpecificValue = Program.Rng.DieRoll(8) + 8;
                    break;

                case StaffType.Slowness:
                    TypeSpecificValue = Program.Rng.DieRoll(8) + 8;
                    break;

                case StaffType.HasteMonsters:
                    TypeSpecificValue = Program.Rng.DieRoll(8) + 8;
                    break;

                case StaffType.Summoning:
                    TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
                    break;

                case StaffType.Teleportation:
                    TypeSpecificValue = Program.Rng.DieRoll(4) + 5;
                    break;

                case StaffType.Identify:
                    TypeSpecificValue = Program.Rng.DieRoll(15) + 5;
                    break;

                case StaffType.RemoveCurse:
                    TypeSpecificValue = Program.Rng.DieRoll(3) + 4;
                    break;

                case StaffType.Starlight:
                    TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
                    break;

                case StaffType.Light:
                    TypeSpecificValue = Program.Rng.DieRoll(20) + 8;
                    break;

                case StaffType.Mapping:
                    TypeSpecificValue = Program.Rng.DieRoll(5) + 5;
                    break;

                case StaffType.DetectGold:
                    TypeSpecificValue = Program.Rng.DieRoll(20) + 8;
                    break;

                case StaffType.DetectItem:
                    TypeSpecificValue = Program.Rng.DieRoll(15) + 6;
                    break;

                case StaffType.DetectTrap:
                    TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
                    break;

                case StaffType.DetectDoor:
                    TypeSpecificValue = Program.Rng.DieRoll(8) + 6;
                    break;

                case StaffType.DetectInvis:
                    TypeSpecificValue = Program.Rng.DieRoll(15) + 8;
                    break;

                case StaffType.DetectEvil:
                    TypeSpecificValue = Program.Rng.DieRoll(15) + 8;
                    break;

                case StaffType.CureLight:
                    TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
                    break;

                case StaffType.Curing:
                    TypeSpecificValue = Program.Rng.DieRoll(3) + 4;
                    break;

                case StaffType.Healing:
                    TypeSpecificValue = Program.Rng.DieRoll(2) + 1;
                    break;

                case StaffType.TheMagi:
                    TypeSpecificValue = Program.Rng.DieRoll(2) + 2;
                    break;

                case StaffType.SleepMonsters:
                    TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
                    break;

                case StaffType.SlowMonsters:
                    TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
                    break;

                case StaffType.Speed:
                    TypeSpecificValue = Program.Rng.DieRoll(3) + 4;
                    break;

                case StaffType.Probing:
                    TypeSpecificValue = Program.Rng.DieRoll(6) + 2;
                    break;

                case StaffType.DispelEvil:
                    TypeSpecificValue = Program.Rng.DieRoll(3) + 4;
                    break;

                case StaffType.Power:
                    TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
                    break;

                case StaffType.Holiness:
                    TypeSpecificValue = Program.Rng.DieRoll(2) + 2;
                    break;

                case StaffType.Carnage:
                    TypeSpecificValue = Program.Rng.DieRoll(2) + 1;
                    break;

                case StaffType.Earthquakes:
                    TypeSpecificValue = Program.Rng.DieRoll(5) + 3;
                    break;

                case StaffType.Destruction:
                    TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
                    break;
            }
        }
    }
}