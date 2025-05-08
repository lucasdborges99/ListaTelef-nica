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

namespace ListaTelefônica
{
    public partial class Form1 : Form
    {
        string idContato = "";
        string[][] lista;
        readonly int MAX = 100;
        public Form1()
        {
            InitializeComponent();
            lista = new string[MAX][];
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
        }

        int Length(string[][] e)
        {
            int itens = 0;
            for (int i = 0; i < e.Length; i++)
                if (e[i] != null)
                    itens++;
            return itens;
        }

        int Length(string[] e)
        {
            int itens = 0;
            for (int i = 0; i < e.Length; i++)
                if (e[i] != null)
                    itens++;
            return itens;
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
            for (int i = 0; i < Length(lista); i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvLista);
                for (int j = 0; j < Length(lista[i]); j++)
                    row.Cells[j].Value = lista[i][j];
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

            if (Length(lista) >= MAX && idContato == "")
            {
                MessageBox.Show("A lista está cheia!", "Máximo de itens atingido");
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
                int newId = 1;
                if (Length(lista) > 0)
                    newId = int.Parse(lista[Length(lista) - 1][0]) + 1;

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
                for (int i = linha; i < Length(lista) - 1; i++)
                    lista[i] = lista[i + 1];
                lista[Length(lista) - 1] = null;
            }

            Atualizar();
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