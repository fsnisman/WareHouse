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

namespace InternetStore
{
    public partial class RegesterForm : Form
    {
        //
        //Иницилизация бд
        //
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|DBInternetStore.mdf;Integrated Security=True");//подключение к бд
        public RegesterForm()
        {
            InitializeComponent();
            Size = new Size(800, 450);
            panelEmail.Location = new Point(272, 184);
            panelPass.Location = new Point(272, 184);
            panelName.Location = new Point(272, 184);
            panelSerName.Location = new Point(272, 184);
            panelTelephon.Location = new Point(272, 184);
            panelData.Location = new Point(272, 184);
            panelTrueRegestration.Location = new Point(12, 30);
            panelFalseRegestretion.Location = new Point(12, 30);
            panelFalseRegestretion.Visible = false;
            panelTrueRegestration.Visible = false;
            panelEmail.Visible = false;
            panelPass.Visible = false;
            panelName.Visible = false;
            panelSerName.Visible = false;
            panelTelephon.Visible = false;
            panelData.Visible = false;
        }

        #region ErrorEnter
        private void button2_Click(object sender, EventArgs e)
        {
            panelEmail.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelPass.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panelName.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panelSerName.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panelTelephon.Visible = false;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            panelData.Visible = false;
        }
        #endregion ErrorEnter

        #region CloseApp
        private void CloseForm_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Owner = this;
            loginForm.Show();
            this.Hide();
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
        #endregion PanelMove

        #region FalseTrueRegestration
        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Owner = this;
            loginForm.Show();
            this.Hide();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            panelFalseRegestretion.Visible = false;
        }
        #endregion FalseTrueRegestration

        #region DataBaseRegestration
        private void buttonRegestr_Click(object sender, EventArgs e)
        {
            //проверка на пустые поля
            #region CheckEnter
            if (textBoxEmail.Text == "" && textBoxPass.Text == "" && textBoxName.Text == ""  && textBoxFalname.Text == "" && textBoxTelephon.Text == "")
            {
                panelData.Visible = true;
                return;
            }
            if (textBoxEmail.Text == "")
            {
                panelEmail.Visible = true;
                return;
            }
            if (textBoxPass.Text == "")
            {
                panelPass.Visible = true;
                return;
            }
            if (textBoxName.Text == "")
            {
                panelName.Visible = true;
                return;
            }
            if (textBoxFalname.Text == "")
            {
                panelSerName.Visible = true;
                return;
            }
            if (textBoxTelephon.Text == "")
            {
                panelTelephon.Visible = true;
                return;
            }
            #endregion CheckEnter
            //проверка на повторение аккаунта
            if (checkUser())
            {
                return;
            }

            string status = "user";

            SqlCommand command = new SqlCommand("INSERT INTO [Users] ([Login], [Password], [Имя], [Фамилия], [Телефон], [Статус]) VALUES (@login, @pass, @name, @sername, @phone, @status)", sqlConnection); //выбрать все и добавить

            command.Parameters.Add("@login", SqlDbType.VarChar).Value = textBoxEmail.Text; //добавить емаил
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = textBoxPass.Text; //добавить пароль
            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = textBoxName.Text; //добавить имя
            command.Parameters.Add("@sername", SqlDbType.NVarChar).Value = textBoxFalname.Text; //добавить фамилию
            command.Parameters.Add("@phone", SqlDbType.VarChar).Value = textBoxTelephon.Text; //добавить телефон
            command.Parameters.Add("@status", SqlDbType.NVarChar).Value = status; //добавить имя

            sqlConnection.Open(); //открыть соединеие с бд

            if(command.ExecuteNonQuery() == 1) //проверка на удачную регестрацию
            {
               sqlConnection.Close(); // закрыть соденинение с бд
                panelTrueRegestration.Visible = true;
            }
            else
            {
                panelFalseRegestretion.Visible = true;
            }
        }
        #endregion DataBaseRegestration

        #region CheckAccount
        public Boolean checkUser()
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            
            SqlCommand command = new SqlCommand("SELECT * FROM [Users] WHERE [Login] = @uL", sqlConnection); //команда выборки из бд
            command.Parameters.Add("@uL", SqlDbType.VarChar).Value = textBoxEmail.Text; //проверка на ввод

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count.ToString() == "1") //выбор
            {
                panelFalseRegestretion.Visible = true;
                return true; //если пользователь повторяется, то обратно регестрацию проходить
            }
            else
            {
                return false; //если нет пользователя, то аккаунт создан
            }
        }
        #endregion CheckAccount

        #region Trash
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void RegesterForm_Load(object sender, EventArgs e)
        {

        }
        #endregion Trash

    }
}
