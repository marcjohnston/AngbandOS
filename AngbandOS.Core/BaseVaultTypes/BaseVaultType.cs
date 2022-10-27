using AngbandOS.Core.Interface;
namespace AngbandOS.Core
{
    internal abstract class BaseVaultType
    {
        public abstract char Character { get; }
        public virtual Colour Colour => Colour.White;
        public abstract string Name { get; }
        public abstract int Category { get; }
        public abstract int Height { get; }
        public abstract int Rating { get; }
        public abstract string Text { get; }
        public abstract int Width { get; }
    }
}
