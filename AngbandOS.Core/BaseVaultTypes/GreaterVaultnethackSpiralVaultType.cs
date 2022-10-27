using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GreaterVaultnethackSpiralVaultType : BaseVaultType
{
    public override char Character => '#';
    public override string Name => "Greater vault (nethack spiral)";
    public override int Category => 8;
    public override int Height => 19;
    public override int Rating => 30;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%.........XXXXXXXXX+XXXXXXXXX........%%......XXXX^^^^^^^^^^^^^^^^^XXXX.....%%...XXXX^^^^^XXXXXXXXXXXXX^^^^^XXXX..%%..XX^^^^^XXXX^^^^^^^^^^^XXXX^^^^^XX.%%.XX^^^^XXX^^^^XXXXXXXXX^^^^XXX^^^^XX%%.X^^^^XX^^^^XXX,^^^^^,XXX^^^^XX^^^^X%%.X,,,XX,,,XXX,,^XX+XX^,,XXX,,,XX,,,X%%.X,,,X,,,,X,,,^XX***XX^,,,X,,,,X,,,X%%.X,,,X,99,X,,,^+@888@+^,,,X,,,,+,,,X%%.X,,,X,,,,X,,,^XX***XX^,,,X,,,,X,,,X%%.X,,,XX,,,XXX,,^XX+XX^,,XXX,,,XX,,,X%%.X,,,,XX^^^^XXX,^^^^^,XXX^^^^XX,,,,X%%.XX,,,,XXX^^^^XXXX+XXXX^^^^XXX,,,,XX%%..XX,,,**XXXX^^^^^^^^^^^XXXX,,,,,XX.%%...XXXX**,,,XXXXXXXXXXXXX,,,,,XXXX..%%......XXXX,,,,,,,,,,,,,,,,,XXXX.....%%.........XXXXXXXXXXXXXXXXXXX........%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 38;
}
