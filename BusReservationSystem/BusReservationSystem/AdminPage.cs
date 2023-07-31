using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusReservationSystem
{
    public partial class AdminPage : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("BusReservationSystem");
        static IMongoCollection<Buses> buscollection = db.GetCollection<Buses>("buses");
        static IMongoCollection<admincredentials> admincollection = db.GetCollection<admincredentials>("admin_credentials");

        public AdminPage()
        {
            InitializeComponent();
        }

        private void AdminPage_Load(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            bunifuGradientPanel3.Hide();
            bunifuImageButton2.Show();
            menu.Hide();
            usermenu.Hide();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            menu.Show();
            bunifuImageButton1.Hide();
            bunifuImageButton2.Show();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            menu.Hide();
            bunifuImageButton1.Show();
            bunifuImageButton2.Hide();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            usermenu.Show();
            bunifuImageButton3.Hide();
            bunifuImageButton4.Show();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            usermenu.Hide();
            bunifuImageButton3.Show();
            bunifuImageButton4.Hide();
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {
            LoginPage p = new LoginPage();
            p.Show();
            this.Hide();
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            LoginPage p = new LoginPage();
            p.Show();
            this.Hide();
        }

        private void bunifuGroupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            bunifuGradientPanel2.Hide();            
            Addbuses a = new Addbuses();
            a.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            bunifuGradientPanel2.Hide();
            
            Addbuses b = new Addbuses();
            b.Show();
            this.Hide();
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {

            bunifuGradientPanel3.Show();
            bunifuGradientPanel2.Hide();
            
        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

            bunifuGradientPanel3.Show();
            bunifuGradientPanel2.Hide();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            var credentials = new admincredentials
            {
                adminfname = txtAdminName.Text,
                adminusername = txtAdminuname.Text,
                adminpassword = txtAdminPass.Text
            };

            admincollection.InsertOne(credentials);
            MessageBox.Show("New Admin Added !!");
        }

        private void bunifuLabel7_Click(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            bunifuImageButton1.Show();
            bunifuImageButton2.Hide();
            bunifuGradientPanel3.Hide();
            bunifuGradientPanel2.Show();
            menu.Hide();
        }

        private void bunifuImageButton10_Click(object sender, EventArgs e)
        {
            bunifuImageButton1.Show();
            bunifuImageButton2.Hide();
            bunifuGradientPanel3.Hide();
            bunifuGradientPanel2.Show();
            menu.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            bunifuGradientPanel2.Hide();

            Addbuses b = new Addbuses();
            menu.Hide();
            b.Show();
            this.Hide();
        }

        private void bunifuImageButton11_Click(object sender, EventArgs e)
        {
            bunifuGradientPanel2.Hide();

            Addbuses b = new Addbuses();
            menu.Hide();
            b.Show();
            this.Hide();
        }

        private void bunifuLabel8_Click(object sender, EventArgs e)
        {
            bunifuImageButton1.Show();
            bunifuImageButton2.Hide();
            menu.Hide();
            bunifuGradientPanel3.Show();
            bunifuGradientPanel2.Hide();
        }

        private void bunifuImageButton12_Click(object sender, EventArgs e)
        {
            bunifuImageButton1.Show();
            bunifuImageButton2.Hide();
            menu.Hide();
            bunifuGradientPanel3.Show();
            bunifuGradientPanel2.Hide();
        }

        private void bunifuLabel9_Click(object sender, EventArgs e)
        {
            bunifuGradientPanel2.Hide();

            Addbuses b = new Addbuses();
            b.Show();
            this.Hide();
        }

        private void bunifuImageButton13_Click(object sender, EventArgs e)
        {
            bunifuGradientPanel2.Hide();

            Addbuses b = new Addbuses();
            b.Show();
            this.Hide();
        }

        private async void bunifuLabel10_Click(object sender, EventArgs e)
        {
            bunifuGradientPanel2.Hide();
            var documents = await buscollection.Find(new BsonDocument()).ToListAsync();
            dataGridView1.DataSource = documents;
        }

        private async void bunifuImageButton14_Click(object sender, EventArgs e)
        {
            bunifuGradientPanel2.Hide();
            var documents = await buscollection.Find(new BsonDocument()).ToListAsync();
            dataGridView1.DataSource = documents;
        }
        private void bunifuLabel11_Click_1(object sender, EventArgs e)
        {
            bunifuGradientPanel2.Hide();

            Addbuses b = new Addbuses();
            b.Show();
            this.Hide();
        }

        private void bunifuImageButton15_Click(object sender, EventArgs e)
        {
            menu.Hide();
            bunifuGradientPanel2.Hide();

            Addbuses b = new Addbuses();
            b.Show();
            this.Hide();
        }

        private async void bunifuLabel12_Click(object sender, EventArgs e)
        {
            menu.Hide();
            bunifuGradientPanel2.Hide();
            var documents = await buscollection.Find(new BsonDocument()).ToListAsync();
            dataGridView1.DataSource = documents;
        }

        private async void bunifuImageButton16_Click(object sender, EventArgs e)
        {
            menu.Hide();
            bunifuGradientPanel2.Hide();
            var documents = await buscollection.Find(new BsonDocument()).ToListAsync();
            dataGridView1.DataSource = documents;
            dataGridView1.Show();
        }


    }
}
