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
        string idContato = "";
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
            idContato = ""; 
            btAdicionar.Text = "Adicionar";
        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtNome.Text) || !txtTel.MaskFull)
            {
                MessageBox.Show("Insira um nome e telefone válidos.");
                return;
            }   

            if (idContato != "")
            {
                for (int i = 0; i < Length(lista); i++)
                {
                    if (lista[i][0] == idContato)
                    {
                        lista[i][1] = txtNome.Text;
                        lista[i][2] = txtTel.Text;
                        break;
                    }
                }
            }
            else
            {
                int id = 1;
                if (lista.Count > 0)
                    id = lista.Max(c => c.Id) + 1;
                
                Contato novo = new Contato();
                novo.Id = id;
                novo.Nome = txtNome.Text;
                novo.Telefone = txtTel.Text;

                lista.Add(novo);


                for (int i = 0; i < lista.Length; i++)
                {
                    if (lista[i] == null)
                    {
                        lista[i] = new string[3];
                        lista[i][0] = newId.ToString();
                        lista[i][1] = txtNome.Text;
                        lista[i][2] = txtTel.Text;
                        break;
                    }
                }
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
            if (linha < 0 || linha >= lista.Length || lista[linha] == null)
            {
                MessageBox.Show("Selecione um item válido");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Deseja de fato remover o contato de " + lista[linha][1] + "?",
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
            if (e.RowIndex < 0 || e.RowIndex >= Length(lista) || lista[e.RowIndex] == null)
                return;

            DialogResult confirmacao = MessageBox.Show(
                "Deseja editar o contato de " + lista[e.RowIndex][1] + "?",
                "Editar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacao == DialogResult.Yes)
            {
                idContato = lista[e.RowIndex][0];
                txtNome.Text = lista[e.RowIndex][1];
                txtTel.Text = lista[e.RowIndex][2];
                txtNome.Focus();
                btAdicionar.Text = "Editar";
            }
        }
    }
}