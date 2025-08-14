using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ListaTelefônica.Models;
using ListaTelefônica.Presenters;

namespace ListaTelefônica.View
{
    public partial class FrmNovoContato : Form
    {
        private ContatoPresenter presenter;
        public FrmNovoContato(ContatoPresenter presenter)
        {
            InitializeComponent();
            this.presenter = presenter;
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string tel = txtTel.Text;
            if(nome.Length == 0 || !txtTel.MaskCompleted)
            {
                MessageBox.Show("Preencha os campos corretamente!");
                return; 
            }

            Contato novo = new Contato()
            {
                Nome = nome,
                Telefone = tel
            };
            if (presenter.AdicionarContato(novo))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Erro ao adicionar contato.");
            }
        }
    }
}
