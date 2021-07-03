using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace InternetStore
{
    public partial class MainForm : Form
    {
        //
        //Иницилизация бд
        //
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|DBInternetStore.mdf;Integrated Security=True");//подключение к бд
        SqlDataAdapter adapter = null;
        SqlCommandBuilder sqlBuilder = null;
        DataSet dataSet = null;
        DataTable table = null;

        SqlDataAdapter adapter_admin = null;
        DataSet dataSet_admin = null;

        SqlDataAdapter adapter_order = null;
        DataSet dataSet_order = null;

        //
        //Иницилизация переменных
        //
        int count = 0; //переменная для количества

        public MainForm()
        {
            InitializeComponent();
            customizeDesing();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            sqlConnection.Open();
            LoadData();
        }
        private void customizeDesing()
        {
            Size = new Size(1261, 729);

            //меню пользователя
            panelMain.Visible = true;
            panelMain.Location = new Point(0, 25);
            panelSettings.Visible = false;
            panelShopSubMenu.Visible = false;
            panelAccountSubMenu.Visible = false;
            panelHelpSubMenu.Visible = false;

            //корзина
            panelBasket.Visible = false;

            //аксессуары
            panel_Accesories.Visible = false;
            panel_Accesories_Man.Visible = false;
            panel_Accesories_Man_Wallets.Visible = false;
            panel_Accesories_Man_Belts.Visible = false;
            panel_Accesories_Man_Neckties.Visible = false;
            panel_Accesories_Man_SunGlasses.Visible = false;
            panel_Accesories_Man_Clocks.Visible = false;

            //одежда
            panelClothes.Visible = false;

            //спорт товары
            panel_Sport.Visible = false;

            //електроника
            panel_Electronic.Visible = false;

            //косметика
            panel_Cosmetics.Visible = false;

            //бытовуха
            panel_Appliances.Visible = false;
        }

        #region HubMenu
        //Скрывать хаб меню
        private void hideSubMenu()
        {
            if (panelShopSubMenu.Visible == true)
                panelShopSubMenu.Visible = false;
            if (panelAccountSubMenu.Visible == true)
                panelAccountSubMenu.Visible = false;
            if (panelHelpSubMenu.Visible == true)
                panelHelpSubMenu.Visible = false;
        }
        //Показывать хаб меню
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        //Показывать меню магазина
        private void btnShop_Click(object sender, EventArgs e)
        {
            showSubMenu(panelShopSubMenu);
        }
        #endregion HubMenu

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

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        #endregion PanelMove

        #region CloseApp
        private void btnExit_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("DELETE FROM [Local_Order_User]", sqlConnection);
            command.ExecuteNonQuery();

            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("DELETE FROM [Local_Order_User]", sqlConnection);
            command.ExecuteNonQuery();

            Application.Exit();
        }
        #endregion CloseApp

        #region TurnApp
        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion TurnApp


        #region MainPanel
        private void btnMain_Click(object sender, EventArgs e) //главная
        {
            panel_Admin.Visible = false;

            panel_Info.Visible = false;
            panel_Help.Visible = false;
            panelBasket.Visible = false;
            panelSettings.Visible = false;
            panel_Order.Visible = false;

            panel_Appliances.Visible = false;
            panel_Cosmetics.Visible = false;
            panel_Electronic.Visible = false;
            panel_Sport.Visible = false;
            panelClothes.Visible = false;
            panel_Accesories.Visible = false;

            panelMain.Visible = true;
        }

        private void button_Clothes_Click(object sender, EventArgs e)
        {
            panel_Info.Visible = false;
            panel_Help.Visible = false;
            panel_Admin.Visible = false;
            panelMain.Visible = false;
            panelBasket.Visible = false;
            panelSettings.Visible = false;
            panel_Order.Visible = false;

            panel_Appliances.Visible = false;
            panel_Cosmetics.Visible = false;
            panel_Electronic.Visible = false;
            panel_Sport.Visible = false;
            panel_Accesories.Visible = false;

            panelClothes.Location = new Point(0, 25);
            panelClothes.Visible = true;
        }

        private void button_Accessories_Click(object sender, EventArgs e)
        {
            panel_Info.Visible = false;
            panel_Help.Visible = false;
            panel_Admin.Visible = false;
            panelMain.Visible = false;
            panelBasket.Visible = false;
            panelSettings.Visible = false;
            panel_Order.Visible = false;

            panel_Appliances.Visible = false;
            panel_Cosmetics.Visible = false;
            panel_Electronic.Visible = false;
            panel_Sport.Visible = false;
            panelClothes.Visible = false;

            panel_Accesories.Location = new Point(0, 25);
            panel_Accesories.Visible = true;
        }

        private void button_Sport_Click(object sender, EventArgs e)
        {
            panel_Info.Visible = false;
            panel_Help.Visible = false;
            panel_Admin.Visible = false;
            panelMain.Visible = false;
            panelBasket.Visible = false;
            panelSettings.Visible = false;
            panel_Order.Visible = false;

            panel_Appliances.Visible = false;
            panel_Cosmetics.Visible = false;
            panel_Electronic.Visible = false;
            panel_Accesories.Visible = false;
            panelClothes.Visible = false;

            panel_Sport.Location = new Point(0, 25);
            panel_Sport.Visible = true;
        }

        private void button_Electronics_Click(object sender, EventArgs e)
        {
            panel_Info.Visible = false;
            panel_Help.Visible = false;
            panel_Admin.Visible = false;
            panelMain.Visible = false;
            panelBasket.Visible = false;
            panelSettings.Visible = false;
            panel_Order.Visible = false;

            panel_Appliances.Visible = false;
            panel_Cosmetics.Visible = false;
            panel_Sport.Visible = false;
            panel_Accesories.Visible = false;
            panelClothes.Visible = false;

            panel_Electronic.Location = new Point(0, 25);
            panel_Electronic.Visible = true;
        }

        private void button_Cosmetics_Click(object sender, EventArgs e)
        {
            panel_Info.Visible = false;
            panel_Help.Visible = false;
            panel_Admin.Visible = false;
            panelMain.Visible = false;
            panelBasket.Visible = false;
            panelSettings.Visible = false;
            panel_Order.Visible = false;

            panel_Appliances.Visible = false;
            panel_Electronic.Visible = false;
            panel_Sport.Visible = false;
            panel_Accesories.Visible = false;
            panelClothes.Visible = false;

            panel_Cosmetics.Location = new Point(0, 25);
            panel_Cosmetics.Visible = true;
        }

        private void button_Appliances_Click(object sender, EventArgs e)
        {
            panel_Info.Visible = false;
            panel_Help.Visible = false;
            panel_Admin.Visible = false;
            panelMain.Visible = false;
            panelBasket.Visible = false;
            panelSettings.Visible = false;
            panel_Order.Visible = false;

            panel_Cosmetics.Visible = false;
            panel_Electronic.Visible = false;
            panel_Sport.Visible = false;
            panel_Accesories.Visible = false;
            panelClothes.Visible = false;

            panel_Appliances.Location = new Point(0, 25);
            panel_Appliances.Visible = true;
        }

        private void pictureBox583_Click(object sender, EventArgs e)
        {
            panel_Info.Visible = false;
            panel_Help.Visible = false;
            panel_Admin.Visible = false;
            panelMain.Visible = false;
            panelBasket.Visible = false;
            panelSettings.Visible = false;
            panel_Order.Visible = false;

            panel_Appliances.Visible = false;
            panel_Cosmetics.Visible = false;
            panel_Sport.Visible = false;
            panel_Accesories.Visible = false;
            panelClothes.Visible = false;

            panel_Electronic.Location = new Point(0, 25);
            panel_Electronic.Visible = true;
            panel_Electronic.AutoScroll = false;
            panel_Notebook.Location = new Point(0, 0);
            panel_Notebook.Visible = true;
        }

        private void pictureBox581_Click(object sender, EventArgs e)
        {
            panel_Info.Visible = false;
            panel_Help.Visible = false;
            panel_Admin.Visible = false;
            panelMain.Visible = false;
            panelBasket.Visible = false;
            panelSettings.Visible = false;
            panel_Order.Visible = false;

            panel_Appliances.Visible = false;
            panel_Cosmetics.Visible = false;
            panel_Sport.Visible = false;
            panel_Accesories.Visible = false;
            panelClothes.Visible = false;

            panel_Electronic.Location = new Point(0, 25);
            panel_Electronic.Visible = true;
            panel_Electronic.AutoScroll = false;
            panel_Photo.Location = new Point(0, 0);
            panel_Photo.Visible = true;
        }

        private void pictureBox582_Click(object sender, EventArgs e)
        {
            panel_Info.Visible = false;
            panel_Help.Visible = false;
            panel_Admin.Visible = false;
            panelMain.Visible = false;
            panelBasket.Visible = false;
            panelSettings.Visible = false;
            panel_Order.Visible = false;

            panel_Appliances.Visible = false;
            panel_Cosmetics.Visible = false;
            panel_Electronic.Visible = false;
            panel_Sport.Visible = false;
            panel_Accesories.Visible = false;

            panelClothes.Location = new Point(0, 25);
            panelClothes.Visible = true;
            panel_Clothes_Man.Location = new Point(0, 0);
            panel_Clothes_Man.Visible = true;
            panel_TShirt_Man.Location = new Point(0, 0);
            panel_TShirt_Man.Visible = true;
        }
        #endregion MainPanel

        #region ShopPanel
        private void button9_Click(object sender, EventArgs e) //одежда
        {
            panel_Info.Visible = false;
            panel_Help.Visible = false;
            panel_Admin.Visible = false;
            panelMain.Visible = false;
            panelBasket.Visible = false;
            panelSettings.Visible = false;
            panel_Order.Visible = false;

            panel_Appliances.Visible = false;
            panel_Cosmetics.Visible = false;
            panel_Electronic.Visible = false;
            panel_Sport.Visible = false;
            panel_Accesories.Visible = false;

            panelClothes.Location = new Point(0, 25);
            panelClothes.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e) //аксессуары
        {
            panel_Info.Visible = false;
            panel_Help.Visible = false;
            panel_Admin.Visible = false;
            panelMain.Visible = false;
            panelBasket.Visible = false;
            panelSettings.Visible = false;
            panel_Order.Visible = false;

            panel_Appliances.Visible = false;
            panel_Cosmetics.Visible = false;
            panel_Electronic.Visible = false;
            panel_Sport.Visible = false;
            panelClothes.Visible = false;

            panel_Accesories.Location = new Point(0, 25);
            panel_Accesories.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e) //спорт товары
        {
            panel_Info.Visible = false;
            panel_Help.Visible = false;
            panel_Admin.Visible = false;
            panelMain.Visible = false;
            panelBasket.Visible = false;
            panelSettings.Visible = false;
            panel_Order.Visible = false;

            panel_Appliances.Visible = false;
            panel_Cosmetics.Visible = false;
            panel_Electronic.Visible = false;
            panel_Accesories.Visible = false;
            panelClothes.Visible = false;

            panel_Sport.Location = new Point(0, 25);
            panel_Sport.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e) //электроника
        {
            panel_Info.Visible = false;
            panel_Help.Visible = false;
            panel_Admin.Visible = false;
            panelMain.Visible = false;
            panelBasket.Visible = false;
            panelSettings.Visible = false;
            panel_Order.Visible = false;

            panel_Appliances.Visible = false;
            panel_Cosmetics.Visible = false;
            panel_Sport.Visible = false;
            panel_Accesories.Visible = false;
            panelClothes.Visible = false;

            panel_Electronic.Location = new Point(0, 25);
            panel_Electronic.Visible = true;
        }


        private void button11_Click(object sender, EventArgs e) //косметика
        {
            panel_Info.Visible = false;
            panel_Help.Visible = false;
            panel_Admin.Visible = false;
            panelMain.Visible = false;
            panelBasket.Visible = false;
            panelSettings.Visible = false;
            panel_Order.Visible = false;

            panel_Appliances.Visible = false;
            panel_Electronic.Visible = false;
            panel_Sport.Visible = false;
            panel_Accesories.Visible = false;
            panelClothes.Visible = false;

            panel_Cosmetics.Location = new Point(0, 25);
            panel_Cosmetics.Visible = true;
        }


        private void button14_Click(object sender, EventArgs e) //бытовая техника
        {
            panel_Info.Visible = false;
            panel_Help.Visible = false;
            panel_Admin.Visible = false;
            panelMain.Visible = false;
            panelBasket.Visible = false;
            panelSettings.Visible = false;
            panel_Order.Visible = false;

            panel_Cosmetics.Visible = false;
            panel_Electronic.Visible = false;
            panel_Sport.Visible = false;
            panel_Accesories.Visible = false;
            panelClothes.Visible = false;

            panel_Appliances.Location = new Point(0, 25);
            panel_Appliances.Visible = true;
        }
        #endregion ShopPanel

        #region AccountPanel
        //Показывать меню Аккаунта
        private void btnAccount_Click(object sender, EventArgs e)
        {
            showSubMenu(panelAccountSubMenu);
        }
        private void button4_Click(object sender, EventArgs e)//врубление корзины
        {
            panel_Admin.Visible = false;

            panel_Info.Visible = false;
            panel_Help.Visible = false;
            panelMain.Visible = false;
            panelSettings.Visible = false;
            panel_Order.Visible = false;

            panel_Appliances.Visible = false;
            panel_Cosmetics.Visible = false;
            panel_Electronic.Visible = false;
            panel_Sport.Visible = false;
            panelClothes.Visible = false;
            panel_Accesories.Visible = false;

            panelBasket.Location = new Point(0, 25);
            panelBasket.Visible = true;
            RealodData();
        }


        private void button2_Click(object sender, EventArgs e)//врубление настроек
        {
            panel_Admin.Visible = false;

            panel_Info.Visible = false;
            panel_Help.Visible = false;
            panelMain.Visible = false;
            panelBasket.Visible = false;
            panel_Order.Visible = false;

            panel_Appliances.Visible = false;
            panel_Cosmetics.Visible = false;
            panel_Electronic.Visible = false;
            panel_Sport.Visible = false;
            panelClothes.Visible = false;
            panel_Accesories.Visible = false;

            panelSettings.Location = new Point(0, 25);
            panelSettings.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e) //спав панели выхода
        {
            panelExit.Location = new Point(157, 305);
            panelExit.Visible = true;
        }
        private void button12_Click_1(object sender, EventArgs e) //выход из аккаунта, сброс данных и загрузка логин форм
        {
            SqlCommand command = new SqlCommand("DELETE FROM [Local_Order_User]", sqlConnection);
            command.ExecuteNonQuery();

            labelEmail.Text = "Email";
            labelName.Text = "Name";
            labelSername.Text = "Sername";
            labelTelepgone.Text = "Telephone";


            LoginForm loginForm = new LoginForm();
            loginForm.Owner = this;
            loginForm.Show();
            this.Hide();
        }

        private void button13_Click_1(object sender, EventArgs e)//закрытие панели выхода, если ответили нет
        {
            panelExit.Visible = false;
        }

        #region SwitchData
        private void buttonSwitchEmail_Click(object sender, EventArgs e)//поменять емали
        {
            panelSwitchName.Visible = false;
            panelSwitchSername.Visible = false;
            panelSwitchTelephone.Visible = false;
            panelSwitchPass.Visible = false;

            panelSwitchEmail.Location = new Point(327, 229);
            panelSwitchEmail.Visible = true;
        }

        private void buttonSwitchName_Click(object sender, EventArgs e)//поменять имя
        {
            panelSwitchEmail.Visible = false;
            panelSwitchSername.Visible = false;
            panelSwitchTelephone.Visible = false;
            panelSwitchPass.Visible = false;

            panelSwitchName.Location = new Point(327, 229);
            panelSwitchName.Visible = true;
        }

        private void buttonSwitchSername_Click(object sender, EventArgs e)//поменять фамилию
        {
            panelSwitchName.Visible = false;
            panelSwitchEmail.Visible = false;
            panelSwitchTelephone.Visible = false;
            panelSwitchPass.Visible = false;

            panelSwitchSername.Location = new Point(327, 229);
            panelSwitchSername.Visible = true;
        }

        private void buttonSwitchTelephone_Click(object sender, EventArgs e)//поменять телефон
        {
            panelSwitchSername.Visible = false;
            panelSwitchName.Visible = false;
            panelSwitchEmail.Visible = false;
            panelSwitchPass.Visible = false;

            panelSwitchTelephone.Location = new Point(327, 229);
            panelSwitchTelephone.Visible = true;
        }

        private void buttonSwitchPass_Click(object sender, EventArgs e)//поменять пароль
        {
            panelSwitchTelephone.Visible = false;
            panelSwitchSername.Visible = false;
            panelSwitchName.Visible = false;
            panelSwitchEmail.Visible = false;

            panelSwitchPass.Size = new Size(283, 175);
            panelSwitchPass.Location = new Point(327, 229);
            panelSwitchPass.Visible = true;
        }
        private void buttonSwitchTelephoneEdit_Click(object sender, EventArgs e)//кнопка изменить телефон
        {
            //проверка на повторение телефона
            if (checkUserTelephone())
            {
                return;
            }

            if (textBoxEditTelephone.Text != "")
            {
                SqlCommand command = new SqlCommand("UPDATE [Users] SET [Телефон] = '" + textBoxEditTelephone.Text + "' WHERE [Login] = '" + labelEmail.Text + "'", sqlConnection);
                command.ExecuteNonQuery();

                labelTelepgone.Text = textBoxEditTelephone.Text;
                textBoxEditTelephone.Text = "";

                panelSwitchTelephone.Visible = false;
                panelEditTrue.Location = new Point(323, 245);
                panelEditTrue.Visible = true;
            }
        }

        private void buttonSwitchTelephoneNoEdit_Click(object sender, EventArgs e)//кнопка не изменить телефон
        {
            panelSwitchTelephone.Visible = false;
        }

        private void buttonSwitchEmailEdit_Click(object sender, EventArgs e)//кнопка изменить почту
        {
            //проверка на повторение почту
            if (checkUserEmail())
            {
                return;
            }

            if (textBoxEditEmail.Text != "")
            {
                SqlCommand command = new SqlCommand("UPDATE [Users] SET [Login] = '" + textBoxEditEmail.Text + "' WHERE [Login] = '" + labelEmail.Text + "'", sqlConnection);//обновление

                if (command.ExecuteNonQuery() == 1)
                {
                    labelEmail.Text = textBoxEditEmail.Text;
                    textBoxEditEmail.Text = "";

                    panelSwitchEmail.Visible = false;
                    panelEditTrue.Location = new Point(323, 245);
                    panelEditTrue.Visible = true;
                }
            }
        }

        private void buttonSwitchEmailNoEdit_Click(object sender, EventArgs e)//кнопка не изменить почту
        {
            panelSwitchEmail.Visible = false;
        }

        private void buttonSwitchNameEdit_Click(object sender, EventArgs e)//кнопка изменить имя
        {
            if (textBoxEditName.Text != "")
            {
                SqlCommand command = new SqlCommand("UPDATE [Users] SET [Имя] = @uName WHERE [Login] = '" + labelEmail.Text + "'", sqlConnection);//обновление
                command.Parameters.Add("@uName", SqlDbType.NVarChar).Value = textBoxEditName.Text;

                if (command.ExecuteNonQuery() == 1)
                {
                    labelName.Text = textBoxEditName.Text;
                    textBoxEditName.Text = "";

                    panelSwitchName.Visible = false;
                    panelEditTrue.Location = new Point(323, 245);
                    panelEditTrue.Visible = true;
                }
            }
        }

        private void buttonSwitchNameNoEdit_Click(object sender, EventArgs e)//кнопка не изменить имя
        {
            panelSwitchName.Visible = false;
        }

        private void buttonSwitchSernameEdit_Click(object sender, EventArgs e)//кнопка изменить фамилию
        {
            if (textBoxEditSername.Text != "")
            {
                SqlCommand command = new SqlCommand("UPDATE [Users] SET [Фамилия] = @uSername WHERE [Login] = '" + labelEmail.Text + "'", sqlConnection);//обновление
                command.Parameters.Add("@uSername", SqlDbType.NVarChar).Value = textBoxEditSername.Text;

                if (command.ExecuteNonQuery() == 1)
                {
                    labelSername.Text = textBoxEditSername.Text;
                    textBoxEditSername.Text = "";

                    panelSwitchSername.Visible = false;
                    panelEditTrue.Location = new Point(323, 245);
                    panelEditTrue.Visible = true;
                }
            }
        }

        private void buttonSwitchSernameNoEdit_Click(object sender, EventArgs e)//кнопка не изменить фамилию
        {
            panelSwitchSername.Visible = false;
        }

        private void buttonSwitchPassEdit_Click(object sender, EventArgs e)//кнопка изменить пароль
        {
            adapter = new SqlDataAdapter("SELECT * FROM [Users] WHERE [Login] = '" + labelEmail.Text + "' AND [Password] = '" + textBoxOldPass.Text + "'", sqlConnection);
            table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count.ToString() == "1")
            {
                if (textBoxEditPass.Text != "")
                {
                    SqlCommand command = new SqlCommand("UPDATE [Users] SET [Password] = @uP WHERE [Login] = '" + labelEmail.Text + "'", sqlConnection);
                    command.Parameters.Add("@uP", SqlDbType.VarChar).Value = textBoxEditPass.Text;
                    command.ExecuteNonQuery();

                    labelOldPassword.Visible = false;
                    labelNewPassword.Visible = false;
                    buttonSwitchPassOK.Visible = false;
                    labelPassTrue.Location = new Point(3, 68);
                    buttonPassTrue.Location = new Point(74, 104);
                    labelPassTrue.Visible = true;
                    buttonPassTrue.Visible = true;
                    panelErrorPass.Visible = true;

                    textBoxOldPass.Text = "";
                    textBoxEditPass.Text = "";
                }
                else
                {
                    labelOldPassword.Visible = false;
                    labelPassTrue.Visible = false;
                    labelNewPassword.Location = new Point(23, 68);
                    labelNewPassword.Visible = true;
                    panelErrorPass.Location = new Point(0, 0);
                    panelErrorPass.Visible = true;
                }
            }
            else
            {
                labelPassTrue.Visible = false;
                labelNewPassword.Visible = false;
                labelOldPassword.Visible = true;
                panelErrorPass.Location = new Point(0, 0);
                panelErrorPass.Visible = true;
            }
        }

        private void buttonSwitchPassNoEdit_Click(object sender, EventArgs e)//кнопка не инменить пароль
        {
            panelSwitchPass.Visible = false;
        }

        private void buttonSwitchPassOK_Click(object sender, EventArgs e)//кнопка для подвеждения о неверном пароле
        {
            panelErrorPass.Visible = false;
        }
        private void buttonEditTrueOK_Click(object sender, EventArgs e)
        {
            panelEditTrue.Visible = false;
        }
        private void buttonPassTrue_Click(object sender, EventArgs e)
        {
            labelPassTrue.Visible = false;
            panelErrorPass.Visible = false;
            buttonPassTrue.Visible = false;
            buttonSwitchPassOK.Visible = true;
            panelSwitchPass.Visible = false;
        }
        #endregion SwitchData

        #region CheckAccount
        public Boolean checkUserEmail()
        {
            table = new DataTable();
            adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * FROM [Users] WHERE [Login] = '" + textBoxEditEmail.Text + "'", sqlConnection); //команда выборки из бд

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count.ToString() == "1") //выбор
            {
                labelEmailCheck.Visible = true;
                return true; //если почка повторяется, то обратно
            }
            else
            {
                labelEmailCheck.Visible = false;
                return false;
            }
        }

        public Boolean checkUserTelephone()
        {
            table = new DataTable();
            adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * FROM [Users] WHERE [Телефон] = '" + textBoxEditTelephone.Text + "'", sqlConnection); //команда выборки из бд

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count.ToString() == "1") //выбор
            {
                labelTelephoneCheck.Visible = true;
                return true; //если телефон повторяется, то обратно 
            }
            else
            {
                labelTelephoneCheck.Visible = false;
                return false; 
            }
        }
        #endregion CheckAccount

        #region Order
        private void button484_Click(object sender, EventArgs e)
        {
            panel_Admin.Visible = false;

            panel_Info.Visible = false;
            panel_Help.Visible = false;
            panelMain.Visible = false;
            panelBasket.Visible = false;
            panelSettings.Visible = false;

            panel_Appliances.Visible = false;
            panel_Cosmetics.Visible = false;
            panel_Electronic.Visible = false;
            panel_Sport.Visible = false;
            panelClothes.Visible = false;
            panel_Accesories.Visible = false;

            panel_Order.Location = new Point(0, 25);
            panel_Order.Visible = true;

            adapter_order = new SqlDataAdapter("SELECT * FROM [Order]", sqlConnection);
            dataSet_order = new DataSet();
            adapter_order.Fill(dataSet_order);
            dataGridView_OrderLocal.DataSource = dataSet_order.Tables[0];

            (dataGridView_OrderLocal.DataSource as DataTable).DefaultView.RowFilter = $"[Email заказчика] LIKE '%" + labelEmail.Text + "%'";
        }



        #endregion Order

        #endregion AccountPanel

        #region HelpPanel
        private void btnHelp_Click(object sender, EventArgs e)
        {
            showSubMenu(panelHelpSubMenu);
        }
        private void button18_Click(object sender, EventArgs e)
        {
            panel_Admin.Visible = false;

            panel_Info.Visible = false;
            panelMain.Visible = false;
            panelBasket.Visible = false;
            panelSettings.Visible = false;
            panel_Order.Visible = false;

            panel_Appliances.Visible = false;
            panel_Cosmetics.Visible = false;
            panel_Sport.Visible = false;
            panel_Electronic.Visible = false;
            panelClothes.Visible = false;
            panel_Accesories.Visible = false;

            panel_Help.Location = new Point(0, 25);
            panel_Help.Visible = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            panel_Admin.Visible = false;

            panel_Help.Visible = false;
            panelMain.Visible = false;
            panelBasket.Visible = false;
            panelSettings.Visible = false;
            panel_Order.Visible = false;

            panel_Appliances.Visible = false;
            panel_Cosmetics.Visible = false;
            panel_Sport.Visible = false;
            panel_Electronic.Visible = false;
            panelClothes.Visible = false;
            panel_Accesories.Visible = false;

            panel_Info.Location = new Point(0, 25);
            panel_Info.Visible = true;
        }
        private void label5_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Admin.Visible = false;

            panel_Help.Visible = false;
            panelMain.Visible = false;
            panelBasket.Visible = false;
            panelSettings.Visible = false;
            panel_Order.Visible = false;

            panel_Appliances.Visible = false;
            panel_Cosmetics.Visible = false;
            panel_Sport.Visible = false;
            panel_Electronic.Visible = false;
            panelClothes.Visible = false;
            panel_Accesories.Visible = false;

            panel_Info.Location = new Point(0, 25);
            panel_Info.Visible = true;
        }
        #endregion HelpPanel

        #region AdminPanel

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            hideSubMenu();

            panel_Help.Visible = false;
            panel_Info.Visible = false;
            panelMain.Visible = false;
            panelBasket.Visible = false;
            panelSettings.Visible = false;
            panel_Order.Visible = false;

            panel_Appliances.Visible = false;
            panel_Cosmetics.Visible = false;
            panel_Sport.Visible = false;
            panel_Electronic.Visible = false;
            panel_Accesories.Visible = false;
            panelClothes.Visible = false;

            panel_Admin.Location = new Point(0, 25);
            panel_Admin.Visible = true;
        }

        #region Accessories

        private void button_panel_Admin_Accessories_Click(object sender, EventArgs e)
        {
            adapter_admin = new SqlDataAdapter("SELECT * FROM [Accessories]", sqlConnection);
            dataSet_admin = new DataSet();
            adapter_admin.Fill(dataSet_admin);
            dataGridView_Accessories.DataSource = dataSet_admin.Tables[0];

            panel_Admin_Accessories.Location = new Point(0, 0);
            panel_Admin_Accessories.Visible = true;
        }
        private void button_Search_Accessories_Click(object sender, EventArgs e) // поиск по товару
        {
            (dataGridView_Accessories.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%" + textBox_Search.Text + "%'";
        }
        private void button_panel_Admin_Accessories_Back_Click(object sender, EventArgs e) //поиск отсуствующих товаров
        {
            (dataGridView_Accessories.DataSource as DataTable).DefaultView.RowFilter = $"Количество = 0";
        }

        private void button397_Click(object sender, EventArgs e) //поиск кольц
        {
            (dataGridView_Accessories.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Кольцо%'";
        }

        private void button398_Click(object sender, EventArgs e) //поиск пирсинга
        {
            (dataGridView_Accessories.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Пирсинг%'";
        }

        private void button402_Click(object sender, EventArgs e) //поиск чокеров
        {
            (dataGridView_Accessories.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Чокер%'";
        }

        private void button404_Click(object sender, EventArgs e) //поиск подвесок
        {
            (dataGridView_Accessories.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Подвеска%'";
        }

        private void button391_Click(object sender, EventArgs e) //поиск очков
        {
            (dataGridView_Accessories.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Очки%'";
        }

        private void button392_Click(object sender, EventArgs e) //поиск галстуков
        {
            (dataGridView_Accessories.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Галстук%'";
        }

        private void button389_Click(object sender, EventArgs e) //поиск ремней
        {
            (dataGridView_Accessories.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Ремень%'";
        }

        private void button390_Click(object sender, EventArgs e) //поиск кошельков
        {
            (dataGridView_Accessories.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Кошелек%'";
        }

        private void button394_Click(object sender, EventArgs e) //поиск часов
        {
            (dataGridView_Accessories.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Часы%'";
        }

        private void button395_Click(object sender, EventArgs e) //поиск браслетов
        {
            (dataGridView_Accessories.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Браслет%'";
        }

        private void button396_Click(object sender, EventArgs e) //поиск броши
        {
            (dataGridView_Accessories.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Брошь%'";
        }

        private void button388_Click(object sender, EventArgs e) //обновить данные
        {
            panel_Update_DateBD.Location = new Point(286, 189);
            panel_Update_DateBD.Visible = true;
            sqlBuilder = new SqlCommandBuilder(adapter_admin);
            adapter_admin.Update((DataTable)dataGridView_Accessories.DataSource);
        }

        private void button405_Click(object sender, EventArgs e) // кнопка выхода
        {
            panel_Admin_Accessories.Visible = false;
        }

        #endregion Accessories

        #region Clothes

        private void button_panel_Admin_Сlothes_Click(object sender, EventArgs e)
        {
            adapter_admin = new SqlDataAdapter("SELECT * FROM [Clothes]", sqlConnection);
            dataSet_admin = new DataSet();
            adapter_admin.Fill(dataSet_admin);
            dataGridView_Clothes.DataSource = dataSet_admin.Tables[0];

            panel_Admin_Clothes.Location = new Point(0, 0);
            panel_Admin_Clothes.Visible = true;
        }

        private void button418_Click(object sender, EventArgs e) // поиск отсуствующих товаров
        {
            (dataGridView_Clothes.DataSource as DataTable).DefaultView.RowFilter = $"Количество = 0";
        }

        private void button417_Click(object sender, EventArgs e) // поиск товаров
        {
            (dataGridView_Clothes.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%" + textBox1.Text + "%'";
        }

        private void button393_Click_1(object sender, EventArgs e) // обновить данные
        {
            panel_Update_DateBD.Location = new Point(286, 189);
            panel_Update_DateBD.Visible = true;
            sqlBuilder = new SqlCommandBuilder(adapter_admin);
            adapter_admin.Update((DataTable)dataGridView_Clothes.DataSource);
        }

        private void button387_Click_1(object sender, EventArgs e) // выйти
        {
            panel_Admin_Clothes.Visible = false;
        }

        private void button409_Click(object sender, EventArgs e) // муж товары
        {
            (dataGridView_Clothes.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Муж.%'";
        }

        private void button408_Click(object sender, EventArgs e) // женские товры
        {
            (dataGridView_Clothes.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Жен.%'";
        }

        private void button407_Click(object sender, EventArgs e) // футболки
        {
            (dataGridView_Clothes.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Футболка%'";
        }

        private void button406_Click(object sender, EventArgs e) // худи
        {
            (dataGridView_Clothes.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Худи%'";
        }

        private void button416_Click(object sender, EventArgs e) // свитшоты
        {
            (dataGridView_Clothes.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Свитшот%'";
        }

        private void button415_Click(object sender, EventArgs e) // рубашки
        {
            (dataGridView_Clothes.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Рубашка%'";
        }

        private void button414_Click(object sender, EventArgs e) // джинсы
        {
            (dataGridView_Clothes.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Джинсы%'";
        }

        private void button413_Click(object sender, EventArgs e) // брюки
        {
            (dataGridView_Clothes.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Брюки%'";
        }

        private void button412_Click(object sender, EventArgs e) // леггинсы
        {
            (dataGridView_Clothes.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Леггинсы%'";
        }

        private void button411_Click(object sender, EventArgs e) // платья
        {
            (dataGridView_Clothes.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Платья%'";
        }

        private void button410_Click(object sender, EventArgs e) // топы
        {
            (dataGridView_Clothes.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Топ%'";
        }

        private void button386_Click(object sender, EventArgs e) // нижнее белье
        {
            (dataGridView_Clothes.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Трусы%'";
        }

        #endregion Clothes

        #region Cosmetics

        private void button_panel_Admin_Cosmetics_Click(object sender, EventArgs e)
        {
            adapter_admin = new SqlDataAdapter("SELECT * FROM [Cosmetics]", sqlConnection);
            dataSet_admin = new DataSet();
            adapter_admin.Fill(dataSet_admin);
            dataGridView_Cosmetics.DataSource = dataSet_admin.Tables[0];

            panel_Admin_Cosmetics.Location = new Point(0, 0);
            panel_Admin_Cosmetics.Visible = true;
        }

        private void button430_Click(object sender, EventArgs e) //поиск по отсуствующим товарам
        {
            (dataGridView_Cosmetics.DataSource as DataTable).DefaultView.RowFilter = $"Количетво = 0";
        }

        private void button429_Click(object sender, EventArgs e) //поиск
        {
            (dataGridView_Cosmetics.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%" + textBox2.Text + "%'";
        }

        private void button401_Click(object sender, EventArgs e) //обновить
        {
            panel_Update_DateBD.Location = new Point(286, 189);
            panel_Update_DateBD.Visible = true;
            sqlBuilder = new SqlCommandBuilder(adapter_admin);
            adapter_admin.Update((DataTable)dataGridView_Cosmetics.DataSource);
        }

        private void button400_Click(object sender, EventArgs e) //выход
        {
            panel_Admin_Cosmetics.Visible = false;
        }

        private void button421_Click(object sender, EventArgs e) //карандаши
        {
            (dataGridView_Cosmetics.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Карандаш%'";
        }

        private void button420_Click(object sender, EventArgs e) //крема
        {
            (dataGridView_Cosmetics.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Крем%'";
        }

        private void button419_Click(object sender, EventArgs e) //пудры
        {
            (dataGridView_Cosmetics.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Пудра%'";
        }

        private void button403_Click(object sender, EventArgs e) //гель
        {
            (dataGridView_Cosmetics.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Гель%'";
        }

        private void button428_Click(object sender, EventArgs e) //палочки
        {
            (dataGridView_Cosmetics.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Палочки%'";
        }

        private void button427_Click(object sender, EventArgs e) //Сыворотки
        {
            (dataGridView_Cosmetics.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Сыворотка%'";
        }

        private void button426_Click(object sender, EventArgs e) //маски
        {
            (dataGridView_Cosmetics.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Маска%'";
        }

        private void button425_Click(object sender, EventArgs e) //парфюмерия
        {
            (dataGridView_Cosmetics.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Парфюмерная%'";
        }

        private void button424_Click(object sender, EventArgs e) //туалетная
        {
            (dataGridView_Cosmetics.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Туалетная%'";
        }

        private void button423_Click(object sender, EventArgs e) //румян
        {
            (dataGridView_Cosmetics.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Румян%'";
        }

        private void button422_Click(object sender, EventArgs e) //масла
        {
            (dataGridView_Cosmetics.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Масло%'";
        }

        private void button399_Click(object sender, EventArgs e) //наборы
        {
            (dataGridView_Cosmetics.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Набор%'";
        }
        #endregion Cosmetics

        #region Appliances

        private void button_panel_Admin_Appliances_Click(object sender, EventArgs e)
        {
            adapter_admin = new SqlDataAdapter("SELECT * FROM [Appliances]", sqlConnection);
            dataSet_admin = new DataSet();
            adapter_admin.Fill(dataSet_admin);
            dataGridView_Appliances.DataSource = dataSet_admin.Tables[0];

            panel_Admin_Appliances.Location = new Point(0, 0);
            panel_Admin_Appliances.Visible = true;
        }

        private void button477_Click(object sender, EventArgs e) //поиск по отсуствующим товарам
        {
            (dataGridView_Appliances.DataSource as DataTable).DefaultView.RowFilter = $"Количеcтво = 0";
        }

        private void button476_Click(object sender, EventArgs e) //поиск 
        {
            (dataGridView_Appliances.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%" + textBox5.Text + "%'";
        }

        private void button464_Click(object sender, EventArgs e) //обновление бд
        {
            panel_Update_DateBD.Location = new Point(286, 189);
            panel_Update_DateBD.Visible = true;
            sqlBuilder = new SqlCommandBuilder(adapter_admin);
            adapter_admin.Update((DataTable)dataGridView_Appliances.DataSource);
        }

        private void button463_Click(object sender, EventArgs e) //выйти
        {
            panel_Admin_Appliances.Visible = false;
        }

        private void button468_Click(object sender, EventArgs e) //холодильники
        {
            (dataGridView_Appliances.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Холодильник%'";
        }

        private void button467_Click(object sender, EventArgs e) //стиральные машины
        {
            (dataGridView_Appliances.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Стиральная машина%'";
        }

        private void button466_Click(object sender, EventArgs e) //блендер
        {
            (dataGridView_Appliances.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Блендер%'";
        }

        private void button465_Click(object sender, EventArgs e) //Масляный радиаторы
        {
            (dataGridView_Appliances.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Масляный радиатор%'";
        }

        private void button475_Click(object sender, EventArgs e) //кофемашины
        {
            (dataGridView_Appliances.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Кофемашина%'";
        }

        #endregion Appliances

        #region Electronic

        private void button_panel_Admin_Electronics_Click(object sender, EventArgs e)
        {
            adapter_admin = new SqlDataAdapter("SELECT * FROM [Electronics]", sqlConnection);
            dataSet_admin = new DataSet();
            adapter_admin.Fill(dataSet_admin);
            dataGridView_Electronics.DataSource = dataSet_admin.Tables[0];

            panel_Admin_Electronics.Location = new Point(0, 0);
            panel_Admin_Electronics.Visible = true;
        }

        private void button446_Click(object sender, EventArgs e) //поиск по осуствующим товарам
        {
            (dataGridView_Electronics.DataSource as DataTable).DefaultView.RowFilter = $"Количество = 0";
        }

        private void button445_Click(object sender, EventArgs e) //поиск 
        {
            (dataGridView_Electronics.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%" + textBox3.Text + "%'"; 
        }

        private void button433_Click(object sender, EventArgs e) //обновление бд
        {
            panel_Update_DateBD.Location = new Point(286, 189);
            panel_Update_DateBD.Visible = true;
            sqlBuilder = new SqlCommandBuilder(adapter_admin);
            adapter_admin.Update((DataTable)dataGridView_Electronics.DataSource);
        }

        private void button432_Click(object sender, EventArgs e) //выйти
        {
            panel_Admin_Electronics.Visible = false;
        }

        private void button437_Click(object sender, EventArgs e) //наушники
        {
            (dataGridView_Electronics.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Наушники%'";
        }

        private void button436_Click(object sender, EventArgs e) //смартфоны
        {
            (dataGridView_Electronics.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Смартфон%'";
        }

        private void button435_Click(object sender, EventArgs e) //камеры
        {
            (dataGridView_Electronics.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Камера%'";
        }

        private void button434_Click(object sender, EventArgs e) //Ноутбуки
        {
            (dataGridView_Electronics.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Ноутбук%'";
        }

        private void button444_Click(object sender, EventArgs e) //Телевизор
        {
            (dataGridView_Electronics.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Телевизор%'";
        }

        private void button443_Click(object sender, EventArgs e) //Коннекторы
        {
            (dataGridView_Electronics.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Коннектор%'";
        }

        private void button442_Click(object sender, EventArgs e) //Модули
        {
            (dataGridView_Electronics.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Модуль%'";
        }

        private void button441_Click(object sender, EventArgs e) //Датчики
        {
            (dataGridView_Electronics.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Датчик%'";
        }

        private void button440_Click(object sender, EventArgs e) //Пульты
        {
            (dataGridView_Electronics.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Пульт%'";
        }

        private void button439_Click(object sender, EventArgs e) //Розетки
        {
            (dataGridView_Electronics.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Розетка%'";
        }

        private void button438_Click(object sender, EventArgs e) //Адаптеры
        {
            (dataGridView_Electronics.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Адаптер%'";
        }

        #endregion Electronic

        #region Sport

        private void button_panel_Admin_Sport_Click(object sender, EventArgs e)
        {
            adapter_admin = new SqlDataAdapter("SELECT * FROM [Sport]", sqlConnection);
            dataSet_admin = new DataSet();
            adapter_admin.Fill(dataSet_admin);
            dataGridView_Sport.DataSource = dataSet_admin.Tables[0];

            panel_Admin_Sport.Location = new Point(0, 0);
            panel_Admin_Sport.Visible = true;
        }

        private void button460_Click(object sender, EventArgs e) //поиск по отсуствующим товарам
        {
            (dataGridView_Sport.DataSource as DataTable).DefaultView.RowFilter = $"Количество = 0";
        }

        private void button459_Click(object sender, EventArgs e) //поиск
        {
            (dataGridView_Sport.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%" + textBox4.Text + "%'";
        }

        private void button447_Click(object sender, EventArgs e) //обработка
        {
            panel_Update_DateBD.Location = new Point(286, 189);
            panel_Update_DateBD.Visible = true;
            sqlBuilder = new SqlCommandBuilder(adapter_admin);
            adapter_admin.Update((DataTable)dataGridView_Sport.DataSource);
        }

        private void button431_Click(object sender, EventArgs e) //выйти
        {
            panel_Admin_Sport.Visible = false;
        }

        private void button451_Click(object sender, EventArgs e) //велосипеды
        {
            (dataGridView_Sport.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Велосипед%'";
        }

        private void button450_Click(object sender, EventArgs e) //коврики
        {
            (dataGridView_Sport.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Коврик%'";
        }

        private void button449_Click(object sender, EventArgs e) //шлема
        {
            (dataGridView_Sport.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Шлем%'";
        }

        private void button448_Click(object sender, EventArgs e) //лыжи
        {
            (dataGridView_Sport.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Лыжи%'";
        }

        private void button458_Click(object sender, EventArgs e) //сноуборды
        {
            (dataGridView_Sport.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Сноуборд%'";
        }

        private void button457_Click(object sender, EventArgs e) //коньки
        {
            (dataGridView_Sport.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Коньки%'";
        }

        private void button456_Click(object sender, EventArgs e) //клюшки
        {
            (dataGridView_Sport.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Клюшка%'";
        }

        private void button455_Click(object sender, EventArgs e) //Очки для плавания
        {
            (dataGridView_Sport.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Очки для плавания%'";
        }

        private void button454_Click(object sender, EventArgs e) //Гидрокостюм
        {
            (dataGridView_Sport.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Гидрокостюм%'";
        }

        private void button453_Click(object sender, EventArgs e) //кроссовки
        {
            (dataGridView_Sport.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Кроссовки%'";
        }

        private void button452_Click(object sender, EventArgs e) //купальники
        {
            (dataGridView_Sport.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Купальник%'";
        }

        private void button461_Click(object sender, EventArgs e) //плавки
        {
            (dataGridView_Sport.DataSource as DataTable).DefaultView.RowFilter = $"Модель LIKE '%Плавки%'";
        }

        #endregion Sport


        #region PointIssue

        private void button_panel_Admin_PointIssue_Click(object sender, EventArgs e)
        {
            adapter_admin = new SqlDataAdapter("SELECT * FROM [PointIssue]", sqlConnection);
            dataSet_admin = new DataSet();
            adapter_admin.Fill(dataSet_admin);
            dataGridView_PointIssue.DataSource = dataSet_admin.Tables[0];

            panel_Admin_PointIssue.Location = new Point(0, 0);
            panel_Admin_PointIssue.Visible = true;
        }

        private void button_admin_city_Click(object sender, EventArgs e) //поиск по городам
        {
            (dataGridView_PointIssue.DataSource as DataTable).DefaultView.RowFilter = $"Город LIKE '%" + textBox_admin_city.Text + "%'";
        }

        private void button_admin_adress_Click(object sender, EventArgs e) //поиск по адресам
        {
            (dataGridView_PointIssue.DataSource as DataTable).DefaultView.RowFilter = $"Адрес LIKE '%" + textBox_admin_adress.Text + "%'";
        }

        private void button472_Click(object sender, EventArgs e) //обновление
        {
            panel_Update_DateBD.Location = new Point(286, 189);
            panel_Update_DateBD.Visible = true;
            sqlBuilder = new SqlCommandBuilder(adapter_admin);
            adapter_admin.Update((DataTable)dataGridView_PointIssue.DataSource);
        }

        private void button471_Click(object sender, EventArgs e) //выход
        {
            panel_Admin_PointIssue.Visible = false;
        }

        #endregion PointIssue

        #region Users

        private void button_panel_Admin_Users_Click(object sender, EventArgs e)
        {
            adapter_admin = new SqlDataAdapter("SELECT * FROM [Users]", sqlConnection);
            dataSet_admin = new DataSet();
            adapter_admin.Fill(dataSet_admin);
            dataGridView_Users.DataSource = dataSet_admin.Tables[0];

            panel_Admin_Users.Location = new Point(0, 0);
            panel_Admin_Users.Visible = true;
        }

        private void button481_Click(object sender, EventArgs e) //поиск пользователей user
        {
            (dataGridView_Users.DataSource as DataTable).DefaultView.RowFilter = $"Статус LIKE '%user%'";
        }

        private void button482_Click(object sender, EventArgs e) //поиск пользователей admin
        {
            (dataGridView_Users.DataSource as DataTable).DefaultView.RowFilter = $"Статус LIKE '%admin%'";
        }

        private void button483_Click(object sender, EventArgs e) //поиск пользователей по login
        {
            (dataGridView_Users.DataSource as DataTable).DefaultView.RowFilter = $"Login LIKE '%" + textBox8.Text + "%'";
        }

        private void button478_Click(object sender, EventArgs e) //поиск пользователей по фамилии
        {
            (dataGridView_Users.DataSource as DataTable).DefaultView.RowFilter = $"Фамилия LIKE '%" + textBox7.Text + "%'";
        }

        private void button462_Click(object sender, EventArgs e) //поиск ползователй по телефону
        {
            (dataGridView_Users.DataSource as DataTable).DefaultView.RowFilter = $"Телефон LIKE '%" + textBox6.Text + "%'";
        }

        private void button480_Click(object sender, EventArgs e) //обновление
        {
            panel_Update_DateBD.Location = new Point(286, 189);
            panel_Update_DateBD.Visible = true;
            sqlBuilder = new SqlCommandBuilder(adapter_admin);
            adapter_admin.Update((DataTable)dataGridView_Users.DataSource);
        }

        private void button479_Click(object sender, EventArgs e) //выйти
        {
            panel_Admin_Users.Visible = false;
        }

        #endregion Users

        #region Order

        private void button_panel_Admin_Order_Click(object sender, EventArgs e)
        {
            adapter_admin = new SqlDataAdapter("SELECT * FROM [Order]", sqlConnection);
            dataSet_admin = new DataSet();
            adapter_admin.Fill(dataSet_admin);
            dataGridView_Order.DataSource = dataSet_admin.Tables[0];

            panel_Admin_Order.Location = new Point(0, 0);
            panel_Admin_Order.Visible = true;
        }

        private void button473_Click(object sender, EventArgs e)
        {
            (dataGridView_Order.DataSource as DataTable).DefaultView.RowFilter = $"Доставлено LIKE '%Доставлено%'";
        }

        private void button474_Click(object sender, EventArgs e)
        {
            (dataGridView_Order.DataSource as DataTable).DefaultView.RowFilter = $"Доставлено LIKE '%Не доставлен%'";
        }

        private void button_numberorder_Click(object sender, EventArgs e) //поиск по номер заказа
        {
            if (textBox_admin_numberorder.Text != "")
            {
                (dataGridView_Order.DataSource as DataTable).DefaultView.RowFilter = $"[Номер заказа] = '" + Convert.ToInt32(textBox_admin_numberorder.Text) + "'";
            }
        }

        private void button_emailorder_Click(object sender, EventArgs e) //поиск по почте заказчика
        {
            (dataGridView_Order.DataSource as DataTable).DefaultView.RowFilter = $"[Email Заказчика] LIKE '%" + textBox_admin_emailorder.Text + "%'";
        }

        private void button_telephoneorder_Click(object sender, EventArgs e) //поиск по номеру телефона заказчика
        {
            (dataGridView_Order.DataSource as DataTable).DefaultView.RowFilter = $"[Телефон заказчика] LIKE '%" + textBox_admin_telephoneorder.Text + "%'";
        }

        private void button470_Click(object sender, EventArgs e)
        {
            panel_Update_DateBD.Location = new Point(286, 189);
            panel_Update_DateBD.Visible = true;
            sqlBuilder = new SqlCommandBuilder(adapter_admin);
            adapter_admin.Update((DataTable)dataGridView_Order.DataSource);
        }

        private void button469_Click(object sender, EventArgs e)
        {
            panel_Admin_Order.Visible = false;
        }

        #endregion Order

        private void panel_Update_DateBD_btn_Click(object sender, EventArgs e)
        {
            panel_Update_DateBD.Visible = false;
        }

        #endregion AdminPanel


        #region SwitchColorPanelButton
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(134, 124, 185);
            label1.ForeColor = Color.FromArgb(20, 15, 30);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(20, 15, 30);
            label1.ForeColor = Color.FromArgb(134, 124, 185);
        }
        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.BackColor = Color.FromArgb(134, 124, 185);
            label2.ForeColor = Color.FromArgb(20, 15, 30);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.BackColor = Color.FromArgb(20, 15, 30);
            label2.ForeColor = Color.FromArgb(134, 124, 185);

        }
        #endregion SwitchColorPanelButton
        
        #region SwitchColorButton
        private void btnMain_MouseEnter(object sender, EventArgs e)
        {
            btnMain.BackColor = Color.FromArgb(51, 34, 71);
        }

        private void btnMain_MouseLeave(object sender, EventArgs e)
        {
            btnMain.BackColor = Color.FromArgb(11, 7, 17);
        }

        private void btnShop_MouseEnter(object sender, EventArgs e)
        {
            btnShop.BackColor = Color.FromArgb(51, 34, 71);
        }

        private void btnShop_MouseLeave(object sender, EventArgs e)
        {
            btnShop.BackColor = Color.FromArgb(11, 7, 17);
        }

        private void btnAccount_MouseEnter(object sender, EventArgs e)
        {
            btnAccount.BackColor = Color.FromArgb(51, 34, 71);
        }

        private void btnAccount_MouseLeave(object sender, EventArgs e)
        {
            btnAccount.BackColor = Color.FromArgb(11, 7, 17);
        }

        private void btnHelp_MouseDown(object sender, MouseEventArgs e) // не удалять
        {
        }

        private void btnHelp_MouseLeave(object sender, EventArgs e)
        {
            btnHelp.BackColor = Color.FromArgb(11, 7, 17);
        }

        private void btnHelp_MouseEnter(object sender, EventArgs e)
        {
            btnHelp.BackColor = Color.FromArgb(51, 34, 71);
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.FromArgb(51, 34, 71);
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.FromArgb(11, 7, 17);
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            btnMain.BackColor = Color.FromArgb(51, 34, 71);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            btnMain.BackColor = Color.FromArgb(11, 7, 17);
        }
        #endregion SwitchColorButton


        #region Local_Basket_DB
        public void LoadData() //загрузка локальной бд
        {
            adapter = new SqlDataAdapter("SELECT *, 'Delete' AS [Удалить] FROM [Local_Order_User]", sqlConnection);
            sqlBuilder = new SqlCommandBuilder(adapter);
            sqlBuilder.GetDeleteCommand();

            dataSet = new DataSet();
            adapter.Fill(dataSet, "Local_Order_User");
            dataGridView1.DataSource = dataSet.Tables["Local_Order_User"];

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                dataGridView1[4, i] = linkCell;
            }
        }
        public void RealodData() //перегрузка локальной бд
        {
            dataSet.Tables["Local_Order_User"].Clear();

            adapter.Fill(dataSet, "Local_Order_User");
            dataGridView1.DataSource = dataSet.Tables["Local_Order_User"];

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                dataGridView1[4, i] = linkCell;
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) //удаление товара из локальной бд
        {
            if (e.ColumnIndex == 4)
            {
                if (e.RowIndex > -1)
                {
                    string task = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    if (task == "Delete")
                    {
                        panel_Delete_Order.Location = new Point(343, 252);
                        panel_Delete_Order.Visible = true;
                    }
                }
            }

            RealodData();
        }
        public void Delete_Order_from_Basket() // реализация удаления товара из локальной бд
        {
            DataGridViewCellEventArgs e = new DataGridViewCellEventArgs(0, 0);

            int rowIndex = e.RowIndex;

            dataGridView1.Rows.RemoveAt(rowIndex);
            dataSet.Tables["Local_Order_User"].Rows[rowIndex].Delete();
            adapter.Update(dataSet, "Local_Order_User");

            labelSumm.Text = "0";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                labelSumm.Text = Convert.ToString(double.Parse(labelSumm.Text) + double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()) * int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()));
            }
        }
        private void Delete_Order_button_Yes_Click(object sender, EventArgs e) // согласие на удаление
        {
            Delete_Order_from_Basket();
            panel_Delete_Order.Visible = false;
        }
        private void Delete_Order_button_No_Click(object sender, EventArgs e) // не согласие на удаление
        {
            panel_Delete_Order.Visible = false;
        }
        private void DB_button_Update_Click(object sender, EventArgs e) //обновление бд
        {
            labelSumm.Text = "0";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                labelSumm.Text = Convert.ToString(double.Parse(labelSumm.Text) + double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()) * int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()));
            }
            RealodData();
        }
        #endregion Local_Basket_DB

        #region AddBascket
        public async void Accessories_Table(string label) //Добавление аксессуаров
        {
            string labelItem = "";
            string priceItem = "";
            string countItem = "";

            SqlCommand command_reader = new SqlCommand("SELECT * FROM [Accessories] WHERE [Модель] LIKE N'%" + label + "%'", sqlConnection);
            var label_command = command_reader.ExecuteReader();

            if (label_command.Read())
            {
                labelItem = label_command["Модель"].ToString();
                label_command.Close();
            }

            var price_command = command_reader.ExecuteReader();
            if (price_command.Read())
            {
                priceItem = price_command["Цена"].ToString();
                price_command.Close();
            }

            var count_command = command_reader.ExecuteReader();
            if (count_command.Read())
            {
                countItem = count_command["Количество"].ToString();
                count_command.Close();
            }

            if (Convert.ToInt32(countItem) <= 0) // проверка на наличии товара на складе
            {
                panelCountItem.Location = new Point(320, 305);
                panelCountItem.Visible = true;
            }
            else
            {
                panel_Count.Location = new Point(320, 305);
                panel_Count.Visible = true;

                await Task.Delay(5000); // задержка для запроса sql

                if (count != 0)
                {
                    SqlCommand command_insert = new SqlCommand("INSERT INTO [Local_Order_User] ([Заказ], [Цена], [Количество]) VALUES (@order, @price, @count)", sqlConnection);

                    command_insert.Parameters.Add("@order", SqlDbType.NVarChar).Value = labelItem; //добавить название товара
                    command_insert.Parameters.Add("@price", SqlDbType.Money).Value = priceItem; //добавить цену товара
                    command_insert.Parameters.Add("@count", SqlDbType.Int).Value = count; //добавить количество товара
                    command_insert.ExecuteNonQuery();
                }

                count = 0;
            }
        }

        public async void Appliances_Table(string label) //Добавление бытовой техники
        {
            string labelItem = "";
            string priceItem = "";
            string countItem = "";

            SqlCommand command_reader = new SqlCommand("SELECT * FROM [Appliances] WHERE [Модель] LIKE N'%" + label + "%'", sqlConnection);
            var label_command = command_reader.ExecuteReader();

            if (label_command.Read())
            {
                labelItem = label_command["Модель"].ToString();
                label_command.Close();
            }

            var price_command = command_reader.ExecuteReader();
            if (price_command.Read())
            {
                priceItem = price_command["Цена"].ToString();
                price_command.Close();
            }

            var count_command = command_reader.ExecuteReader();
            if (count_command.Read())
            {
                countItem = count_command["Количество"].ToString();
                count_command.Close();
            }

            if (Convert.ToInt32(countItem) <= 0) // проверка на наличии товара на складе
            {
                panelCountItem.Location = new Point(320, 305);
                panelCountItem.Visible = true;
            }
            else
            {
                panel_Count.Location = new Point(320, 305);
                panel_Count.Visible = true;

                await Task.Delay(5000); // задержка для запроса sql

                if (count != 0)
                {
                    SqlCommand command_insert = new SqlCommand("INSERT INTO [Local_Order_User] ([Заказ], [Цена], [Количество]) VALUES (@order, @price, @count)", sqlConnection);

                    command_insert.Parameters.Add("@order", SqlDbType.NVarChar).Value = labelItem; //добавить название товара
                    command_insert.Parameters.Add("@price", SqlDbType.Money).Value = priceItem; //добавить цену товара
                    command_insert.Parameters.Add("@count", SqlDbType.Int).Value = count; //добавить количество товара
                    command_insert.ExecuteNonQuery();
                }

                count = 0;
            }
        }

        public async void Clothes_Table(string label) //Добавление одежды
        {
            string labelItem = "";
            string priceItem = "";
            string countItem = "";

            SqlCommand command_reader = new SqlCommand("SELECT * FROM [Clothes] WHERE [Модель] LIKE N'%" + label + "%'", sqlConnection);
            var label_command = command_reader.ExecuteReader();

            if (label_command.Read())
            {
                labelItem = label_command["Модель"].ToString();
                label_command.Close();
            }

            var price_command = command_reader.ExecuteReader();
            if (price_command.Read())
            {
                priceItem = price_command["Цена"].ToString();
                price_command.Close();
            }

            var count_command = command_reader.ExecuteReader();
            if (count_command.Read())
            {
                countItem = count_command["Количество"].ToString();
                count_command.Close();
            }

            if (Convert.ToInt32(countItem) <= 0) // проверка на наличии товара на складе
            {
                panelCountItem.Location = new Point(320, 305);
                panelCountItem.Visible = true;
            }
            else
            {
                panel_Count.Location = new Point(320, 305);
                panel_Count.Visible = true;

                await Task.Delay(5000); // задержка для запроса sql

                if (count != 0)
                {
                    SqlCommand command_insert = new SqlCommand("INSERT INTO [Local_Order_User] ([Заказ], [Цена], [Количество]) VALUES (@order, @price, @count)", sqlConnection);

                    command_insert.Parameters.Add("@order", SqlDbType.NVarChar).Value = labelItem; //добавить название товара
                    command_insert.Parameters.Add("@price", SqlDbType.Money).Value = priceItem; //добавить цену товара
                    command_insert.Parameters.Add("@count", SqlDbType.Int).Value = count; //добавить количество товара
                    command_insert.ExecuteNonQuery();
                }

                count = 0;
            }
        }

        public async void Cosmetics_Table(string label) //Добавление косметики
        {
            string labelItem = "";
            string priceItem = "";
            string countItem = "";

            SqlCommand command_reader = new SqlCommand("SELECT * FROM [Cosmetics] WHERE [Модель] LIKE N'%" + label + "%'", sqlConnection);
            var label_command = command_reader.ExecuteReader();

            if (label_command.Read())
            {
                labelItem = label_command["Модель"].ToString();
                label_command.Close();
            }

            var price_command = command_reader.ExecuteReader();
            if (price_command.Read())
            {
                priceItem = price_command["Цена"].ToString();
                price_command.Close();
            }

            var count_command = command_reader.ExecuteReader();
            if (count_command.Read())
            {
                countItem = count_command["Количетво"].ToString();
                count_command.Close();
            }

            if (Convert.ToInt32(countItem) <= 0) // проверка на наличии товара на складе
            {
                panelCountItem.Location = new Point(320, 305);
                panelCountItem.Visible = true;
            }
            else
            {
                panel_Count.Location = new Point(320, 305);
                panel_Count.Visible = true;

                await Task.Delay(5000); // задержка для запроса sql

                if (count != 0)
                {
                    SqlCommand command_insert = new SqlCommand("INSERT INTO [Local_Order_User] ([Заказ], [Цена], [Количество]) VALUES (@order, @price, @count)", sqlConnection);

                    command_insert.Parameters.Add("@order", SqlDbType.NVarChar).Value = labelItem; //добавить название товара
                    command_insert.Parameters.Add("@price", SqlDbType.Money).Value = priceItem; //добавить цену товара
                    command_insert.Parameters.Add("@count", SqlDbType.Int).Value = count; //добавить количество товара
                    command_insert.ExecuteNonQuery();
                }

                count = 0;
            }
        }

        public async void Electronics_Table(string label) //Добавление электроники
        {
            string labelItem = "";
            string priceItem = "";
            string countItem = "";

            SqlCommand command_reader = new SqlCommand("SELECT * FROM [Electronics] WHERE [Модель] LIKE N'%" + label + "%'", sqlConnection);
            var label_command = command_reader.ExecuteReader();

            if (label_command.Read())
            {
                labelItem = label_command["Модель"].ToString();
                label_command.Close();
            }

            var price_command = command_reader.ExecuteReader();
            if (price_command.Read())
            {
                priceItem = price_command["Цена"].ToString();
                price_command.Close();
            }

            var count_command = command_reader.ExecuteReader();
            if (count_command.Read())
            {
                countItem = count_command["Количество"].ToString();
                count_command.Close();
            }

            if (Convert.ToInt32(countItem) <= 0) // проверка на наличии товара на складе
            {
                panelCountItem.Location = new Point(320, 305);
                panelCountItem.Visible = true;
            }
            else
            {
                panel_Count.Location = new Point(320, 305);
                panel_Count.Visible = true;

                await Task.Delay(5000); // задержка для запроса sql

                if (count != 0)
                {
                    SqlCommand command_insert = new SqlCommand("INSERT INTO [Local_Order_User] ([Заказ], [Цена], [Количество]) VALUES (@order, @price, @count)", sqlConnection);

                    command_insert.Parameters.Add("@order", SqlDbType.NVarChar).Value = labelItem; //добавить название товара
                    command_insert.Parameters.Add("@price", SqlDbType.Money).Value = priceItem; //добавить цену товара
                    command_insert.Parameters.Add("@count", SqlDbType.Int).Value = count; //добавить количество товара
                    command_insert.ExecuteNonQuery();
                }

                count = 0;
            }
        }

        public async void Sport_Table(string label) //Добавление спорт товаров
        {
            string labelItem = "";
            string priceItem = "";
            string countItem = "";

            SqlCommand command_reader = new SqlCommand("SELECT * FROM [Sport] WHERE [Модель] LIKE N'%" + label + "%'", sqlConnection);
            var label_command = command_reader.ExecuteReader();

            if (label_command.Read())
            {
                labelItem = label_command["Модель"].ToString();
                label_command.Close();
            }

            var price_command = command_reader.ExecuteReader();
            if (price_command.Read())
            {
                priceItem = price_command["Цена"].ToString();
                price_command.Close();
            }

            var count_command = command_reader.ExecuteReader();
            if (count_command.Read())
            {
                countItem = count_command["Количество"].ToString();
                count_command.Close();
            }

            if (Convert.ToInt32(countItem) <= 0) // проверка на наличии товара на складе
            {
                panelCountItem.Location = new Point(320, 305);
                panelCountItem.Visible = true;
            }
            else
            {
                panel_Count.Location = new Point(320, 305);
                panel_Count.Visible = true;

                await Task.Delay(5000); // задержка для запроса sql

                if (count != 0)
                {
                    SqlCommand command_insert = new SqlCommand("INSERT INTO [Local_Order_User] ([Заказ], [Цена], [Количество]) VALUES (@order, @price, @count)", sqlConnection);

                    command_insert.Parameters.Add("@order", SqlDbType.NVarChar).Value = labelItem; //добавить название товара
                    command_insert.Parameters.Add("@price", SqlDbType.Money).Value = priceItem; //добавить цену товара
                    command_insert.Parameters.Add("@count", SqlDbType.Int).Value = count; //добавить количество товара
                    command_insert.ExecuteNonQuery();
                }

                count = 0;
            }
        }

        private void buttonCount_Click(object sender, EventArgs e) //обработка количества
        {
            count = Convert.ToInt32(numericUpDown1.Value);
            numericUpDown1.Value = 1;

            panel_Add_In_Basket.Location = new Point(310, 300);
            panel_Add_In_Basket.Visible = true;

            panel_Count.Visible = false;
        }
        private void buttonCountItem_Click(object sender, EventArgs e)
        {
            panelCountItem.Visible = false;
        }
        private void button_panel_Add_In_Basket_Click(object sender, EventArgs e)
        {
            panel_Add_In_Basket.Visible = false;
        }
        #endregion AddBascket
        

        #region Accessories

        #region Accessories_Man
        private void panel_Accessories_Man_Button_MouseClick(object sender, MouseEventArgs e) //Аксессуары для мужиков
        {
            panel_Accesories_Man.Location = new Point(0, 0);
            panel_Accesories_Man.Visible = true;
        }

        private void panel_Accessories_Man_Button_MouseEnter(object sender, EventArgs e) //Меняем цвет при навигации
        {
            panel_Accessories_Man_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Accessories_Man_Button_MouseLeave(object sender, EventArgs e) //Меняем цвет когда мышь уходит
        {
            panel_Accessories_Man_Button.BackColor = Color.FromArgb(28, 26, 38);
        }

        private void panel_Accessories_Man_Button_Back_Click(object sender, EventArgs e) //Кнопка к выбору муж или жен аксессуары
        {
            panel_Accesories_Man.Visible = false;
        }

        #region Wallets
        private void panel_Accessories_Man_Wallets_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Accesories_Man_Wallets.Location = new Point(0, 0);
            panel_Accesories_Man_Wallets.Visible = true;
        }

        private void panel_Accessories_Man_Wallets_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Accessories_Man_Wallets_Button.BackColor = Color.FromArgb(34, 32, 44);
        }

        private void panel_Accessories_Man_Wallets_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Accessories_Man_Wallets_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void panel_Accessories_Man_Button_Back_2_Click(object sender, EventArgs e) //Кнопка к выбору муж аксессуары
        {
            panel_Accesories_Man_Wallets.Visible = false;
        }

        #region Shop_Wallets
        private void button15_Click(object sender, EventArgs e)
        {
            Accessories_Table(label28.Text);
        }
        private void button16_Click(object sender, EventArgs e)
        {
            Accessories_Table(label43.Text);
        }
        private void button19_Click(object sender, EventArgs e)
        {
            Accessories_Table(label45.Text);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Accessories_Table(label47.Text);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Accessories_Table(label49.Text);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Accessories_Table(label51.Text);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Accessories_Table(label53.Text);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Accessories_Table(label55.Text);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Accessories_Table(label57.Text);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Accessories_Table(label59.Text);
        }

        #endregion Shop_Wallets

        #endregion Wallets

        #region Belst
        private void panel_Accessories_Man_Belts_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Accesories_Man_Belts.Location = new Point(0, 0);
            panel_Accesories_Man_Belts.Visible = true;
        }
        private void panel_Accessories_Man_Belts_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Accessories_Man_Belts_Button.BackColor = Color.FromArgb(34, 32, 44);
        }

        private void panel_Accessories_Man_Belts_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Accessories_Man_Belts_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button35_Click(object sender, EventArgs e)
        {
            panel_Accesories_Man_Belts.Visible = false;
        }

        #region Shop_Belst
        private void button36_Click(object sender, EventArgs e)
        {
            Accessories_Table(label81.Text);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            Accessories_Table(label79.Text);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            Accessories_Table(label77.Text);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            Accessories_Table(label75.Text);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            Accessories_Table(label73.Text);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            Accessories_Table(label71.Text);
        }

        private void button37_Click(object sender, EventArgs e)
        {
            Accessories_Table(label83.Text);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            Accessories_Table(label69.Text);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            Accessories_Table(label67.Text);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Accessories_Table(label65.Text);
        }

        #endregion Shop_Belst

        #endregion Belst

        #region Neckties
        private void panel_Accessories_Man_Neckties_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Accesories_Man_Neckties.Location = new Point(0, 0);
            panel_Accesories_Man_Neckties.Visible = true;
        }
        private void panel_Accessories_Man_Neckties_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Accessories_Man_Neckties_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Accessories_Man_Neckties_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Accessories_Man_Neckties_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button46_Click(object sender, EventArgs e)
        {
            panel_Accesories_Man_Neckties.Visible = false;
        }

        #region Shop_Neckties
        private void button47_Click(object sender, EventArgs e)
        {
            Accessories_Table(label101.Text);
        }

        private void button45_Click(object sender, EventArgs e)
        {
            Accessories_Table(label99.Text);
        }

        private void button44_Click(object sender, EventArgs e)
        {
            Accessories_Table(label97.Text);
        }

        private void button43_Click(object sender, EventArgs e)
        {
            Accessories_Table(label95.Text);
        }

        private void button42_Click(object sender, EventArgs e)
        {
            Accessories_Table(label93.Text);
        }

        private void button41_Click(object sender, EventArgs e)
        {
            Accessories_Table(label91.Text);
        }

        private void button48_Click(object sender, EventArgs e)
        {
            Accessories_Table(label103.Text);
        }

        private void button40_Click(object sender, EventArgs e)
        {
            Accessories_Table(label89.Text);
        }

        private void button39_Click(object sender, EventArgs e)
        {
            Accessories_Table(label87.Text);
        }

        private void button38_Click(object sender, EventArgs e)
        {
            Accessories_Table(label85.Text);
        }

        #endregion Shop_Neckties

        #endregion Neckties

        #region SunGlasses
        private void panel_Accessories_Man_SunGlasses_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Accesories_Man_SunGlasses.Location = new Point(0, 0);
            panel_Accesories_Man_SunGlasses.Visible = true;
        }
        private void panel_Accessories_Man_SunGlasses_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Accessories_Man_SunGlasses_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Accessories_Man_SunGlasses_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Accessories_Man_SunGlasses_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button57_Click(object sender, EventArgs e)
        {
            panel_Accesories_Man_SunGlasses.Visible = false;
        }

        #region Shop_SunGlasses
        private void button58_Click(object sender, EventArgs e)
        {
            Accessories_Table(label121.Text);
        }

        private void button56_Click(object sender, EventArgs e)
        {
            Accessories_Table(label119.Text);
        }

        private void button55_Click(object sender, EventArgs e)
        {
            Accessories_Table(label117.Text);
        }

        private void button54_Click(object sender, EventArgs e)
        {
            Accessories_Table(label115.Text);
        }

        private void button53_Click(object sender, EventArgs e)
        {
            Accessories_Table(label113.Text);
        }

        private void button52_Click(object sender, EventArgs e)
        {
            Accessories_Table(label111.Text);
        }

        private void button59_Click(object sender, EventArgs e)
        {
            Accessories_Table(label123.Text);
        }

        private void button51_Click(object sender, EventArgs e)
        {
            Accessories_Table(label109.Text);
        }

        private void button50_Click(object sender, EventArgs e)
        {
            Accessories_Table(label107.Text);
        }

        private void button49_Click(object sender, EventArgs e)
        {
            Accessories_Table(label105.Text);
        }

        #endregion Shop_SunGlasses

        #endregion SunGlasses

        #region Clocks
        private void panel_Accessories_Man_Clocks_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Accesories_Man_Clocks.Location = new Point(0, 0);
            panel_Accesories_Man_Clocks.Visible = true;
        }
        private void panel_Accessories_Man_Clocks_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Accessories_Man_Clocks_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Accessories_Man_Clocks_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Accessories_Man_Clocks_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button68_Click(object sender, EventArgs e)
        {
            panel_Accesories_Man_Clocks.Visible = false;
        }

        #region Shop_Clocks
        private void button69_Click(object sender, EventArgs e)
        {
            Accessories_Table(label141.Text);
        }

        private void button67_Click(object sender, EventArgs e)
        {
            Accessories_Table(label139.Text);
        }

        private void button66_Click(object sender, EventArgs e)
        {
            Accessories_Table(label137.Text);
        }

        private void button65_Click(object sender, EventArgs e)
        {
            Accessories_Table(label135.Text);
        }

        private void button64_Click(object sender, EventArgs e)
        {
            Accessories_Table(label133.Text);
        }

        private void button63_Click(object sender, EventArgs e)
        {
            Accessories_Table(label131.Text);
        }

        private void button70_Click(object sender, EventArgs e)
        {
            Accessories_Table(label143.Text);
        }

        private void button62_Click(object sender, EventArgs e)
        {
            Accessories_Table(label129.Text);
        }

        private void button61_Click(object sender, EventArgs e)
        {
            Accessories_Table(label127.Text);
        }

        private void button60_Click(object sender, EventArgs e)
        {
            Accessories_Table(label125.Text);
        }

        #endregion Shop_Clocks

        #endregion Clocks

        #endregion Accessories_Man

        #region Accessories_Woman
        private void panel_Accessories_Woman_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Accesories_Woman.Location = new Point(0, 0);
            panel_Accesories_Woman.Visible = true;
        }
        private void panel_Accessories_Woman_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Accessories_Woman_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Accessories_Woman_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Accessories_Woman_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button126_Click(object sender, EventArgs e)
        {
            panel_Accesories_Woman.Visible = false;
        }

        #region Hair_Accessories
        private void panel_Hair_Accessories_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Hair_Accessories.Location = new Point(0, 0);
            panel_Hair_Accessories.Visible = true;
        }
        private void panel_Hair_Accessories_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Hair_Accessories_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Hair_Accessories_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Hair_Accessories_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button123_Click(object sender, EventArgs e)
        {
            panel_Hair_Accessories.Visible = false;
        }

        #region Shop_Hair_Accessories
        private void button124_Click(object sender, EventArgs e)
        {
            Accessories_Table(label242.Text);
        }

        private void button122_Click(object sender, EventArgs e)
        {
            Accessories_Table(label240.Text);
        }

        private void button121_Click(object sender, EventArgs e)
        {
            Accessories_Table(label238.Text);
        }

        private void button120_Click(object sender, EventArgs e)
        {
            Accessories_Table(label236.Text);
        }

        private void button119_Click(object sender, EventArgs e)
        {
            Accessories_Table(label234.Text);
        }

        private void button118_Click(object sender, EventArgs e)
        {
            Accessories_Table(label232.Text);
        }

        private void button125_Click(object sender, EventArgs e)
        {
            Accessories_Table(label244.Text);
        }

        private void button117_Click(object sender, EventArgs e)
        {
            Accessories_Table(label230.Text);
        }

        private void button116_Click(object sender, EventArgs e)
        {
            Accessories_Table(label228.Text);
        }

        private void button115_Click(object sender, EventArgs e)
        {
            Accessories_Table(label226.Text);
        }



        #endregion Shop_Hair_Accessories

        #endregion Hair_Accessories

        #region Decoration
        private void panel_Decoration_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Decoration.Location = new Point(0, 0);
            panel_Decoration.Visible = true;
        }
        private void panel_Decoration_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Decoration_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Decoration_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Decoration_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button112_Click(object sender, EventArgs e)
        {
            panel_Decoration.Visible = false;
        }

        #region Shop_Decoration
        private void button113_Click(object sender, EventArgs e)
        {
            Accessories_Table(label222.Text);
        }

        private void button111_Click(object sender, EventArgs e)
        {
            Accessories_Table(label220.Text);
        }

        private void button110_Click(object sender, EventArgs e)
        {
            Accessories_Table(label218.Text);
        }

        private void button109_Click(object sender, EventArgs e)
        {
            Accessories_Table(label216.Text);
        }

        private void button108_Click(object sender, EventArgs e)
        {
            Accessories_Table(label214.Text);
        }

        private void button107_Click(object sender, EventArgs e)
        {
            Accessories_Table(label212.Text);
        }

        private void button114_Click(object sender, EventArgs e)
        {
            Accessories_Table(label224.Text);
        }

        private void button106_Click(object sender, EventArgs e)
        {
            Accessories_Table(label210.Text);
        }

        private void button105_Click(object sender, EventArgs e)
        {
            Accessories_Table(label208.Text);
        }

        private void button104_Click(object sender, EventArgs e)
        {
            Accessories_Table(label206.Text);
        }


        #endregion Shop_Decoration

        #endregion Decoration

        #region Blets_Woman
        private void panel_Blets_Woman_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Blets_Woman.Location = new Point(0, 0);
            panel_Blets_Woman.Visible = true;
        }
        private void panel_Blets_Woman_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Blets_Woman_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Blets_Woman_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Blets_Woman_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button101_Click(object sender, EventArgs e)
        {
            panel_Blets_Woman.Visible = false;
        }

        #region Shop_Blets_Woman
        private void button102_Click(object sender, EventArgs e)
        {
            Accessories_Table(label202.Text);
        }

        private void button100_Click(object sender, EventArgs e)
        {
            Accessories_Table(label200.Text);
        }

        private void button99_Click(object sender, EventArgs e)
        {
            Accessories_Table(label198.Text);
        }

        private void button98_Click(object sender, EventArgs e)
        {
            Accessories_Table(label196.Text);
        }

        private void button97_Click(object sender, EventArgs e)
        {
            Accessories_Table(label194.Text);
        }

        private void button96_Click(object sender, EventArgs e)
        {
            Accessories_Table(label192.Text);
        }

        private void button103_Click(object sender, EventArgs e)
        {
            Accessories_Table(label204.Text);
        }

        private void button95_Click(object sender, EventArgs e)
        {
            Accessories_Table(label190.Text);
        }

        private void button94_Click(object sender, EventArgs e)
        {
            Accessories_Table(label188.Text);
        }



        #endregion Shop_Blets_Woman


        #endregion Blets_Woman

        #region SunGlasses_Woman
        private void panel_SunGlasses_Woman_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_SunGlasses_Woman.Location = new Point(0, 0);
            panel_SunGlasses_Woman.Visible = true;
        }
        private void panel_SunGlasses_Woman_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_SunGlasses_Woman_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_SunGlasses_Woman_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_SunGlasses_Woman_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button90_Click(object sender, EventArgs e)
        {
            panel_SunGlasses_Woman.Visible = false;
        }

        #region Shop_SunGlasses_Woman
        private void button91_Click(object sender, EventArgs e)
        {
            Accessories_Table(label182.Text);
        }

        private void button89_Click(object sender, EventArgs e)
        {
            Accessories_Table(label180.Text);
        }

        private void button88_Click(object sender, EventArgs e)
        {
            Accessories_Table(label178.Text);
        }

        private void button87_Click(object sender, EventArgs e)
        {
            Accessories_Table(label176.Text);
        }

        private void button86_Click(object sender, EventArgs e)
        {
            Accessories_Table(label174.Text);
        }

        private void button85_Click(object sender, EventArgs e)
        {
            Accessories_Table(label172.Text);
        }

        private void button92_Click(object sender, EventArgs e)
        {
            Accessories_Table(label184.Text);
        }

        private void button84_Click(object sender, EventArgs e)
        {
            Accessories_Table(label170.Text);
        }

        private void button83_Click(object sender, EventArgs e)
        {
            Accessories_Table(label168.Text);
        }

        private void button82_Click(object sender, EventArgs e)
        {
            Accessories_Table(label166.Text);
        }



        #endregion Shop_SunGlasses_Woman

        #endregion SunGlasses_Woman

        #region Clocks_Woman
        private void panel_Clocks_Woman_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Clocks_Woman.Location = new Point(0, 0);
            panel_Clocks_Woman.Visible = true;
        }
        private void panel_Clocks_Woman_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Clocks_Woman_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Clocks_Woman_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Clocks_Woman_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button79_Click(object sender, EventArgs e)
        {
            panel_Clocks_Woman.Visible = false;
        }

        #region Shop_Clocks_Woman
        private void button80_Click(object sender, EventArgs e)
        {
            Accessories_Table(label162.Text);
        }

        private void button78_Click(object sender, EventArgs e)
        {
            Accessories_Table(label160.Text);
        }

        private void button77_Click(object sender, EventArgs e)
        {
            Accessories_Table(label158.Text);
        }

        private void button76_Click(object sender, EventArgs e)
        {
            Accessories_Table(label156.Text);
        }

        private void button75_Click(object sender, EventArgs e)
        {
            Accessories_Table(label154.Text);
        }

        private void button74_Click(object sender, EventArgs e)
        {
            Accessories_Table(label152.Text);
        }

        private void button81_Click(object sender, EventArgs e)
        {
            Accessories_Table(label164.Text);
        }

        private void button73_Click(object sender, EventArgs e)
        {
            Accessories_Table(label150.Text);
        }

        private void button72_Click(object sender, EventArgs e)
        {
            Accessories_Table(label148.Text);
        }

        private void button71_Click(object sender, EventArgs e)
        {
            Accessories_Table(label146.Text);
        }


        #endregion Shop_Clocks_Woman

        #endregion Clocks_Woman

        #endregion Accessories_Woman

        #endregion Accessories

        #region Clothes

        #region Clothes_Man
        private void panel_Clothes_Man_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Clothes_Man.Location = new Point(0, 0);
            panel_Clothes_Man.Visible = true;
        }
        private void panel_Clothes_Man_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Clothes_Man_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Clothes_Man_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Clothes_Man_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button181_Click(object sender, EventArgs e)
        {
            panel_Clothes_Man.Visible = false;
        }

        #region T-Shirts_Man
        private void panel_TShirt_Man_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_TShirt_Man.Location = new Point(0, 0);
            panel_TShirt_Man.Visible = true;
        }
        private void panel_TShirt_Man_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_TShirt_Man_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_TShirt_Man_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_TShirt_Man_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button178_Click(object sender, EventArgs e)
        {
            panel_TShirt_Man.Visible = false;
        }

        #region Shop_T-Shirts_Man
        private void button179_Click(object sender, EventArgs e)
        {
            Clothes_Table(label347.Text);
        }

        private void button177_Click(object sender, EventArgs e)
        {
            Clothes_Table(label345.Text);
        }

        private void button176_Click(object sender, EventArgs e)
        {
            Clothes_Table(label343.Text);
        }

        private void button175_Click(object sender, EventArgs e)
        {
            Clothes_Table(label341.Text);
        }

        private void button174_Click(object sender, EventArgs e)
        {
            Clothes_Table(label339.Text);
        }

        private void button173_Click(object sender, EventArgs e)
        {
            Clothes_Table(label337.Text);
        }

        private void button180_Click(object sender, EventArgs e)
        {
            Clothes_Table(label349.Text);
        }

        private void button172_Click(object sender, EventArgs e)
        {
            Clothes_Table(label335.Text);
        }

        private void button171_Click(object sender, EventArgs e)
        {
            Clothes_Table(label333.Text);
        }

        private void button170_Click(object sender, EventArgs e)
        {
            Clothes_Table(label331.Text);
        }


        #endregion Shop_T-Shirts_Man

        #endregion T-Shirts_Man

        #region Hoodie
        private void panel_Hoodie_Man_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Hoodie_Man.Location = new Point(0, 0);
            panel_Hoodie_Man.Visible = true;
        }
        private void panel_Hoodie_Man_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Hoodie_Man_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Hoodie_Man_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Hoodie_Man_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button167_Click(object sender, EventArgs e)
        {
            panel_Hoodie_Man.Visible = false;
        }

        #region Shop_Hoodie
        private void button168_Click(object sender, EventArgs e)
        {
            Clothes_Table(label327.Text);
        }

        private void button166_Click(object sender, EventArgs e)
        {
            Clothes_Table(label325.Text);
        }

        private void button165_Click(object sender, EventArgs e)
        {
            Clothes_Table(label323.Text);
        }

        private void button164_Click(object sender, EventArgs e)
        {
            Clothes_Table(label321.Text);
        }

        private void button163_Click(object sender, EventArgs e)
        {
            Clothes_Table(label319.Text);
        }

        private void button162_Click(object sender, EventArgs e)
        {
            Clothes_Table(label317.Text);
        }

        private void button169_Click(object sender, EventArgs e)
        {
            Clothes_Table(label329.Text);
        }

        private void button161_Click(object sender, EventArgs e)
        {
            Clothes_Table(label315.Text);
        }

        private void button160_Click(object sender, EventArgs e)
        {
            Clothes_Table(label313.Text);
        }




        #endregion Shop_Hoodie

        #endregion Hoodie

        #region Shirts
        private void panel_Shirts_Man_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Shirts_Man.Location = new Point(0, 0);
            panel_Shirts_Man.Visible = true;
        }
        private void panel_Shirts_Man_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Shirts_Man_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Shirts_Man_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Shirts_Man_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button156_Click(object sender, EventArgs e)
        {
            panel_Shirts_Man.Visible = false;
        }

        #region Shop_Shirts

        private void button157_Click(object sender, EventArgs e)
        {
            Clothes_Table(label307.Text);
        }

        private void button155_Click(object sender, EventArgs e)
        {
            Clothes_Table(label305.Text);
        }

        private void button154_Click(object sender, EventArgs e)
        {
            Clothes_Table(label303.Text);
        }

        private void button153_Click(object sender, EventArgs e)
        {
            Clothes_Table(label301.Text);
        }

        private void button152_Click(object sender, EventArgs e)
        {
            Clothes_Table(label299.Text);
        }

        private void button151_Click(object sender, EventArgs e)
        {
            Clothes_Table(label297.Text);
        }

        private void button158_Click(object sender, EventArgs e)
        {
            Clothes_Table(label309.Text);
        }

        private void button150_Click(object sender, EventArgs e)
        {
            Clothes_Table(label295.Text);
        }

        private void button149_Click(object sender, EventArgs e)
        {
            Clothes_Table(label293.Text);
        }

        private void button148_Click(object sender, EventArgs e)
        {
            Clothes_Table(label291.Text);
        }

        #endregion Shop_Shirts


        #endregion Shirts

        #region Jeans
        private void panel_Jeans_Man_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Jeans_Man.Location = new Point(0, 0);
            panel_Jeans_Man.Visible = true;
        }
        private void panel_Jeans_Man_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Jeans_Man_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Jeans_Man_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Jeans_Man_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button145_Click(object sender, EventArgs e)
        {
            panel_Jeans_Man.Visible = false;
        }

        #region Shop_Jeans

        private void button146_Click(object sender, EventArgs e)
        {
            Clothes_Table(label287.Text);
        }

        private void button144_Click(object sender, EventArgs e)
        {
            Clothes_Table(label285.Text);
        }

        private void button142_Click(object sender, EventArgs e)
        {
            Clothes_Table(label281.Text);
        }

        private void button141_Click(object sender, EventArgs e)
        {
            Clothes_Table(label279.Text);
        }

        private void button140_Click(object sender, EventArgs e)
        {
            Clothes_Table(label277.Text);
        }

        private void button147_Click(object sender, EventArgs e)
        {
            Clothes_Table(label289.Text);
        }

        private void button139_Click(object sender, EventArgs e)
        {
            Clothes_Table(label275.Text);
        }

        private void button138_Click(object sender, EventArgs e)
        {
            Clothes_Table(label273.Text);
        }

        private void button137_Click(object sender, EventArgs e)
        {
            Clothes_Table(label271.Text);
        }

        #endregion Shop_Jeans


        #endregion Jeans

        #region Pants
        private void panel_Pants_Man_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Pants_Man.Location = new Point(0, 0);
            panel_Pants_Man.Visible = true;
        }
        private void panel_Pants_Man_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Pants_Man_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Pants_Man_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Pants_Man_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button134_Click(object sender, EventArgs e)
        {
            panel_Pants_Man.Visible = false;
        }

        #region Shop_Pants

        private void button135_Click(object sender, EventArgs e)
        {
            Clothes_Table(label267.Text);
        }

        private void button133_Click(object sender, EventArgs e)
        {
            Clothes_Table(label265.Text);
        }

        private void button132_Click(object sender, EventArgs e)
        {
            Clothes_Table(label263.Text);
        }

        private void button131_Click(object sender, EventArgs e)
        {
            Clothes_Table(label261.Text);
        }

        private void button130_Click(object sender, EventArgs e)
        {
            Clothes_Table(label259.Text);
        }

        private void button129_Click(object sender, EventArgs e)
        {
            Clothes_Table(label257.Text);
        }

        private void button136_Click(object sender, EventArgs e)
        {
            Clothes_Table(label269.Text);
        }

        private void button128_Click(object sender, EventArgs e)
        {
            Clothes_Table(label255.Text);
        }

        private void button127_Click(object sender, EventArgs e)
        {
            Clothes_Table(label253.Text);
        }

        private void button93_Click_1(object sender, EventArgs e)
        {
            Clothes_Table(label251.Text);
        }

        #endregion Shop_Pants


        #endregion Pants

        #region Underwear
        private void panel_Underwear_Man_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Underwear_Man.Location = new Point(0, 0);
            panel_Underwear_Man.Visible = true;
        }
        private void panel_Underwear_Man_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Underwear_Man_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Underwear_Man_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Underwear_Man_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button245_Click(object sender, EventArgs e)
        {
            panel_Underwear_Man.Visible = false;
        }

        #region Shop_Underwear

        private void button246_Click(object sender, EventArgs e)
        {
            Clothes_Table(label474.Text);
        }

        private void button244_Click(object sender, EventArgs e)
        {
            Clothes_Table(label472.Text);
        }

        private void button243_Click(object sender, EventArgs e)
        {
            Clothes_Table(label470.Text);
        }

        private void button242_Click(object sender, EventArgs e)
        {
            Clothes_Table(label468.Text);
        }

        private void button241_Click(object sender, EventArgs e)
        {
            Clothes_Table(label466.Text);
        }

        private void button240_Click(object sender, EventArgs e)
        {
            Clothes_Table(label464.Text);
        }

        private void button247_Click(object sender, EventArgs e)
        {
            Clothes_Table(label476.Text);
        }

        private void button239_Click(object sender, EventArgs e)
        {
            Clothes_Table(label462.Text);
        }

        private void button238_Click(object sender, EventArgs e)
        {
            Clothes_Table(label460.Text);
        }

        private void button237_Click(object sender, EventArgs e)
        {
            Clothes_Table(label458.Text);
        }

        #endregion Shop_Underwear


        #endregion Underwear

        #endregion Clothes_Man

        #region Clothes_Woman
        private void panel_Clothes_Woman_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Clothes_Woman.Location = new Point(0, 0);
            panel_Clothes_Woman.Visible = true;
        }
        private void panel_Clothes_Woman_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Clothes_Woman_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Clothes_Woman_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Clothes_Woman_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button234_Click(object sender, EventArgs e)
        {
            panel_Clothes_Woman.Visible = false;
        }

        #region Tops
        private void panel_Tops_Woman_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Tops_Woman.Location = new Point(0, 0);
            panel_Tops_Woman.Visible = true;
        }

        private void panel_Tops_Woman_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Tops_Woman_Button.BackColor = Color.FromArgb(34, 32, 44);
        }

        private void panel_Tops_Woman_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Tops_Woman_Button.BackColor = Color.FromArgb(28, 26, 38);
        }

        private void button220_Click(object sender, EventArgs e)
        {
            panel_Tops_Woman.Visible = false;
        }

        #region Shop_Tops

        private void button221_Click(object sender, EventArgs e)
        {
            Clothes_Table(label424.Text);
        }

        private void button219_Click(object sender, EventArgs e)
        {
            Clothes_Table(label422.Text);
        }

        private void button218_Click(object sender, EventArgs e)
        {
            Clothes_Table(label420.Text);
        }

        private void button217_Click(object sender, EventArgs e)
        {
            Clothes_Table(label418.Text);
        }

        private void button216_Click(object sender, EventArgs e)
        {
            Clothes_Table(label416.Text);
        }

        private void button215_Click(object sender, EventArgs e)
        {
            Clothes_Table(label414.Text);
        }

        private void button222_Click(object sender, EventArgs e)
        {
            Clothes_Table(label426.Text);
        }

        private void button214_Click(object sender, EventArgs e)
        {
            Clothes_Table(label412.Text);
        }

        private void button213_Click(object sender, EventArgs e)
        {
            Clothes_Table(label410.Text);
        }

        private void button212_Click(object sender, EventArgs e)
        {
            Clothes_Table(label408.Text);
        }

        #endregion Shop_Tops


        #endregion Tops

        #region Hoodie_Woman
        private void panel_Hoodie_Woman_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Hoodie_Woman.Location = new Point(0, 0);
            panel_Hoodie_Woman.Visible = true;
        }
        private void panel_Hoodie_Woman_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Hoodie_Woman_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Hoodie_Woman_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Hoodie_Woman_Button.BackColor = Color.FromArgb(28, 26, 38);
        }

        private void button253_Click_2(object sender, EventArgs e)
        {
            panel_Hoodie_Woman.Visible = false;
        }

        #region Shop_Hoodie_Woman

        private void button254_Click(object sender, EventArgs e)
        {
            Clothes_Table(label484.Text);
        }

        private void button252_Click(object sender, EventArgs e)
        {
            Clothes_Table(label482.Text);
        }

        private void button251_Click(object sender, EventArgs e)
        {
            Clothes_Table(label480.Text);
        }

        private void button250_Click(object sender, EventArgs e)
        {
            Clothes_Table(label478.Text);
        }

        private void button249_Click(object sender, EventArgs e)
        {
            Clothes_Table(label454.Text);
        }

        private void button248_Click(object sender, EventArgs e)
        {
            Clothes_Table(label452.Text);
        }

        private void button255_Click(object sender, EventArgs e)
        {
            Clothes_Table(label486.Text);
        }

        private void button236_Click(object sender, EventArgs e)
        {
            Clothes_Table(label450.Text);
        }

        private void button235_Click(object sender, EventArgs e)
        {
            Clothes_Table(label448.Text);
        }

        #endregion Shop_Hoodie_Woman


        #endregion Hoodie_Woman

        #region Jeans_Woman
        private void panel_Jeans_Woman_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Jeans_Woman.Location = new Point(0, 0);
            panel_Jeans_Woman.Visible = true;
        }
        private void panel_Jeans_Woman_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Jeans_Woman_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Jeans_Woman_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Jeans_Woman_Button.BackColor = Color.FromArgb(28, 26, 38);
        }

        private void button209_Click(object sender, EventArgs e)
        {
            panel_Jeans_Woman.Visible = false;
        }

        #region Shop_Jeans_Woman

        private void button210_Click(object sender, EventArgs e)
        {
            Clothes_Table(label404.Text);
        }

        private void button208_Click(object sender, EventArgs e)
        {
            Clothes_Table(label402.Text);
        }

        private void button205_Click(object sender, EventArgs e)
        {
            Clothes_Table(label396.Text);
        }

        private void button207_Click(object sender, EventArgs e)
        {
            Clothes_Table(label400.Text);
        }

        private void button206_Click(object sender, EventArgs e)
        {
            Clothes_Table(label398.Text);
        }

        private void button203_Click(object sender, EventArgs e)
        {
            Clothes_Table(label392.Text);
        }

        private void button211_Click(object sender, EventArgs e)
        {
            Clothes_Table(label406.Text);
        }

        private void button204_Click(object sender, EventArgs e)
        {
            Clothes_Table(label394.Text);
        }

        private void button202_Click(object sender, EventArgs e)
        {
            Clothes_Table(label390.Text);
        }


        #endregion Shop_Jeans_Woman


        #endregion Jeans_Woman

        #region Pants_Woman
        private void panel_Pants_Woman_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Pants_Woman.Location = new Point(0, 0);
            panel_Pants_Woman.Visible = true;
        }
        private void panel_Pants_Woman_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Pants_Woman_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Pants_Woman_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Pants_Woman_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button199_Click(object sender, EventArgs e)
        {
            panel_Pants_Woman.Visible = false;
        }

        #region Shop_Pants_Woman
        private void button200_Click(object sender, EventArgs e)
        {
            Clothes_Table(label386.Text);
        }

        private void button198_Click(object sender, EventArgs e)
        {
            Clothes_Table(label384.Text);
        }

        private void button197_Click(object sender, EventArgs e)
        {
            Clothes_Table(label382.Text);
        }

        private void button196_Click(object sender, EventArgs e)
        {
            Clothes_Table(label380.Text);
        }

        private void button195_Click(object sender, EventArgs e)
        {
            Clothes_Table(label378.Text);
        }

        private void button194_Click(object sender, EventArgs e)
        {
            Clothes_Table(label376.Text);
        }

        private void button201_Click(object sender, EventArgs e)
        {
            Clothes_Table(label388.Text);
        }

        private void button193_Click(object sender, EventArgs e)
        {
            Clothes_Table(label374.Text);
        }

        private void button192_Click(object sender, EventArgs e)
        {
            Clothes_Table(label372.Text);
        }

        private void button191_Click(object sender, EventArgs e)
        {
            Clothes_Table(label370.Text);
        }


        #endregion Shop_Pants_Woman


        #endregion Pants_Woman

        #region Underwear_Woman
        private void panel_Underwear_Woman_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Underwear_Woman.Location = new Point(0, 0);
            panel_Underwear_Woman.Visible = true;
        }
        private void panel_Underwear_Woman_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Underwear_Woman_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Underwear_Woman_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Underwear_Woman_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button188_Click(object sender, EventArgs e)
        {
            panel_Underwear_Woman.Visible = false;
        }

        #region Shop_Underwer_Woman

        private void button189_Click(object sender, EventArgs e)
        {
            Clothes_Table(label366.Text);
        }

        private void button187_Click(object sender, EventArgs e)
        {
            Clothes_Table(label364.Text);
        }

        private void button186_Click(object sender, EventArgs e)
        {
            Clothes_Table(label362.Text);
        }

        private void button185_Click(object sender, EventArgs e)
        {
            Clothes_Table(label360.Text);
        }

        private void button184_Click(object sender, EventArgs e)
        {
            Clothes_Table(label358.Text);
        }

        private void button183_Click(object sender, EventArgs e)
        {
            Clothes_Table(label356.Text);
        }

        private void button190_Click(object sender, EventArgs e)
        {
            Clothes_Table(label368.Text);
        }

        private void button182_Click(object sender, EventArgs e)
        {
            Clothes_Table(label311.Text);
        }

        private void button159_Click_1(object sender, EventArgs e)
        {
            Clothes_Table(label283.Text);
        }

        private void button143_Click_1(object sender, EventArgs e)
        {
            Clothes_Table(label8.Text);
        }

        #endregion Shop_Underwer_Woman

        #endregion Underwear_Woman

        #region Dress
        private void panel_Dress_Woman_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Dress_Woman.Location = new Point(0, 0);
            panel_Dress_Woman.Visible = true;
        }
        private void panel_Dress_Woman_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Dress_Woman_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Dress_Woman_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Dress_Woman_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button231_Click(object sender, EventArgs e)
        {
            panel_Dress_Woman.Visible = false;
        }

        #region Shop_Dress

        private void button232_Click(object sender, EventArgs e)
        {
            Clothes_Table(label444.Text);
        }

        private void button230_Click(object sender, EventArgs e)
        {
            Clothes_Table(label442.Text);
        }

        private void button229_Click(object sender, EventArgs e)
        {
            Clothes_Table(label440.Text);
        }

        private void button228_Click(object sender, EventArgs e)
        {
            Clothes_Table(label438.Text);
        }

        private void button227_Click(object sender, EventArgs e)
        {
            Clothes_Table(label436.Text);
        }

        private void button226_Click(object sender, EventArgs e)
        {
            Clothes_Table(label434.Text);
        }

        private void button233_Click(object sender, EventArgs e)
        {
            Clothes_Table(label446.Text);
        }

        private void button225_Click(object sender, EventArgs e)
        {
            Clothes_Table(label432.Text);
        }

        private void button224_Click(object sender, EventArgs e)
        {
            Clothes_Table(label430.Text);
        }

        private void button223_Click(object sender, EventArgs e)
        {
            Clothes_Table(label428.Text);
        }

        #endregion Shop_Dress

        #endregion Dress

        #endregion Clothes_Woman


        #endregion Clothes

        #region Sport

        #region Sport_Bikesport
        private void panel_Sport_Bikesport_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Sport_Bikesport.Location = new Point(0, 0);
            panel_Sport_Bikesport.Visible = true;
        }
        private void panel_Sport_Bikesport_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Sport_Bikesport_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Sport_Bikesport_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Sport_Bikesport_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button385_Click(object sender, EventArgs e)
        {
            panel_Sport_Bikesport.Visible = false;
        }

        #region Bike

        private void panel355_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Bike.Location = new Point(0, 0);
            panel_Bike.Visible = true;
        }

        private void panel355_MouseEnter(object sender, EventArgs e)
        {
            panel355.BackColor = Color.FromArgb(34, 32, 44);
        }


        private void panel355_MouseLeave(object sender, EventArgs e)
        {
            panel355.BackColor = Color.FromArgb(28, 26, 38);
        }

        private void button382_Click(object sender, EventArgs e)
        {
            panel_Bike.Visible = false;
        }

        #region Shop_Bike

        private void button383_Click(object sender, EventArgs e)
        {
            Sport_Table(label728.Text);
        }

        private void button381_Click(object sender, EventArgs e)
        {
            Sport_Table(label726.Text);
        }

        private void button380_Click(object sender, EventArgs e)
        {
            Sport_Table(label724.Text);
        }

        private void button379_Click(object sender, EventArgs e)
        {
            Sport_Table(label722.Text);
        }

        private void button378_Click(object sender, EventArgs e)
        {
            Sport_Table(label720.Text);
        }

        private void button377_Click(object sender, EventArgs e)
        {
            Sport_Table(label718.Text);
        }

        private void button384_Click(object sender, EventArgs e)
        {
            Sport_Table(label730.Text);
        }

        private void button376_Click(object sender, EventArgs e)
        {
            Sport_Table(label716.Text);
        }

        private void button375_Click(object sender, EventArgs e)
        {
            Sport_Table(label714.Text);
        }

        private void button374_Click(object sender, EventArgs e) //dsdsdsd
        {
            Sport_Table(label712.Text);
        }



        #endregion Shop_Bike


        #endregion Bike

        #region Equipment
        private void panel_Equipment_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Equipment.Location = new Point(0, 0);
            panel_Equipment.Visible = true;
        }

        private void panel_Equipment_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Equipment_Button.BackColor = Color.FromArgb(34, 32, 44);
        }

        private void panel_Equipment_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Equipment_Button.BackColor = Color.FromArgb(28, 26, 38);
        }

        private void button525_Click(object sender, EventArgs e)
        {
            panel_Equipment.Visible = false;
        }

        #region Shop_Equipment

        private void button526_Click(object sender, EventArgs e)
        {
            Sport_Table(label838.Text);
        }

        private void button524_Click(object sender, EventArgs e)
        {
            Sport_Table(label836.Text);
        }

        private void button522_Click(object sender, EventArgs e)
        {
            Sport_Table(label832.Text);
        }

        private void button520_Click(object sender, EventArgs e)
        {
            Sport_Table(label828.Text);
        }

        private void button518_Click(object sender, EventArgs e)
        {
            Sport_Table(label824.Text);
        }

        private void button516_Click(object sender, EventArgs e)
        {
            Sport_Table(label820.Text);
        }

        private void button527_Click(object sender, EventArgs e)
        {
            Sport_Table(label840.Text);
        }

        private void button513_Click(object sender, EventArgs e)
        {
            Sport_Table(label814.Text);
        }

        private void button509_Click(object sender, EventArgs e) //fdfsdfsdf
        {
            Sport_Table(label806.Text);
        }



        #endregion Shop_Equipment
  
        #endregion Equipment

        #region Detalis

        private void panel357_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Bikesport_Detalis.Location = new Point(0, 0);
            panel_Bikesport_Detalis.Visible = true;
        }

        private void panel357_MouseEnter(object sender, EventArgs e)
        {
            panel357.BackColor = Color.FromArgb(34, 32, 44);
        }

        private void panel357_MouseLeave(object sender, EventArgs e)
        {
            panel357.BackColor = Color.FromArgb(28, 26, 38);
        }

        private void button576_Click(object sender, EventArgs e)
        {
            panel_Bikesport_Detalis.Visible = false;
        }

        #region Shop_Detalis

        private void button577_Click(object sender, EventArgs e)
        {
            Sport_Table(label938.Text);
        }

        private void button575_Click(object sender, EventArgs e)
        {
            Sport_Table(label936.Text);
        }

        private void button573_Click(object sender, EventArgs e)
        {
            Sport_Table(label932.Text);
        }

        private void button571_Click(object sender, EventArgs e)
        {
            Sport_Table(label928.Text);
        }

        private void button569_Click(object sender, EventArgs e)
        {
            Sport_Table(label924.Text);
        }

        private void button567_Click(object sender, EventArgs e)
        {
            Sport_Table(label920.Text);
        }

        private void button578_Click(object sender, EventArgs e)
        {
            Sport_Table(label940.Text);
        }

        private void button564_Click(object sender, EventArgs e)
        {
            Sport_Table(label914.Text);
        }

        private void button560_Click(object sender, EventArgs e)
        {
            Sport_Table(label906.Text);
        }

        private void button558_Click(object sender, EventArgs e) //sdfasdf
        {
            Sport_Table(label902.Text);
        }



        #endregion Shop_Detalis

        #endregion Detalis


        #endregion Sport_Bikesport

        #region Sport_Fitnes
        private void panel_Sport_Fitnes_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Sport_Fitnes.Location = new Point(0, 0);
            panel_Sport_Fitnes.Visible = true;
        }
        private void panel_Sport_Fitnes_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Sport_Fitnes_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Sport_Fitnes_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Sport_Fitnes_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button667_Click(object sender, EventArgs e)
        {
            panel_Sport_Fitnes.Visible = false;
        }

        #region Covriki
        private void panel_Fitnes_Covriki_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Fitnes_Covriki.Location = new Point(0, 0);
            panel_Fitnes_Covriki.Visible = true;
        }
        private void panel_Fitnes_Covriki_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Fitnes_Covriki_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Fitnes_Covriki_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Fitnes_Covriki_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button664_Click(object sender, EventArgs e)
        {
            panel_Fitnes_Covriki.Visible = false;
        }

        #region Shop_Covriki

        private void button665_Click(object sender, EventArgs e)
        {
            Sport_Table(label1116.Text);
        }

        private void button663_Click(object sender, EventArgs e)
        {
            Sport_Table(label1114.Text);
        }

        private void button661_Click(object sender, EventArgs e)
        {
            Sport_Table(label1110.Text);
        }

        private void button659_Click(object sender, EventArgs e)
        {
            Sport_Table(label1106.Text);
        }

        private void button657_Click(object sender, EventArgs e)
        {
            Sport_Table(label1102.Text);
        }

        private void button655_Click(object sender, EventArgs e)
        {
            Sport_Table(label1098.Text);
        }

        private void button666_Click(object sender, EventArgs e)
        {
            Sport_Table(label1118.Text);
        }

        private void button652_Click(object sender, EventArgs e)
        {
            Sport_Table(label1092.Text);
        }

        private void button648_Click(object sender, EventArgs e)
        {
            Sport_Table(label1084.Text);
        }

        private void button646_Click(object sender, EventArgs e) //sdsdsdsd
        {
            Sport_Table(label1080.Text);
        }


        #endregion Shop_Covriki


        #endregion Covriki

        #region Fitnes_Accessoin
        private void panel_Fitnes_Accession_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Fitnes_Accession.Location = new Point(0, 0);
            panel_Fitnes_Accession.Visible = true;
        }
        private void panel_Fitnes_Accession_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Fitnes_Accession_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Fitnes_Accession_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Fitnes_Accession_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button613_Click(object sender, EventArgs e)
        {
            panel_Fitnes_Accession.Visible = false;
        }

        #region Shop_Fitnes_Accessoin

        private void button614_Click(object sender, EventArgs e)
        {
            Sport_Table(label1016.Text);
        }

        private void button612_Click(object sender, EventArgs e)
        {
            Sport_Table(label1014.Text);
        }

        private void button610_Click(object sender, EventArgs e)
        {
            Sport_Table(label1010.Text);
        }

        private void button608_Click(object sender, EventArgs e)
        {
            Sport_Table(label1006.Text);
        }

        private void button606_Click(object sender, EventArgs e)
        {
            Sport_Table(label1002.Text);
        }

        private void button604_Click(object sender, EventArgs e)
        {
            Sport_Table(label998.Text);
        }

        private void button615_Click(object sender, EventArgs e)
        {
            Sport_Table(label1018.Text);
        }

        private void button601_Click(object sender, EventArgs e)
        {
            Sport_Table(label992.Text);
        }

        private void button597_Click(object sender, EventArgs e)
        {
            Sport_Table(label984.Text);
        }

        private void button595_Click(object sender, EventArgs e)
        {
            Sport_Table(label980.Text);
        }



        #endregion Shop_Fitnes_Accessoin

        #endregion Fitnes_Accessoin

        #region Power_Traning
        private void panel_Power_Training_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Power_Training.Location = new Point(0, 0);
            panel_Power_Training.Visible = true;
        }
        private void panel_Power_Training_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Power_Training_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Power_Training_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Power_Training_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button304_Click(object sender, EventArgs e)
        {
            panel_Power_Training.Visible = false;
        }

        #region Shop_Power_Traning

        private void button305_Click(object sender, EventArgs e)
        {
            Sport_Table(label590.Text);
        }

        private void button303_Click(object sender, EventArgs e)
        {
            Sport_Table(label588.Text);
        }

        private void button301_Click(object sender, EventArgs e)
        {
            Sport_Table(label584.Text);
        }

        private void button299_Click(object sender, EventArgs e)
        {
            Sport_Table(label580.Text);
        }

        private void button297_Click(object sender, EventArgs e)
        {
            Sport_Table(label576.Text);
        }

        private void button295_Click(object sender, EventArgs e)
        {
            Sport_Table(label572.Text);
        }

        private void button306_Click(object sender, EventArgs e)
        {
            Sport_Table(label592.Text);
        }

        private void button292_Click(object sender, EventArgs e)
        {
            Sport_Table(label566.Text);
        }

        private void button288_Click(object sender, EventArgs e)
        {
            Sport_Table(label558.Text);
        }

        private void button286_Click(object sender, EventArgs e) 
        {
            Sport_Table(label554.Text);
        }



        #endregion Shop_Power_Traning

        #endregion Power_Traning

        #region Cross_Training
        private void panel_Cross_Training_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Cross_Training.Location = new Point(0, 0);
            panel_Cross_Training.Visible = true;
        }
        private void panel_Cross_Training_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Cross_Training_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Cross_Training_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Cross_Training_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button716_Click(object sender, EventArgs e)
        {
            panel_Cross_Training.Visible = false;
        }

        #region Shop_Cross_Training

        private void button717_Click(object sender, EventArgs e)
        {
            Sport_Table(label1220.Text);
        }

        private void button715_Click(object sender, EventArgs e)
        {
            Sport_Table(label1218.Text);
        }

        private void button713_Click(object sender, EventArgs e)
        {
            Sport_Table(label1214.Text);
        }

        private void button711_Click(object sender, EventArgs e)
        {
            Sport_Table(label1210.Text);
        }

        private void button709_Click(object sender, EventArgs e)
        {
            Sport_Table(label1206.Text);
        }

        private void button707_Click(object sender, EventArgs e)
        {
            Sport_Table(label1202.Text);
        }

        private void button718_Click(object sender, EventArgs e)
        {
            Sport_Table(label1222.Text);
        }

        private void button704_Click(object sender, EventArgs e)
        {
            Sport_Table(label1196.Text);
        }

        private void button700_Click(object sender, EventArgs e)
        {
            Sport_Table(label1188.Text);
        }

        private void button698_Click(object sender, EventArgs e)
        {
            Sport_Table(label1184.Text);
        }



        #endregion Shop_Cross_Training


        #endregion Cross_Training


        #endregion Sport_Fitnes

        #region Sport_Water
        private void panel_Sport_Watersport_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Sport_Watersport.Location = new Point(0, 0);
            panel_Sport_Watersport.Visible = true;
        }
        private void panel_Sport_Watersport_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Sport_Watersport_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Sport_Watersport_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Sport_Watersport_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button311_Click_1(object sender, EventArgs e)
        {
            panel_Sport_Watersport.Visible = false;
        }

        #region Accession_Water
        private void panel_Accession_Water_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Accession_Water.Location = new Point(0, 0);
            panel_Accession_Water.Visible = true;
        }
        private void panel_Accession_Water_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Accession_Water_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Accession_Water_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Accession_Water_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button308_Click_1(object sender, EventArgs e)
        {
            panel_Accession_Water.Visible = false;
        }

        #region Shop_Accession_Water

        private void button309_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label582.Text);
        }

        private void button307_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label578.Text);
        }

        private void button302_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label574.Text);
        }

        private void button300_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label570.Text);
        }

        private void button298_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label568.Text);
        }

        private void button296_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label564.Text);
        }

        private void button310_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label586.Text);
        }

        private void button294_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label562.Text);
        }

        private void button293_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label560.Text);
        }

        private void button291_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label556.Text);
        }

        #endregion Shop_Accession_Water

        #endregion Accession_Water

        #region WaterCostums
        private void panel_WaterCostums_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_WaterCostums.Location = new Point(0, 0);
            panel_WaterCostums.Visible = true;
        }
        private void panel_WaterCostums_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_WaterCostums_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_WaterCostums_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_WaterCostums_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button287_Click_1(object sender, EventArgs e)
        {
            panel_WaterCostums.Visible = false;
        }

        #region Shop_WaterCostums
        private void button289_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label550.Text);
        }

        private void button285_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label548.Text);
        }

        private void button284_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label546.Text);
        }

        private void button283_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label544.Text);
        }

        private void button282_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label542.Text);
        }

        private void button281_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label540.Text);
        }

        private void button290_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label552.Text);
        }

        private void button280_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label538.Text);
        }

        private void button279_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label536.Text);
        }

        private void button278_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label534.Text);
        }


        #endregion Shop_WaterCostums

        #endregion WaterCostums

        #region WaterInderwear
        private void panel_Waterunderwear_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Waterunderwear.Location = new Point(0, 0);
            panel_Waterunderwear.Visible = true;
        }
        private void panel_Waterunderwear_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Waterunderwear_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Waterunderwear_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Waterunderwear_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button275_Click_1(object sender, EventArgs e)
        {
            panel_Waterunderwear.Visible = false;
        }

        #region Shop_WaterInderwear

        private void button276_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label530.Text);
        }

        private void button274_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label528.Text);
        }

        private void button273_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label526.Text);
        }

        private void button272_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label524.Text);
        }

        private void button271_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label522.Text);
        }

        private void button270_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label520.Text);
        }

        private void button277_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label532.Text);
        }

        private void button269_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label518.Text);
        }

        private void button268_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label516.Text);
        }

        private void button267_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label514.Text);
        }

        #endregion Shop_WaterInderwear


        #endregion WaterInderwear

        #region Waterglasses
        private void panel_Waterglasses_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Waterglasses.Location = new Point(0, 0);
            panel_Waterglasses.Visible = true;
        }
        private void panel_Waterglasses_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Waterglasses_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Waterglasses_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Waterglasses_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button264_Click_1(object sender, EventArgs e)
        {
            panel_Waterglasses.Visible = false;
        }

        #region Shop_Waterglasses

        private void button265_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label510.Text);
        }

        private void button263_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label508.Text);
        }

        private void button262_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label506.Text);
        }

        private void button261_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label504.Text);
        }

        private void button260_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label502.Text);
        }

        private void button259_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label500.Text);
        }

        private void button266_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label512.Text);
        }

        private void button258_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label498.Text);
        }

        private void button257_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label496.Text);
        }

        private void button256_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label494.Text);
        }

        #endregion Shop_Waterglasses

        #endregion Waterglasses

        #endregion Sport_Water

        #region Sport_Winter
        private void panel_Sport_Wintersport_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Sport_Wintersport.Location = new Point(0, 0);
            panel_Sport_Wintersport.Visible = true;
        }
        private void panel_Sport_Wintersport_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Sport_Wintersport_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Sport_Wintersport_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Sport_Wintersport_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button356_Click_1(object sender, EventArgs e)
        {
            panel_Sport_Wintersport.Visible = false;
        }

        #region Hookei
        private void panel_Hookei_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Hookei.Location = new Point(0, 0);
            panel_Hookei.Visible = true;
        }
        private void panel_Hookei_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Hookei_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Hookei_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Hookei_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button353_Click_1(object sender, EventArgs e)
        {
            panel_Hookei.Visible = false;
        }

        #region Shop_Hookie
        private void button354_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label674.Text);
        }

        private void button352_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label672.Text);
        }

        private void button351_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label670.Text);
        }

        private void button350_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label668.Text);
        }

        private void button349_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label666.Text);
        }

        private void button348_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label664.Text);
        }

        private void button355_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label676.Text);
        }

        private void button347_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label662.Text);
        }

        private void button346_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label660.Text);
        }

        private void button345_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label658.Text);
        }

        #endregion Shop_Hookie

        #endregion Hookie

        #region Iceskate
        private void panel_Iceskate_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Iceskate.Location = new Point(0, 0);
            panel_Iceskate.Visible = true;
        }
        private void panel_Iceskate_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Iceskate_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Iceskate_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Iceskate_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button342_Click_1(object sender, EventArgs e)
        {
            panel_Iceskate.Visible = false;
        }

        #region Shop_Iceskate
        private void button343_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label654.Text);
        }

        private void button341_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label652.Text);
        }

        private void button340_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label650.Text);
        }

        #endregion Shop_Iceskate

        #endregion Iceskate

        #region Snowboarding
        private void panel_Snowboarding_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Snowboarding.Location = new Point(0, 0);
            panel_Snowboarding.Visible = true;
        }
        private void panel_Snowboarding_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Snowboarding_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Snowboarding_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Snowboarding_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button331_Click_1(object sender, EventArgs e)
        {
            panel_Snowboarding.Visible = false;
        }

        #region Shop_Snowboarding
        private void button332_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label634.Text);
        }

        private void button330_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label632.Text);
        }

        private void button329_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label630.Text);
        }

        private void button328_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label628.Text);
        }

        private void button327_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label626.Text);
        }

        private void button326_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label624.Text);
        }

        private void button333_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label636.Text);
        }

        #endregion Shop_Snowboarding

        #endregion Snowboarding

        #region Skiing
        private void panel_Skiing_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Skiing.Location = new Point(0, 0);
            panel_Skiing.Visible = true;
        }

        private void panel_Skiing_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Skiing_Button.BackColor = Color.FromArgb(34, 32, 44);
        }

        private void panel_Skiing_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Skiing_Button.BackColor = Color.FromArgb(28, 26, 38);
        }

        private void button320_Click_1(object sender, EventArgs e)
        {
            panel_Skiing.Visible = false;
        }

        #region Shop_Skiing
        private void button321_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label614.Text);
        }

        private void button319_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label612.Text);
        }

        private void button318_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label610.Text);
        }

        private void button317_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label608.Text);
        }

        private void button316_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label606.Text);
        }

        private void button315_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label604.Text);
        }

        private void button322_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label616.Text);
        }

        private void button314_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label602.Text);
        }

        private void button313_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label600.Text);
        }

        private void button312_Click_1(object sender, EventArgs e)
        {
            Sport_Table(label598.Text);
        }


        #endregion Shop_Skiing

        #endregion Skiing

        #endregion Sport_Winter

        #endregion Sport

        #region Electronica

        #region Headpods
        private void panel_Headpods_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Electronic.AutoScroll = false;
            panel_Headpods.Location = new Point(0, 0);
            panel_Headpods.Visible = true;
        }

        private void panel_Headpods_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Headpods_Button.BackColor = Color.FromArgb(34, 32, 44);
        }

        private void panel_Headpods_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Headpods_Button.BackColor = Color.FromArgb(28, 26, 38);
        }

        private void button494_Click_1(object sender, EventArgs e)
        {
            panel_Electronic.AutoScroll = true;
            panel_Headpods.Visible = false;
        }

        #region Shop_Headpods
        private void button495_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label764.Text);
        }

        private void button493_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label761.Text);
        }

        private void button492_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label759.Text);
        }

        private void button491_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label735.Text);
        }

        private void button490_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label710.Text);
        }

        private void button373_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label708.Text);
        }

        private void button496_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label766.Text);
        }

        private void button372_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label706.Text);
        }

        private void button371_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label704.Text);
        }

        private void button370_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label702.Text);
        }

        #endregion Shop_Headpods


        #endregion Headpods

        #region Smartphone

        private void panel_Smatphone_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Electronic.AutoScroll = false;
            panel_Smatphone.Location = new Point(0, 0);
            panel_Smatphone.Visible = true;
        }

        private void panel_Smatphone_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Smatphone_Button.BackColor = Color.FromArgb(34, 32, 44);
        }

        private void panel_Smatphone_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Smatphone_Button.BackColor = Color.FromArgb(28, 26, 38);
        }

        private void button339_Click_1(object sender, EventArgs e)
        {
            panel_Electronic.AutoScroll = true;
            panel_Smatphone.Visible = false;
        }

        #region Shop_Smartphone
        private void button344_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label681.Text);
        }

        private void button338_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label655.Text);
        }

        private void button337_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label647.Text);
        }

        private void button336_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label645.Text);
        }

        private void button335_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label643.Text);
        }

        private void button334_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label641.Text);
        }

        private void button357_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label683.Text);
        }

        private void button325_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label639.Text);
        }

        private void button324_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label637.Text);
        }

        private void button323_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label621.Text);
        }

        #endregion Shop_Smartphone

        #endregion Smartphone

        #region Photo
        private void panel_Photo_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Electronic.AutoScroll = false;
            panel_Photo.Location = new Point(0, 0);
            panel_Photo.Visible = true;
        }
        private void panel_Photo_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Photo_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Photo_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Photo_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button366_Click_1(object sender, EventArgs e)
        {
            panel_Electronic.AutoScroll = true;
            panel_Photo.Visible = false;
        }
        #region Shop_Photo
        private void button367_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label767.Text);
        }

        private void button365_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label699.Text);
        }

        private void button364_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label697.Text);
        }

        private void button363_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label695.Text);
        }

        private void button362_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label693.Text);
        }

        private void button361_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label691.Text);
        }

        private void button368_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label769.Text);
        }

        private void button360_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label689.Text);
        }

        private void button359_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label687.Text);
        }

        private void button358_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label685.Text);
        }

        #endregion Shop_Photo

        #endregion Photo

        #region Notebook
        private void panel_Notebook_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Electronic.AutoScroll = false;
            panel_Notebook.Location = new Point(0, 0);
            panel_Notebook.Visible = true;
        }
        private void panel_Notebook_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Notebook_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Notebook_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Notebook_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button504_Click_1(object sender, EventArgs e)
        {
            panel_Electronic.AutoScroll = true;
            panel_Notebook.Visible = false;
        }

        #region Shop_Notebook
        private void button505_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label787.Text);
        }

        private void button503_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label785.Text);
        }

        private void button502_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label783.Text);
        }

        private void button501_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label781.Text);
        }

        private void button500_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label779.Text);
        }

        private void button499_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label777.Text);
        }

        private void button506_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label789.Text);
        }

        private void button498_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label775.Text);
        }

        private void button497_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label773.Text);
        }

        private void button369_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label771.Text);
        }


        #endregion Shop_Notebook

        #endregion Notebook

        #region TV
        private void panel_TV_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Electronic.AutoScroll = false;
            panel_TV.Location = new Point(0, 0);
            panel_TV.Visible = true;
        }
        private void panel_TV_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_TV_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_TV_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_TV_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button519_Click_1(object sender, EventArgs e)
        {
            panel_Electronic.AutoScroll = true;
            panel_TV.Visible = false;
        }


        #region Shop_TV
        private void button521_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label809.Text);
        }

        private void button517_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label807.Text);
        }

        private void button515_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label803.Text);
        }

        private void button514_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label801.Text);
        }

        private void button512_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label799.Text);
        }

        private void button511_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label797.Text);
        }

        private void button523_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label811.Text);
        }

        private void button510_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label795.Text);
        }

        private void button508_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label793.Text);
        }

        private void button507_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label791.Text);
        }

        #endregion Shop_TV

        #endregion TV

        #region Network
        private void panel_Network_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Electronic.AutoScroll = false;
            panel_Network.Location = new Point(0, 0);
            panel_Network.Visible = true;
        }
        private void panel_Network_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Network_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Network_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Network_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button536_Click_1(object sender, EventArgs e)
        {
            panel_Electronic.AutoScroll = true;
            panel_Network.Visible = false;
        }

        #region Shop_Network
        private void button537_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label845.Text);
        }

        private void button535_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label843.Text);
        }

        private void button534_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label841.Text);
        }

        private void button533_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label833.Text);
        }

        private void button532_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label829.Text);
        }

        private void button531_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label825.Text);
        }

        private void button538_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label847.Text);
        }

        private void button530_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label821.Text);
        }

        private void button529_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label817.Text);
        }

        private void button528_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label815.Text);
        }

        #endregion Shop_Nerwork

        #endregion Network

        #region SmartHome
        private void panel_Smart_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Electronic.AutoScroll = false;
            panel_Smart.Location = new Point(0, 0);
            panel_Smart.Visible = true;
        }
        private void panel_Smart_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Smart_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Smart_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Smart_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button547_Click_1(object sender, EventArgs e)
        {
            panel_Electronic.AutoScroll = true;
            panel_Smart.Visible = false;
        }

        #region Shop_SmartHome
        private void button548_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label865.Text);
        }

        private void button546_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label863.Text);
        }

        private void button545_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label861.Text);
        }

        private void button544_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label859.Text);
        }

        private void button543_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label857.Text);
        }

        private void button542_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label855.Text);
        }

        private void button549_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label867.Text);
        }

        private void button541_Click_1(object sender, EventArgs e)
        {
            Electronics_Table(label853.Text);
        }




        #endregion Shop_SmartHome

        #endregion SmartHome

        #endregion Electronica

        #region Cosmetics

        #region MakeUp
        private void panel_Makeup_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Cosmetics.AutoScroll = false;
            panel_Makeup.Location = new Point(0, 0);
            panel_Makeup.Visible = true;
        }
        private void panel_Makeup_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Makeup_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Makeup_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Makeup_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button642_Click_1(object sender, EventArgs e)
        {
            panel_Cosmetics.AutoScroll = true;
            panel_Makeup.Visible = false;
        }

        #region Shop_MakeUp
        private void button643_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label1037.Text);
        }

        private void button641_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label1035.Text);
        }

        private void button640_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label1033.Text);
        }

        private void button639_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label1031.Text);
        }

        private void button638_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label1029.Text);
        }

        private void button637_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label1027.Text);
        }

        private void button644_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label1039.Text);
        }

        private void button636_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label1025.Text);
        }

        private void button635_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label1023.Text);
        }

        private void button634_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label1021.Text);
        }

        #endregion Shop_MakeUp

        #endregion MakeUp

        #region Manicure
        private void panel_Manicure_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Cosmetics.AutoScroll = false;
            panel_Manicure.Location = new Point(0, 0);
            panel_Manicure.Visible = true;
        }

        private void panel_Manicure_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Manicure_Button.BackColor = Color.FromArgb(34, 32, 44);
        }

        private void panel_Manicure_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Manicure_Button.BackColor = Color.FromArgb(28, 26, 38);
        }

        private void button631_Click_1(object sender, EventArgs e)
        {
            panel_Cosmetics.AutoScroll = true;
            panel_Manicure.Visible = false;
        }

        #region Shop_Manicure
        private void button632_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label1011.Text);
        }

        private void button630_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label1007.Text);
        }

        private void button629_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label1003.Text);
        }

        private void button628_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label999.Text);
        }

        private void button627_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label995.Text);
        }

        private void button626_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label993.Text);
        }

        private void button633_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label1019.Text);
        }

        private void button625_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label989.Text);
        }

        private void button624_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label987.Text);
        }

        private void button623_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label985.Text);
        }

        #endregion Shop_Manicure

        #endregion Manicure

        #region Shower
        private void panel_Shower_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Cosmetics.AutoScroll = false;
            panel_Shower.Location = new Point(0, 0);
            panel_Shower.Visible = true;
        }

        private void panel_Shower_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Shower_Button.BackColor = Color.FromArgb(34, 32, 44);
        }

        private void panel_Shower_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Shower_Button.BackColor = Color.FromArgb(28, 26, 38);
        }

        private void button620_Click_1(object sender, EventArgs e)
        {
            panel_Cosmetics.AutoScroll = true;
            panel_Shower.Visible = false;
        }

        #region Shop_Shower
        private void button621_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label977.Text);
        }

        private void button619_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label975.Text);
        }

        private void button618_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label973.Text);
        }

        private void button617_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label971.Text);
        }

        private void button616_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label969.Text);
        }

        private void button611_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label967.Text);
        }

        private void button622_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label981.Text);
        }

        private void button609_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label965.Text);
        }

        private void button607_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label963.Text);
        }

        private void button605_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label961.Text);
        }

        #endregion Shop_Shower

        #endregion Shower

        #region HairCare
        private void panel_HairCare_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Cosmetics.AutoScroll = false;
            panel_HairCare.Location = new Point(0, 0);
            panel_HairCare.Visible = true;
        }
        private void panel_HairCare_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_HairCare_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_HairCare_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_HairCare_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button600_Click_1(object sender, EventArgs e)
        {
            panel_Cosmetics.AutoScroll = true;
            panel_HairCare.Visible = false;
        }

        #region Shop_HairCare
        private void button602_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label957.Text);
        }

        private void button599_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label955.Text);
        }

        private void button598_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label953.Text);
        }

        private void button596_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label951.Text);
        }

        private void button594_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label949.Text);
        }

        private void button593_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label947.Text);
        }

        private void button603_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label959.Text);
        }

        private void button592_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label945.Text);
        }

        private void button591_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label943.Text);
        }

        private void button590_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label941.Text);
        }


        #endregion Shop_HairCare

        #endregion HairCare

        #region Perfumery
        private void panel_Perfumery_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Cosmetics.AutoScroll = false;
            panel_Perfumery.Location = new Point(0, 0);
            panel_Perfumery.Visible = true;
        }
        private void panel_Perfumery_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Perfumery_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Perfumery_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Perfumery_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button587_Click_1(object sender, EventArgs e)
        {
            panel_Cosmetics.AutoScroll = true;
            panel_Perfumery.Visible = false;
        }

        #region Shop_Perfumery
        private void button588_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label929.Text);
        }

        private void button586_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label925.Text);
        }

        private void button585_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label921.Text);
        }

        private void button584_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label917.Text);
        }

        private void button583_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label915.Text);
        }

        private void button582_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label911.Text);
        }

        private void button589_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label933.Text);
        }

        private void button581_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label909.Text);
        }

        private void button580_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label907.Text);
        }

        private void button579_Click_1(object sender, EventArgs e)
        {
            Cosmetics_Table(label903.Text);
        }

        #endregion Shop_Perfumery

        #endregion Perfumery

        #endregion Cosmetics

        #region Appliances

        #region Heaters
        private void panel_Heaters_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Appliances.AutoScroll = false;
            panel_Heaters.Location = new Point(0, 0);
            panel_Heaters.Visible = true;
        }
        private void panel_Heaters_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Heaters_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Heaters_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Heaters_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button689_Click_1(object sender, EventArgs e)
        {
            panel_Appliances.AutoScroll = true;
            panel_Heaters.Visible = false;
        }

        #region Shop_Heaters
        private void button690_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1134.Text);
        }

        private void button688_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1132.Text);
        }

        private void button687_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1130.Text);
        }

        private void button686_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1128.Text);
        }

        private void button685_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1126.Text);
        }

        private void button684_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1124.Text);
        }

        private void button691_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1136.Text);
        }

        private void button683_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1112.Text);
        }

        private void button682_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1108.Text);
        }

        private void button681_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1104.Text);
        }

        #endregion Shop_Heaters

        #endregion Heaters

        #region Refrigerator
        private void panel_Refrigerator_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Appliances.AutoScroll = false;
            panel_Refrigerator.Location = new Point(0, 0);
            panel_Refrigerator.Visible = true;
        }

        private void panel_Refrigerator_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Refrigerator_Button.BackColor = Color.FromArgb(34, 32, 44);
        }

        private void panel_Refrigerator_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Refrigerator_Button.BackColor = Color.FromArgb(28, 26, 38);
        }

        private void button678_Click_1(object sender, EventArgs e)
        {
            panel_Appliances.AutoScroll = true;
            panel_Refrigerator.Visible = false;
        }

        #region Shop_Refrigerator
        private void button679_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1096.Text);
        }

        private void button677_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1094.Text);
        }

        private void button676_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1090.Text);
        }

        private void button675_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1088.Text);
        }

        private void button674_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1086.Text);
        }

        private void button673_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1082.Text);
        }

        private void button680_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1100.Text);
        }

        private void button672_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1078.Text);
        }

        private void button671_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1076.Text);
        }

        private void button670_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1074.Text);
        }

        #endregion Shop_Refrigerator

        #endregion Refrigerator

        #region Washing
        private void panel_Washing_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Appliances.AutoScroll = false;
            panel_Washing.Location = new Point(0, 0);
            panel_Washing.Visible = true;
        }

        private void panel_Washing_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Washing_Button.BackColor = Color.FromArgb(34, 32, 44);
        }

        private void panel_Washing_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Washing_Button.BackColor = Color.FromArgb(28, 26, 38);
        }

        private void button662_Click_1(object sender, EventArgs e)
        {
            panel_Appliances.AutoScroll = true;
            panel_Washing.Visible = false;
        }

        #region Shop_Washing
        private void button669_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1070.Text);
        }

        private void button660_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1068.Text);
        }

        private void button658_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1066.Text);
        }

        private void button656_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1064.Text);
        }

        private void button654_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1062.Text);
        }

        private void button653_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1056.Text);
        }

        private void button668_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1072.Text);
        }

        private void button651_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1054.Text);
        }

        private void button650_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1052.Text);
        }

        private void button649_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1050.Text);
        }

        #endregion Shop_Washing

        #endregion Washing

        #region Blender
        private void panel_Blender_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Appliances.AutoScroll = false;
            panel_Blender.Location = new Point(0, 0);
            panel_Blender.Visible = true;
        }
        private void panel_Blender_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Blender_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Blender_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Blender_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button574_Click_1(object sender, EventArgs e)
        {
            panel_Appliances.AutoScroll = true;
            panel_Blender.Visible = false;
        }

        #region Shop_Blender
        private void button645_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1046.Text);
        }

        private void button572_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label899.Text);
        }

        private void button570_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label897.Text);
        }

        private void button568_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label895.Text);
        }

        private void button566_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label893.Text);
        }

        private void button565_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label891.Text);
        }

        private void button647_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label1048.Text);
        }

        private void button563_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label889.Text);
        }

        private void button562_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label887.Text);
        }

        private void button561_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label885.Text);
        }


        #endregion Shop_Blender

        #endregion Blender

        #region Coffee
        private void panel_Coffee_Button_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Appliances.AutoScroll = false;
            panel_Coffee.Location = new Point(0, 0);
            panel_Coffee.Visible = true;
        }
        private void panel_Coffee_Button_MouseEnter(object sender, EventArgs e)
        {
            panel_Coffee_Button.BackColor = Color.FromArgb(34, 32, 44);
        }
        private void panel_Coffee_Button_MouseLeave(object sender, EventArgs e)
        {
            panel_Coffee_Button.BackColor = Color.FromArgb(28, 26, 38);
        }
        private void button556_Click_1(object sender, EventArgs e)
        {
            panel_Appliances.AutoScroll = true;
            panel_Coffee.Visible = false;
        }

        #region Shop_Coffee
        private void button557_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label881.Text);
        }

        private void button555_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label879.Text);
        }

        private void button554_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label877.Text);
        }

        private void button553_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label875.Text);
        }

        private void button552_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label873.Text);
        }

        private void button551_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label871.Text);
        }

        private void button559_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label883.Text);
        }

        private void button550_Click_1(object sender, EventArgs e)
        {
            Appliances_Table(label869.Text);
        }

        private void button540_Click_2(object sender, EventArgs e)
        {
            Appliances_Table(label851.Text);
        }

        private void button539_Click_2(object sender, EventArgs e)
        {
            Appliances_Table(label849.Text);
        }

        #endregion Shop_Coffee

        #endregion Coffee

        #endregion Appliances


        #region Add_Ithem_In_Order
        private void button3_Click_2(object sender, EventArgs e) //панель для выбор оплаты
        {
            if (checkPriceOrder())
            {
                return;
            }

            panel_Payment_Credit.Visible = false;
            panel_Delivery.Visible = false;

            panel_Choise_Money_Credit.Location = new Point(343, 252);
            panel_Choise_Money_Credit.Visible = true;
        }

        bool check_card = false; // переменна для карты способ оплаты
        bool check_money = false; // переменна для денег способ оплаты

        private void button6_Click_1(object sender, EventArgs e) // врубаеб то что выбрали. либо картой оплата либо наличными
        {
            if (radioButton_Credit.Checked == true) //карта
            {
                check_card = true;
                panel_Choise_Money_Credit.Visible = false;
                panel_Payment_Credit.Location = new Point(250, 232);
                panel_Payment_Credit.Visible = true;
            }
            if(radioButton_Money.Checked == true) //наличные
            {
                check_money = true;
                panel_Choise_Money_Credit.Visible = false;
                panel_Delivery.Location = new Point(250, 232);
                panel_Delivery.Visible = true;
            }
        }

        private void button_panel_Payment_Credit_Click(object sender, EventArgs e) //проверка на ввод карты
        {
            if(textBox_CVV.Text == "" || textBox_DateMonth.Text == "" || textBox_DateYear.Text == "" || textBox_NumerCredit.Text == "" || textBox_OwnerCredit.Text == "")
            {
                panel_Check_Card.Location = new Point(0, 0);
                panel_Check_Card.Visible = true;
            }
            else
            {
                panel_Payment_Credit.Visible = false;
                panel_Delivery.Location = new Point(250, 232);
                panel_Delivery.Visible = true;
            }
        }
        private void button_Delivery_Click(object sender, EventArgs e) //проверка на доставку
        {
            string delivery_check = Convert.ToString(comboBox1.SelectedItem);

            if (delivery_check == "")
            {
                label37.Visible = false;
                label36.Visible = true;

                button_CheckDeliveryYES.Visible = false;
                button_CheckDelivery.Visible = true;

                panel_CheckDelivery.Location = new Point(0, 0);
                panel_CheckDelivery.Visible = true;
            }
            else
            {
                label36.Visible = false;
                label37.Location = new Point(131, 29);
                label37.Visible = true;

                button_CheckDelivery.Visible = false;
                button_CheckDeliveryYES.Location = new Point(146, 58);
                button_CheckDeliveryYES.Visible = true;

                panel_CheckDelivery.Location = new Point(0, 0);
                panel_CheckDelivery.Visible = true;
            }
        }

        private void button_NotPayment_Click(object sender, EventArgs e) //отказ от покупки картой
        {
            textBox_CVV.Text = "";
            textBox_DateMonth.Text = "";
            textBox_DateYear.Text = "";
            textBox_NumerCredit.Text = "";
            textBox_OwnerCredit.Text = "";

            panel_Payment_Credit.Visible = false;
            panel_Delivery.Visible = false;
        }
        private void button_NotDelivery_Click(object sender, EventArgs e) //отказ от покупки наличкой
        {
            panel_Delivery.Visible = false;
        }
        private void button10_Click_1(object sender, EventArgs e)
        {
            panel_Choise_Money_Credit.Visible = false;
        } //отказ от покупки

        private void button_Check_Card_Click(object sender, EventArgs e) //отключение проверка на карту
        {
            panel_Check_Card.Visible = false;
        }
        private void button_CheckDelivery_Click(object sender, EventArgs e) //отлючение проверки на доставку
        {
            panel_CheckDelivery.Visible = false;
        }

        private void button_CheckDeliveryYES_Click(object sender, EventArgs e) //принятие адрес доставки
        {
            Add_Data_In_Order_Table();
            RealodData();
            labelSumm.Text = "00.00";
            textBox_NumerCredit.Text = "";
            textBox_DateMonth.Text = "";
            textBox_DateYear.Text = "";
            textBox_CVV.Text = "";
            textBox_OwnerCredit.Text = "";

            panel_CheckDelivery.Visible = false;
            panel_Delivery.Visible = false;
        }

        private void Add_Data_In_Order_Table() // Обработка данных для добавления в таблицу заказов
        {
            //
            // Генерация рандомного номера заказа
            //
            Random random = new Random(); 
            int number_random_order = random.Next(1, 1000000);

            //
            // Переменные для записи данных заказчика в таблицу
            //
            string Name_Order = labelName.Text;
            string Surname_Order = labelSername.Text;
            string Email_Order = labelEmail.Text;
            string Telephone_Order = labelTelepgone.Text;

            //
            // Переменна для записи стоимости заказа
            //
            string Price_Order = labelSumm.Text;

            //
            // Переменна для записи доставки
            //
            string Delivery_Order = comboBox1.SelectedItem.ToString();

            //
            // Переменны для записи оплаты
            //
            string Pay_Card = radioButton_Credit.Text;
            string Pay_Money = radioButton_Money.Text;

            //
            // Переменны для записи данные карты заказчика
            //
            string Number_Card = textBox_NumerCredit.Text;
            string DateMontr_Card = textBox_DateMonth.Text;
            string DateYear_Card = textBox_DateYear.Text;
            string CVV_Card = textBox_CVV.Text;
            string Owner_Card = textBox_OwnerCredit.Text;

            //
            // Переменна для записи доставлен товар или нет
            //
            string Delivery_Order_Yes = "Доставлен";
            string Delivery_Order_No = "Не доставлен";

            //
            // Запись заказа в таблицу Заказов
            //
            SqlCommand command = new SqlCommand("INSERT INTO [Order] ([Заказ], [Количество], [Имя заказчика], [Фамилия заказчика], [Email заказчика], [Телефон заказчика], [Стоимость заказа], [Доставить], [Оплата], [Данные карты], [Номер заказа], [Доставлено]) SELECT [Заказ], [Количество], @name, @surname, @email, @phone, @orderprice, @pointdelivery, @pay, @datecard, @numberirder, @delivery FROM [Local_Order_User]", sqlConnection);

            //
            // Записываем данные владельца заказа и куда доставлять
            //
            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = Name_Order; //добавить имя
            command.Parameters.Add("@surname", SqlDbType.NVarChar).Value = Surname_Order; //добавить фамилию
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = Email_Order; //добавить емаил
            command.Parameters.Add("@phone", SqlDbType.VarChar).Value = Telephone_Order; //добавить телефон
            command.Parameters.Add("@orderprice", SqlDbType.VarChar).Value = Price_Order; //добавить цену заказа
            command.Parameters.Add("@pointdelivery", SqlDbType.NVarChar).Value = Delivery_Order; //добавить точку доставки

            //
            // Проверка чем оплачивает
            //
            if (check_card == true)
            {
                command.Parameters.Add("@pay", SqlDbType.NVarChar).Value = Pay_Card; //добавить способ оплаты
                command.Parameters.Add("@datecard", SqlDbType.NVarChar).Value = Number_Card + " " + DateMontr_Card + " " + DateYear_Card + " " + CVV_Card + " " + Owner_Card; //добавить данные карты
                check_card = false;
            }
            if (check_money == true)
            {
                command.Parameters.Add("@pay", SqlDbType.NVarChar).Value = Pay_Money; //добавить способ оплаты
                command.Parameters.Add("@datecard", SqlDbType.NVarChar).Value = "NULL"; //добавить данные карты
                check_money = false;
            }

            //
            // Привязка номеру заказа и состояние доставки
            //
            command.Parameters.Add("@numberirder", SqlDbType.Int).Value = number_random_order; //добавить номер заказа
            command.Parameters.Add("@delivery", SqlDbType.NVarChar).Value = Delivery_Order_No; //добавить доставлен заказ или нет

            //
            // Цикл для вычитывания количества товара из склада
            //
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string Oredr_Label = dataGridView1.Rows[i].Cells[1].Value.ToString();
                int Order_Count = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value.ToString());
                Check_Table_Count(Oredr_Label, Order_Count);
            }

            command.ExecuteNonQuery();

            //
            // Очистка локальйно бд
            //
            SqlCommand command_clear = new SqlCommand("DELETE FROM [Local_Order_User]", sqlConnection);
            command_clear.ExecuteNonQuery();
        }

        public void Check_Table_Count(string label, int count) //Вычитание из количества
        {
            //
            // Переменная для обновление количества
            //
            int count_update = 0;


            //
            // Выборка из табл аксесуаров
            //
            SqlCommand command_reader_Accessories = new SqlCommand("SELECT [Количество] - " + count + " AS COUNT FROM [Accessories] WHERE [Модель] = N'" + label + "'", sqlConnection);
            var count_command_Accessories = command_reader_Accessories.ExecuteReader();

            if (count_command_Accessories.Read())
            {
                count_update = Convert.ToInt32(count_command_Accessories["COUNT"].ToString());
                SqlCommand command_reader_Accessories_Update = new SqlCommand("UPDATE [Accessories] SET [Количество] = " + count_update + " WHERE [Модель] = N'" + label + "'", sqlConnection);
                count_command_Accessories.Close();
                command_reader_Accessories_Update.ExecuteNonQuery();
                count_update = 0;
            }
            else
            {
                count_command_Accessories.Close();
            }

            //
            // Выборка из табл бытовая техника
            //
            SqlCommand command_reader_Appliances = new SqlCommand("SELECT [Количество] - " + count + " AS COUNT FROM [Appliances] WHERE [Модель] = N'" + label + "'", sqlConnection);
            var count_command_Appliances = command_reader_Appliances.ExecuteReader();

            if (count_command_Appliances.Read())
            {
                count_update = Convert.ToInt32(count_command_Appliances["COUNT"].ToString());
                SqlCommand command_reader_Appliances_Update = new SqlCommand("UPDATE [Appliances] SET [Количество] = " + count_update + " WHERE [Модель] = N'" + label + "'", sqlConnection);
                count_command_Appliances.Close();
                command_reader_Appliances_Update.ExecuteNonQuery();
                count_update = 0;
            }
            else
            {
                count_command_Appliances.Close();
            }

            //
            // Выборка из табл одежда
            //
            SqlCommand command_reader_Clothes = new SqlCommand("SELECT [Количество] - " + count + " AS COUNT FROM [Clothes] WHERE [Модель] = N'" + label + "'", sqlConnection);
            var count_command_Clothes = command_reader_Clothes.ExecuteReader();

            if (count_command_Clothes.Read())
            {
                count_update = Convert.ToInt32(count_command_Clothes["COUNT"].ToString());
                SqlCommand command_reader_Clothes_Update = new SqlCommand("UPDATE [Clothes] SET [Количество] = " + count_update + " WHERE [Модель] = N'" + label + "'", sqlConnection);
                count_command_Clothes.Close();
                command_reader_Clothes_Update.ExecuteNonQuery();
                count_update = 0;
            }
            else
            {
                count_command_Clothes.Close();
            }

            //
            // Выборка из табл косметика
            //
            SqlCommand command_reader_Cosmetics = new SqlCommand("SELECT [Количетво] - " + count + " AS COUNT FROM [Cosmetics] WHERE [Модель] = N'" + label + "'", sqlConnection);
            var count_command_Cosmetics = command_reader_Cosmetics.ExecuteReader();

            if (count_command_Cosmetics.Read())
            {
                count_update = Convert.ToInt32(count_command_Cosmetics["COUNT"].ToString());
                SqlCommand command_reader_Cosmetics_Update = new SqlCommand("UPDATE [Cosmetics] SET [Количетво] = " + count_update + " WHERE [Модель] = N'" + label + "'", sqlConnection);
                count_command_Cosmetics.Close();
                command_reader_Cosmetics_Update.ExecuteNonQuery();
                count_update = 0;
            }
            else
            {
                count_command_Cosmetics.Close();
            }

            //
            // Выборка из табл электроника
            //
            SqlCommand command_reader_Electronics = new SqlCommand("SELECT [Количество] - " + count + " AS COUNT FROM [Electronics] WHERE [Модель] = N'" + label + "'", sqlConnection);
            var count_command_Electronics = command_reader_Electronics.ExecuteReader();

            if (count_command_Electronics.Read())
            {
                count_update = Convert.ToInt32(count_command_Electronics["COUNT"].ToString());
                SqlCommand command_reader_Electronics_Update = new SqlCommand("UPDATE [Electronics] SET [Количество] = " + count_update + " WHERE [Модель] = N'" + label + "'", sqlConnection);
                count_command_Electronics.Close();
                command_reader_Electronics_Update.ExecuteNonQuery();
                count_update = 0;
            }
            else
            {
                count_command_Electronics.Close();
            }

            //
            // Выборка из табл Спорт
            //
            SqlCommand command_reader_Sport = new SqlCommand("SELECT [Количество] - " + count + " AS COUNT FROM [Sport] WHERE [Модель] = N'" + label + "'", sqlConnection);
            var count_command_Sport = command_reader_Sport.ExecuteReader();

            if (count_command_Sport.Read())
            {
                count_update = Convert.ToInt32(count_command_Sport["COUNT"].ToString());
                SqlCommand command_reader_Sport_Update = new SqlCommand("UPDATE [Sport] SET [Количество] = " + count_update + " WHERE [Модель] = N'" + label + "'", sqlConnection);
                count_command_Sport.Close();
                command_reader_Sport_Update.ExecuteNonQuery();
                count_update = 0;
            }
            else
            {
                count_command_Sport.Close();
            }

           
        }
        public Boolean checkPriceOrder()
        {
            string Price_Order = labelSumm.Text;

            if (Price_Order == "00.00" || Convert.ToInt32(Price_Order) == 0) 
            {
                panelUpdateDateOrder.Location = new Point(224, 250);
                panelUpdateDateOrder.Visible = true;
                return true;
            }
            else if (Convert.ToInt32(Price_Order) < Convert.ToInt32(labelSumm.Text))
            {
                panelUpdateDateOrder.Visible = true;
                return true;
            }
            else if (Convert.ToInt32(Price_Order) > Convert.ToInt32(labelSumm.Text))
            {
                panelUpdateDateOrder.Visible = true;
                return true;
            }
            else
            {
                return false;
            }
        } // проверка на обновление данных
        private void buttonpanelUpdateDateOrder_Click(object sender, EventArgs e)
        {
            panelUpdateDateOrder.Visible = false;
        } // закрытие панели обновление данных

        #endregion Add_Ithem_In_Order




        #region Trash
        private void button485_Click(object sender, EventArgs e)
        {

        }
        private void panel_Perfumery_Button_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button540_Click_1(object sender, EventArgs e)
        {

        }

        private void button539_Click_1(object sender, EventArgs e)
        {

        }
        private void label548_Click(object sender, EventArgs e)
        {

        }
        private void button321_Click(object sender, EventArgs e)
        {

        }

        private void button322_Click(object sender, EventArgs e)
        {

        }

        private void button330_Click(object sender, EventArgs e)
        {

        }

        private void button329_Click(object sender, EventArgs e)
        {

        }

        private void button328_Click(object sender, EventArgs e)
        {

        }

        private void button327_Click(object sender, EventArgs e)
        {

        }

        private void button326_Click(object sender, EventArgs e)
        {

        }

        private void button325_Click(object sender, EventArgs e)
        {

        }

        private void button331_Click(object sender, EventArgs e)
        {

        }

        private void button324_Click(object sender, EventArgs e)
        {

        }

        private void button323_Click(object sender, EventArgs e)
        {

        }

        private void button335_Click(object sender, EventArgs e)
        {

        }

        private void button339_Click(object sender, EventArgs e)
        {

        }

        private void button340_Click(object sender, EventArgs e)
        {

        }

        private void button338_Click(object sender, EventArgs e)
        {

        }

        private void button336_Click(object sender, EventArgs e)
        {

        }

        private void button334_Click(object sender, EventArgs e)
        {

        }

        private void button337_Click(object sender, EventArgs e)
        {

        }

        private void button333_Click(object sender, EventArgs e)
        {

        }

        private void button332_Click(object sender, EventArgs e)
        {

        }

        private void button496_Click(object sender, EventArgs e)
        {

        }

        private void button495_Click(object sender, EventArgs e)
        {

        }

        private void button493_Click(object sender, EventArgs e)
        {

        }

        private void button491_Click(object sender, EventArgs e)
        {

        }

        private void button352_Click(object sender, EventArgs e)
        {

        }

        private void button350_Click(object sender, EventArgs e)
        {

        }

        private void button497_Click(object sender, EventArgs e)
        {

        }

        private void button347_Click(object sender, EventArgs e)
        {

        }

        private void button345_Click(object sender, EventArgs e)
        {

        }

        private void button344_Click(object sender, EventArgs e)
        {

        }

        private void button342_Click(object sender, EventArgs e)
        {
        }

        private void button341_Click(object sender, EventArgs e)
        {

        }

        private void button348_Click(object sender, EventArgs e)
        {

        }

        private void button492_Click(object sender, EventArgs e)
        {

        }

        private void button494_Click(object sender, EventArgs e)
        {

        }

        private void button490_Click(object sender, EventArgs e)
        {

        }

        private void button349_Click(object sender, EventArgs e)
        {

        }

        private void button346_Click(object sender, EventArgs e)
        {

        }

        private void button351_Click(object sender, EventArgs e)
        {

        }

        private void button343_Click(object sender, EventArgs e)
        {

        }
        private void button507_Click(object sender, EventArgs e)
        {

        }

        private void button502_Click(object sender, EventArgs e)
        {

        }

        private void button500_Click(object sender, EventArgs e)
        {

        }

        private void button514_Click(object sender, EventArgs e)
        {

        }

        private void button521_Click(object sender, EventArgs e)
        {

        }

        private void button523_Click(object sender, EventArgs e)
        {

        }

        private void button519_Click(object sender, EventArgs e)
        {

        }

        private void button515_Click(object sender, EventArgs e)
        {

        }

        private void button511_Click(object sender, EventArgs e)
        {

        }

        private void button517_Click(object sender, EventArgs e)
        {

        }

        private void button505_Click(object sender, EventArgs e)
        {

        }

        private void button498_Click(object sender, EventArgs e)
        {

        }

        private void button503_Click(object sender, EventArgs e)
        {

        }

        private void button510_Click(object sender, EventArgs e)
        {

        }

        private void button512_Click(object sender, EventArgs e)
        {

        }

        private void button508_Click(object sender, EventArgs e)
        {

        }

        private void button504_Click(object sender, EventArgs e)
        {

        }

        private void button501_Click(object sender, EventArgs e)
        {

        }

        private void button506_Click(object sender, EventArgs e)
        {

        }

        private void button499_Click(object sender, EventArgs e)
        {

        }

        private void button373_Click(object sender, EventArgs e)
        {

        }

        private void button371_Click(object sender, EventArgs e)
        {

        }

        private void button370_Click(object sender, EventArgs e)
        {

        }

        private void button368_Click(object sender, EventArgs e)
        {

        }

        private void button366_Click(object sender, EventArgs e)
        {

        }

        private void button364_Click(object sender, EventArgs e)
        {

        }

        private void button362_Click(object sender, EventArgs e)
        {

        }

        private void button372_Click(object sender, EventArgs e)
        {

        }

        private void button359_Click(object sender, EventArgs e)
        {

        }

        private void button357_Click(object sender, EventArgs e)
        {

        }

        private void button356_Click(object sender, EventArgs e)
        {

        }

        private void button354_Click(object sender, EventArgs e)
        {

        }

        private void button353_Click(object sender, EventArgs e)
        {

        }

        private void button360_Click(object sender, EventArgs e)
        {

        }

        private void button367_Click(object sender, EventArgs e)
        {

        }

        private void button369_Click(object sender, EventArgs e)
        {

        }

        private void button365_Click(object sender, EventArgs e)
        {

        }

        private void button361_Click(object sender, EventArgs e)
        {

        }

        private void button358_Click(object sender, EventArgs e)
        {

        }

        private void button363_Click(object sender, EventArgs e)
        {

        }

        private void button355_Click(object sender, EventArgs e)
        {

        }
        private void button553_Click(object sender, EventArgs e)
        {

        }

        private void button551_Click(object sender, EventArgs e)
        {

        }

        private void button565_Click(object sender, EventArgs e)
        {

        }

        private void button572_Click(object sender, EventArgs e)
        {

        }

        private void button574_Click(object sender, EventArgs e)
        {

        }

        private void button570_Click(object sender, EventArgs e)
        {

        }

        private void button566_Click(object sender, EventArgs e)
        {

        }

        private void button562_Click(object sender, EventArgs e)
        {

        }

        private void button568_Click(object sender, EventArgs e)
        {

        }

        private void button556_Click(object sender, EventArgs e)
        {

        }

        private void button549_Click(object sender, EventArgs e)
        {

        }

        private void button554_Click(object sender, EventArgs e)
        {

        }

        private void button561_Click(object sender, EventArgs e)
        {

        }

        private void button563_Click(object sender, EventArgs e)
        {

        }

        private void button559_Click(object sender, EventArgs e)
        {

        }

        private void button555_Click(object sender, EventArgs e)
        {

        }

        private void button552_Click(object sender, EventArgs e)
        {

        }

        private void button557_Click(object sender, EventArgs e)
        {

        }

        private void button550_Click(object sender, EventArgs e)
        {

        }

        private void button548_Click(object sender, EventArgs e)
        {

        }

        private void button546_Click(object sender, EventArgs e)
        {

        }

        private void button545_Click(object sender, EventArgs e)
        {

        }

        private void button543_Click(object sender, EventArgs e)
        {

        }

        private void button541_Click(object sender, EventArgs e)
        {

        }

        private void button539_Click(object sender, EventArgs e)
        {

        }

        private void button537_Click(object sender, EventArgs e)
        {

        }

        private void button547_Click(object sender, EventArgs e)
        {

        }

        private void button534_Click(object sender, EventArgs e)
        {

        }

        private void button532_Click(object sender, EventArgs e)
        {

        }

        private void button531_Click(object sender, EventArgs e)
        {

        }

        private void button529_Click(object sender, EventArgs e)
        {

        }

        private void button528_Click(object sender, EventArgs e)
        {

        }

        private void button535_Click(object sender, EventArgs e)
        {

        }

        private void button542_Click(object sender, EventArgs e)
        {

        }

        private void button544_Click(object sender, EventArgs e)
        {

        }

        private void button540_Click(object sender, EventArgs e)
        {

        }

        private void button536_Click(object sender, EventArgs e)
        {

        }

        private void button533_Click(object sender, EventArgs e)
        {

        }

        private void button538_Click(object sender, EventArgs e)
        {

        }

        private void button530_Click(object sender, EventArgs e)
        {

        }
        private void button641_Click(object sender, EventArgs e)
        {

        }

        private void button639_Click(object sender, EventArgs e)
        {

        }

        private void button653_Click(object sender, EventArgs e)
        {

        }

        private void button660_Click(object sender, EventArgs e)
        {

        }

        private void button662_Click(object sender, EventArgs e)
        {

        }

        private void button658_Click(object sender, EventArgs e)
        {

        }

        private void button654_Click(object sender, EventArgs e)
        {

        }

        private void button650_Click(object sender, EventArgs e)
        {

        }

        private void button656_Click(object sender, EventArgs e)
        {

        }

        private void button644_Click(object sender, EventArgs e)
        {

        }

        private void button637_Click(object sender, EventArgs e)
        {

        }

        private void button642_Click(object sender, EventArgs e)
        {

        }

        private void button649_Click(object sender, EventArgs e)
        {

        }

        private void button651_Click(object sender, EventArgs e)
        {

        }

        private void button647_Click(object sender, EventArgs e)
        {

        }

        private void button643_Click(object sender, EventArgs e)
        {

        }

        private void button640_Click(object sender, EventArgs e)
        {

        }

        private void button645_Click(object sender, EventArgs e)
        {

        }

        private void button638_Click(object sender, EventArgs e)
        {

        }

        private void button636_Click(object sender, EventArgs e)
        {

        }

        private void button634_Click(object sender, EventArgs e)
        {

        }

        private void button633_Click(object sender, EventArgs e)
        {

        }

        private void button631_Click(object sender, EventArgs e)
        {

        }

        private void button629_Click(object sender, EventArgs e)
        {

        }

        private void button627_Click(object sender, EventArgs e)
        {

        }

        private void button625_Click(object sender, EventArgs e)
        {

        }

        private void button635_Click(object sender, EventArgs e)
        {

        }

        private void button622_Click(object sender, EventArgs e)
        {

        }

        private void button620_Click(object sender, EventArgs e)
        {

        }

        private void button619_Click(object sender, EventArgs e)
        {

        }

        private void button617_Click(object sender, EventArgs e)
        {

        }

        private void button616_Click(object sender, EventArgs e)
        {

        }

        private void button623_Click(object sender, EventArgs e)
        {

        }

        private void button630_Click(object sender, EventArgs e)
        {

        }

        private void button632_Click(object sender, EventArgs e)
        {

        }

        private void button628_Click(object sender, EventArgs e)
        {

        }

        private void button624_Click(object sender, EventArgs e)
        {

        }

        private void button621_Click(object sender, EventArgs e)
        {

        }

        private void button626_Click(object sender, EventArgs e)
        {

        }

        private void button618_Click(object sender, EventArgs e)
        {

        }

        private void button590_Click(object sender, EventArgs e)
        {

        }

        private void button588_Click(object sender, EventArgs e)
        {

        }

        private void button602_Click(object sender, EventArgs e)
        {

        }

        private void button609_Click(object sender, EventArgs e)
        {

        }

        private void button611_Click(object sender, EventArgs e)
        {

        }

        private void button607_Click(object sender, EventArgs e)
        {

        }

        private void button603_Click(object sender, EventArgs e)
        {

        }

        private void button599_Click(object sender, EventArgs e)
        {

        }

        private void button605_Click(object sender, EventArgs e)
        {

        }

        private void button593_Click(object sender, EventArgs e)
        {

        }

        private void button586_Click(object sender, EventArgs e)
        {

        }

        private void button591_Click(object sender, EventArgs e)
        {

        }

        private void button598_Click(object sender, EventArgs e)
        {

        }

        private void button600_Click(object sender, EventArgs e)
        {

        }

        private void button596_Click(object sender, EventArgs e)
        {

        }

        private void button592_Click(object sender, EventArgs e)
        {

        }

        private void button589_Click(object sender, EventArgs e)
        {

        }

        private void button594_Click(object sender, EventArgs e)
        {

        }

        private void button587_Click(object sender, EventArgs e)
        {

        }

        private void button585_Click(object sender, EventArgs e)
        {

        }

        private void button583_Click(object sender, EventArgs e)
        {

        }

        private void button582_Click(object sender, EventArgs e)
        {

        }

        private void button580_Click(object sender, EventArgs e)
        {

        }

        private void button320_Click(object sender, EventArgs e)
        {

        }

        private void button318_Click(object sender, EventArgs e)
        {

        }

        private void button316_Click(object sender, EventArgs e)
        {

        }

        private void button584_Click(object sender, EventArgs e)
        {

        }

        private void button313_Click(object sender, EventArgs e)
        {

        }

        private void button311_Click(object sender, EventArgs e)
        {
        }

        private void button310_Click(object sender, EventArgs e)
        {

        }

        private void button308_Click(object sender, EventArgs e)
        {

        }

        private void button307_Click(object sender, EventArgs e)
        {

        }

        private void button314_Click(object sender, EventArgs e)
        {

        }

        private void button579_Click(object sender, EventArgs e)
        {

        }

        private void button581_Click(object sender, EventArgs e)
        {

        }

        private void button319_Click(object sender, EventArgs e)
        {

        }

        private void button315_Click(object sender, EventArgs e)
        {

        }

        private void button312_Click(object sender, EventArgs e)
        {

        }

        private void button317_Click(object sender, EventArgs e)
        {

        }

        private void button309_Click(object sender, EventArgs e)
        {

        }
        private void button281_Click(object sender, EventArgs e)
        {

        }

        private void button279_Click(object sender, EventArgs e)
        {

        }

        private void button293_Click(object sender, EventArgs e)
        {

        }

        private void button300_Click(object sender, EventArgs e)
        {

        }

        private void button302_Click(object sender, EventArgs e)
        {

        }

        private void button298_Click(object sender, EventArgs e)
        {

        }

        private void button294_Click(object sender, EventArgs e)
        {

        }

        private void button290_Click(object sender, EventArgs e)
        {

        }

        private void button296_Click(object sender, EventArgs e)
        {

        }

        private void button284_Click(object sender, EventArgs e)
        {

        }

        private void button277_Click(object sender, EventArgs e)
        {

        }

        private void button282_Click(object sender, EventArgs e)
        {

        }

        private void button289_Click(object sender, EventArgs e)
        {

        }

        private void button291_Click(object sender, EventArgs e)
        {

        }

        private void button287_Click(object sender, EventArgs e)
        {

        }

        private void button283_Click(object sender, EventArgs e)
        {

        }

        private void button280_Click(object sender, EventArgs e)
        {

        }

        private void button285_Click(object sender, EventArgs e)
        {

        }

        private void button278_Click(object sender, EventArgs e)
        {

        }

        private void button276_Click(object sender, EventArgs e)
        {

        }

        private void button274_Click(object sender, EventArgs e)
        {

        }

        private void button273_Click(object sender, EventArgs e)
        {

        }

        private void button271_Click(object sender, EventArgs e)
        {

        }

        private void button269_Click(object sender, EventArgs e)
        {

        }

        private void button267_Click(object sender, EventArgs e)
        {

        }

        private void button265_Click(object sender, EventArgs e)
        {

        }

        private void button275_Click(object sender, EventArgs e)
        {

        }

        private void button262_Click(object sender, EventArgs e)
        {

        }

        private void button260_Click(object sender, EventArgs e)
        {

        }

        private void button259_Click(object sender, EventArgs e)
        {
        }

        private void button257_Click(object sender, EventArgs e)
        {

        }

        private void button256_Click(object sender, EventArgs e)
        {

        }

        private void button263_Click(object sender, EventArgs e)
        {

        }

        private void button270_Click(object sender, EventArgs e)
        {

        }

        private void button272_Click(object sender, EventArgs e)
        {

        }

        private void button268_Click(object sender, EventArgs e)
        {

        }

        private void button264_Click(object sender, EventArgs e)
        {

        }

        private void button261_Click(object sender, EventArgs e)
        {

        }

        private void button266_Click(object sender, EventArgs e)
        {
        }

        private void button258_Click(object sender, EventArgs e)
        {

        }
        private void button693_Click(object sender, EventArgs e)
        {

        }

        private void button691_Click(object sender, EventArgs e)
        {

        }

        private void button705_Click(object sender, EventArgs e)
        {

        }

        private void button712_Click(object sender, EventArgs e)
        {

        }

        private void button714_Click(object sender, EventArgs e)
        {

        }

        private void button710_Click(object sender, EventArgs e)
        {

        }

        private void button706_Click(object sender, EventArgs e)
        {

        }

        private void button702_Click(object sender, EventArgs e)
        {

        }

        private void button708_Click(object sender, EventArgs e)
        {

        }

        private void button696_Click(object sender, EventArgs e)
        {

        }

        private void button689_Click(object sender, EventArgs e)
        {

        }

        private void button694_Click(object sender, EventArgs e)
        {

        }

        private void button701_Click(object sender, EventArgs e)
        {

        }

        private void button703_Click(object sender, EventArgs e)
        {

        }

        private void button699_Click(object sender, EventArgs e)
        {

        }

        private void button695_Click(object sender, EventArgs e)
        {

        }

        private void button692_Click(object sender, EventArgs e)
        {
        }

        private void button697_Click(object sender, EventArgs e)
        {
        }

        private void button690_Click(object sender, EventArgs e)
        {

        }

        private void button688_Click(object sender, EventArgs e)
        {

        }

        private void button686_Click(object sender, EventArgs e)
        {

        }

        private void button685_Click(object sender, EventArgs e)
        {

        }

        private void button683_Click(object sender, EventArgs e)
        {

        }

        private void button681_Click(object sender, EventArgs e)
        {

        }

        private void button679_Click(object sender, EventArgs e)
        {

        }

        private void button677_Click(object sender, EventArgs e)
        {

        }

        private void button687_Click(object sender, EventArgs e)
        {

        }

        private void button674_Click(object sender, EventArgs e)
        {

        }

        private void button672_Click(object sender, EventArgs e)
        {

        }

        private void button671_Click(object sender, EventArgs e)
        {

        }

        private void button669_Click(object sender, EventArgs e)
        {

        }

        private void button668_Click(object sender, EventArgs e)
        {

        }

        private void button675_Click(object sender, EventArgs e)
        {

        }

        private void button682_Click(object sender, EventArgs e)
        {

        }

        private void button684_Click(object sender, EventArgs e)
        {

        }

        private void button680_Click(object sender, EventArgs e)
        {

        }

        private void button676_Click(object sender, EventArgs e)
        {
        }

        private void button673_Click(object sender, EventArgs e)
        {

        }

        private void button678_Click(object sender, EventArgs e)
        {

        }

        private void button670_Click(object sender, EventArgs e)
        {

        }
        private void panel355_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
        private void button393_Click(object sender, EventArgs e) //поиск акссессуаров для волос
        {

        }

        private void button387_Click(object sender, EventArgs e) // происк женских товаров
        {

        }

        private void button253_Click(object sender, EventArgs e)
        {

        }
        private void button253_Click_1(object sender, EventArgs e)
        {
        }


        private void panel_Hoodie_Woman_Button_MouseDown(object sender, MouseEventArgs e)
        {

        }
        private void button143_Click(object sender, EventArgs e)
        {

        }
        private void button159_Click(object sender, EventArgs e)
        {
            
        }
        private void button93_Click(object sender, EventArgs e)
        {
            
        }

        private void panel_Accessories_Man_Belts_Button_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
        }
        private void panel_Delete_Order_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private void panel_Accessories_Man_Wallets_Button_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panel4_Paint(object sender, PaintEventArgs e) // не удалять
        {
            
        }
        private void button10_Click(object sender, EventArgs e) // не удалять
        {

        }
        private void button6_Click(object sender, EventArgs e) // не удалять
        {

        }
        private void button12_Click(object sender, EventArgs e) // не удалять
        {

        }

        private void button3_Click_1(object sender, EventArgs e) // не удалять
        {

        }

        private void button13_Click(object sender, EventArgs e) // не удалять
        {

        }
        private void panel1_Paint_1(object sender, PaintEventArgs e) // не удалять
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e) // не удалять
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e) // не удалять
        {

        }
        private void tableLayoutPanelClothes_Paint(object sender, PaintEventArgs e) // не удалять
        {

        }
        private void label7_Click(object sender, EventArgs e) // не удалять
        {

        }

        private void panelChildForm_Paint(object sender, PaintEventArgs e) // не удалять
        {

        }
        private void panelMain_Paint(object sender, PaintEventArgs e) // не удалять
        {

        }

        private void DB_button_Clear_Click(object sender, EventArgs e)
        {

        }
        private void panel_Count_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panelExit_Paint(object sender, PaintEventArgs e)
        {

        }
        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {

        }
        private void panelUpdateDateOrder_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e) //офромление заказа
        {

        }

        private void label188_Click(object sender, EventArgs e)
        {

        }

        private void panel_Jeans_Man_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_Sport_Bikesport_Button_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion Trush


    }
}
