using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace efm23
{
    public partial class Exercice2 : UserControl
    {
        public static string connexion = ConfigurationManager.ConnectionStrings["conString"].ToString();
        SqlConnection con = new SqlConnection(connexion);
        SqlCommand cmd;
        SqlDataReader dr;
        BindingSource bs = new BindingSource();
        public Exercice2()
        {
            InitializeComponent();
        }

        private void Exercice2_Load(object sender, EventArgs e)
        {
            dgvex2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            afficher();
        }


        private void afficher()
        {
            try
            {
                string requette = @"SELECT * FROM Employe";
                con.Open();
                cmd = new SqlCommand(requette, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    bs.DataSource = dr;
                    dgvex2.DataSource = bs;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur!");
            }
            finally
            {
                con.Close();
                //dr.Close();
            }
        }

        //bouton Ajouter
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string requette = @"INSERT INTO Employe values(@mat, @nper, @pper, @slr, @prm)";
                con.Open();
                cmd = new SqlCommand(requette, con);
                cmd.Parameters.AddWithValue("@mat", txtbx_ex2_mat.Text);
                cmd.Parameters.AddWithValue("@nper", txtbx_ex2_npers.Text);
                cmd.Parameters.AddWithValue("@pper", txtbx_ex2_ppers.Text);
                cmd.Parameters.AddWithValue("@slr", txtbx_ex2_slr.Text);
                cmd.Parameters.AddWithValue("@prm", txtbx_ex2_prime.Text);

                cmd.ExecuteNonQuery();

                
                bs.DataSource = dr;
                dgvex2.DataSource = bs;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                //dr.Close();
                afficher();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bs.MoveFirst();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bs.MoveLast();
        }

        //bouton Modifier
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtbx_ex2_mat.Text != "" && txtbx_ex2_npers.Text != "" && txtbx_ex2_ppers.Text != "" && txtbx_ex2_prime.Text != "" && txtbx_ex2_slr.Text != "")
            {
                try
                {
                    string requette = @"UPDATE Employe SET NomPers = @nper, PrenomPers = @pper,Salaire = @slr, Prime = @prm WHERE Matricule = @mat";
                    con.Open();
                    cmd = new SqlCommand(requette, con);
                    cmd.Parameters.AddWithValue("@mat", txtbx_ex2_mat.Text);
                    cmd.Parameters.AddWithValue("@nper", txtbx_ex2_npers.Text);
                    cmd.Parameters.AddWithValue("@pper", txtbx_ex2_ppers.Text);
                    cmd.Parameters.AddWithValue("@slr", txtbx_ex2_slr.Text);
                    cmd.Parameters.AddWithValue("@prm", txtbx_ex2_prime.Text);

                    cmd.ExecuteNonQuery();


                    bs.DataSource = dr;
                    dgvex2.DataSource = bs;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                    //dr.Close();
                    afficher();
                }
            }
            else
            {
                MessageBox.Show("Veuillez Remplir tous les champs!!");
            }
        }

        private void dgvex2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtbx_ex2_mat.Text = dgvex2.SelectedRows[0].Cells[0].Value.ToString();
            txtbx_ex2_npers.Text = dgvex2.SelectedRows[0].Cells[1].Value.ToString();
            txtbx_ex2_ppers.Text = dgvex2.SelectedRows[0].Cells[2].Value.ToString();
            txtbx_ex2_slr.Text = dgvex2.SelectedRows[0].Cells[3].Value.ToString();
            txtbx_ex2_prime.Text = dgvex2.SelectedRows[0].Cells[4].Value.ToString();


        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtbx_ex2_mat.Text = "";
            txtbx_ex2_npers.Text = "";
            txtbx_ex2_ppers.Text = "";
            txtbx_ex2_slr.Text = "";
            txtbx_ex2_prime.Text = "";
        }
    }
}
