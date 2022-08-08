using Cthangband.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Media;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Cthangband.Terminal
{
    internal interface IConsole
    {
        void SetCellBackground(int row, int col, string color);
        void Clear();
        void Print(int row, int col, string text, string colour);
        char WaitForKey();
        void SetBackground(BackgroundImage image);
    }
}
