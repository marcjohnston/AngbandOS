namespace AngbandOS.Core.RoomTypes
{
    internal abstract class RoomType
    {
        public abstract int Type { get; }
        public abstract void Build(SaveGame saveGame, int yval, int xval);
    }

    internal class RoomType1 : RoomType
    {
        public override int Type => 1;
        public override void Build(SaveGame saveGame, int yval, int xval)
        {
        }
    }

    internal class RoomType2 : RoomType
    {
        public override int Type => 2;
        public override void Build(SaveGame saveGame, int yval, int xval)
        {
        }

    }

    internal class RoomType3 : RoomType
    {
        public override int Type => 3;
        public override void Build(SaveGame saveGame, int yval, int xval)
        {
        }

    }

    internal class RoomType4 : RoomType
    {
        public override int Type => 4;
        public override void Build(SaveGame saveGame, int yval, int xval)
        {
        }

    }

    internal class RoomType5 : RoomType
    {
        public override int Type => 5;
        public override void Build(SaveGame saveGame, int yval, int xval)
        {
        }

    }

    internal class RoomType6 : RoomType
    {
        public override int Type => 6;
        public override void Build(SaveGame saveGame, int yval, int xval)
        {
        }
    }

    internal class RoomType7 : RoomType
    {
        public override int Type => 7;
        public override void Build(SaveGame saveGame, int yval, int xval)
        {
        }
    }

    internal class RoomType8 : RoomType
    {
        public override int Type => 8;
        public override void Build(SaveGame saveGame, int yval, int xval)
        {
        }
    }
}
