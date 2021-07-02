using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InternetStore
{
    public partial class LoginForm : Form
    {
        //
        //Иницилизация бд
        //
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\c#\InternetStore\InternetStore\InternetStore\DBInternetStore.mdf;Integrated Security=True");//подключение к бд
        DataUser dataUser = new DataUser();
        public LoginForm()
        {
            InitializeComponent();
            Size = new Size(387, 464);
            panelError.Location = new Point(0, 138);
            panelError.Visible = false;
        }

        #region CloseApp
        private void CloseForm_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void CloseForm_MouseEnter(object sender, EventArgs e)
        {
            CloseForm.BackColor = Color.FromArgb(134, 124, 185);
            CloseForm.ForeColor = Color.FromArgb(20, 15, 30);
        }

        private void CloseForm_MouseLeave(object sender, EventArgs e)
        {
            CloseForm.BackColor = Color.FromArgb(20, 15, 30);
            CloseForm.ForeColor = Color.FromArgb(134, 124, 185);
        }
        #endregion CloseApp

        #region RollApp
        private void RollForm_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void RollForm_MouseEnter(object sender, EventArgs e)
        {
            RollForm.BackColor = Color.FromArgb(134, 124, 185);
            RollForm.ForeColor = Color.FromArgb(20, 15, 30);
        }

        private void RollForm_MouseLeave(object sender, EventArgs e)
        {
            RollForm.BackColor = Color.FromArgb(20, 15, 30);
            RollForm.ForeColor = Color.FromArgb(134, 124, 185);
        }
        #endregion RollApp

        #region PanelMove
        Point lastPoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void LoginForm_MouseMove(object sender, MouseEventArgs e) // не удалять
        {}

        private void LoginForm_MouseDown(object sender, MouseEventArgs e) // не удалять
        { }
        #endregion PanelMove

        #region OpenMainForm
        private void button1_Click(object sender, EventArgs e)
        {
            string loginUser = textBoxEmail.Text; //переменна для логина
            string passUser = textBoxPass.Text; //перемена для пароля

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM [Users] WHERE [Login] = '" + loginUser + "' AND [Password] = '" + passUser + "'", sqlConnection); //выборка с бд
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count.ToString() == "1") //если провена на верность
            {
                dataUser.userEmail = textBoxEmail.Text; //присваиваем значение емаила
                dataUser.userPass = textBoxPass.Text; //присваиваем значение пароль

                SqlCommand command = new SqlCommand("SELECT [Login], [Имя], [Фамилия], [Телефон], [Статус] FROM [Users] WHERE Login LIKE '" + loginUser + "'", sqlConnection);
                sqlConnection.Open();
                var name = command.ExecuteReader();

                if (name.Read())
                {
                    dataUser.userName = name["Имя"].ToString();
                    name.Close();
                }
                

                var sername = command.ExecuteReader();
                if (sername.Read())
                {
                    dataUser.userSername = sername["Фамилия"].ToString();
                    sername.Close();
                }

                var telephone = command.ExecuteReader();
                if (telephone.Read())
                {
                    dataUser.userTelephone = telephone["Телефон"].ToString();
                    telephone.Close();
                }

                var status = command.ExecuteReader();
                if (status.Read())
                {
                    dataUser.userStatus = status["Статус"].ToString();
                    status.Close();
                }

                if (dataUser.userStatus == "admin")
                {
                    MainForm mainform = new MainForm(); //если все норм, то заходим в приложение
                    mainform.btnAdmin.Visible = true; //включение админ панели
                    mainform.labelEmail.Text = dataUser.userEmail; //изменяем текст в лайбле емаил
                    mainform.labelName.Text = dataUser.userName; //изменяем текст в лайбле имя
                    mainform.labelSername.Text = dataUser.userSername; //изменяем текст в лайбле фамилия
                    mainform.labelTelepgone.Text = dataUser.userTelephone; //изменяем текст в лайбле телефон
                    mainform.Owner = this;
                    mainform.Show();
                    this.Hide();
                }
                else
                {
                    MainForm mainform = new MainForm(); //если все норм, то заходим в приложение
                    mainform.btnAdmin.Visible = false; //выключение админ панели
                    mainform.labelEmail.Text = dataUser.userEmail; //изменяем текст в лайбле емаил
                    mainform.labelName.Text = dataUser.userName; //изменяем текст в лайбле имя
                    mainform.labelSername.Text = dataUser.userSername; //изменяем текст в лайбле фамилия
                    mainform.labelTelepgone.Text = dataUser.userTelephone; //изменяем текст в лайбле телефон
                    mainform.Owner = this;
                    mainform.Show();
                    this.Hide();
                }
            }
            else
            {
                panelError.Visible = true; //если все не норм, то повторяем ввод
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            panelError.Visible = false;
        }
        #endregion OpenMainForm

        #region Regestration
        private void label4_Click(object sender, EventArgs e)
        {
            RegesterForm regesterForm = new RegesterForm();
            regesterForm.Owner = this;
            regesterForm.Show();
            this.Hide();
        }
        #endregion Regestration



        #region Trash
        private void LoginForm_Load(object sender, EventArgs e) // не удалять
        {
        }
        private void pictureBox1_Click(object sender, EventArgs e) // не удалять
        {

        }
        #endregion Trash

    }
}
