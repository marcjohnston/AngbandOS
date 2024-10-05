using AngbandOS.Core.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AngbandOS.Configurator.WinForm
{
    public partial class TuplePropertyUserControl : UserControl, IPropertyUserControl
    {
        public TuplePropertyUserControl(TuplePropertyMetadata tuplePropertyMetadata, IConfiguration configuration)
        {
            InitializeComponent();
        }
    }
}
