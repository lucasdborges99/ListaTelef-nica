using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ListaTelefônica.Models;

namespace ListaTelefônica
{
    public partial class Form1 : Form
    {
        List<Contato> lista;
        int idContato = 0;
        string[][] list;
        public Form1()
        {
            InitializeComponent();
            btAdicionar.TabIndex = 0;
            btRemover.TabIndex = 1;
            dgvLista.TabStop = false;
            lista = new List<Contato>();
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                if (txtNome.Focused && !String.IsNullOrWhiteSpace(txtNome.Text))
                {
                    txtTel.Focus();
                    return;
                }

                if (txtTel.Focused && txtTel.MaskFull)
                    btAdicionar_Click(this, EventArgs.Empty);
            }
        }

        void Atualizar()
        {
            dgvLista.Rows.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvLista);
                
                row.Cells[0].Value = lista[i].Id;
                row.Cells[1].Value = lista[i].Nome;
                row.Cells[2].Value = lista[i].Telefone;
                dgvLista.Rows.Add(row);
            }
            txtNome.Clear();
            txtTel.Clear();
            txtNome.Focus();
            idContato = 0; 
            btAdicionar.Text = "Adicionar";
        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtNome.Text) || !txtTel.MaskFull)
            {
                MessageBox.Show("Insira um nome e telefone válidos.");
                return;
            }

            if (idContato != 0)
            {
                Contato contato = lista.FirstOrDefault(c => c.Id == idContato);
                if (contato != null)
                {
                    contato.Nome = txtNome.Text;
                    contato.Telefone = txtTel.Text;
                }
            }

            else
            {
                int id = lista.Count > 0 ? lista.Max(c => c.Id) + 1 : 1;

                Contato novo = new Contato
                {
                    Id = id,
                    Nome = txtNome.Text,
                    Telefone = txtTel.Text
                };

                lista.Add(novo);
            }

            Atualizar();
        }

        private void btRemover_Click(object sender, EventArgs e)
        {
            if (dgvLista.SelectedCells.Count == 0)
            {
                MessageBox.Show("Selecione um contato para remover.");
                return;
            }

            int linha = dgvLista.SelectedCells[0].RowIndex;
            if (linha < 0 || linha >= lista.Count)
            {
                MessageBox.Show("Selecione um item válido");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Deseja de fato remover o contato de " + lista[linha].Nome + "?",
                "Remover",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                lista.RemoveAt(linha);
                Atualizar();
            }

           
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= lista.Count)
                return;

            DialogResult confirmacao = MessageBox.Show(
                "Deseja editar o contato de " + lista[e.RowIndex].Nome + "?",
                "Editar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacao == DialogResult.Yes)
            {
                idContato = lista[e.RowIndex].Id;
                txtNome.Text = lista[e.RowIndex].Nome;
                txtTel.Text = lista[e.RowIndex].Telefone;
                txtNome.Focus();
                btAdicionar.Text = "Editar";
            }
        }
    }
}   