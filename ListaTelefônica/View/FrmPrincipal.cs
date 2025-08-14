using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ListaTelefônica.Presenters;

namespace ListaTelefônica.View
{
    public partial class FrmPrincipal : Form
    {
        private ContatoPresenter presenter;
        public FrmPrincipal()
        {
            InitializeComponent();
            presenter = new ContatoPresenter();
        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            FrmNovoContato frm = new FrmNovoContato(presenter);
            frm.ShowDialog();
        }
    }
}
