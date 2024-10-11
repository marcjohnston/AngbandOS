
namespace AngbandOS.Core.Interface;

public class AnimationGameConfiguration
{
    public virtual string Key { get; set; }
    public virtual char Character { get; set; }
    public virtual ColorEnum Color { get; set; }
    public virtual string Name { get; set; }
    public virtual ColorEnum AlternateColor { get; set; }
    public virtual string Sequence { get; set; }
}
