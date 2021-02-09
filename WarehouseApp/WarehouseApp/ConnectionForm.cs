using System;
using System.Windows.Forms;

namespace WarehouseApp
{
    public partial class ConnectionForm : Form
    {
        public ConnectionForm()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxServer.Text))
            {
                MessageBox.Show("Введите адрес сервера БД");
                return;
            }
            if (string.IsNullOrEmpty(tbxDatabase.Text))
            {
                MessageBox.Show("Введите имя базы данных");
                return;
            }
            if (string.IsNullOrEmpty(tbxLogin.Text))
            {
                MessageBox.Show("Введите логин пользователя");
                return;
            }
            if (string.IsNullOrEmpty(tbxPassword.Text))
            {
                MessageBox.Show("Введите пароль");
                return;
            }
            if (Classes.Connection.Connect(tbxServer.Text, tbxDatabase.Text, tbxLogin.Text, tbxPassword.Text))
            {
                Hide();
                int mode = -1;
                if (rbDir.Checked) mode = 1;
                if (rbZav.Checked) mode = 2;
                if (rbKlad.Checked) mode = 0;
                if(mode == -1)
                {
                    MessageBox.Show("Выберите режим работы!");
                    return;
                }
                MainForm form = new MainForm(this, mode);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ошибка при подключении к базе данных: " + Classes.Connection.ConnectionError);
            }
        }
    }
}
