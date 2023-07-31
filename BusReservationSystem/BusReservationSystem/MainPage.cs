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
    public partial class MainPage : Form
    {
        public string Origin { get; set; }

        public string Destination { get; set; }

        public string DepartureDate { get; set; }


        public Int32 flag;

        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("BusReservationSystem");
        static IMongoCollection<Buses> buscollection = db.GetCollection<Buses>("buses");
        static IMongoCollection<curr_user> useridcollection = db.GetCollection<curr_user>("current_user");
        static IMongoCollection<Reservations> reservationcollection = db.GetCollection<Reservations>("reservations");

        public MainPage()
        {
            InitializeComponent();
        }


        public void ReadAll()
        {
            var filterDefinition = Builders<Buses>.Filter.Empty;
            var buses = buscollection.Find(filterDefinition).ToList();
            //dataGridView1.DataSource = buses;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            BusList form2 = new BusList();
            form2.Origin = txtOrigin.Text;
            form2.Destination = txtDestination.Text;
            form2.DepartureDate = dateTimePicker1.Value.ToShortDateString();
            form2.Show();
            this.Hide();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            menu.Hide();
            usermenu.Hide();
            bunifuGradientPanel1.Show();
            bunifuGradientPanel3.Hide();
            var documents = useridcollection.Find(new BsonDocument()).ToList();
            dataGridView2.DataSource = documents;

            string fname = dataGridView2.Rows[0].Cells[1].Value.ToString();
            labeldisplayname.Text = fname;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            menu.Show();
            bunifuImageButton9.Show();
            bunifuImageButton1.Hide();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            usermenu.Show();
            bunifuImageButton2.Show();
            bunifuImageButton3.Hide();
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {
            var documents = useridcollection.Find(new BsonDocument()).ToList();
            dataGridView2.DataSource = documents;

            string username = dataGridView2.Rows[0].Cells[1].Value.ToString();

            var filterdefinition = Builders<curr_user>.Filter.Eq(a => a.userid, username);
            useridcollection.DeleteOne(filterdefinition);

            LoginPage p = new LoginPage();
            p.Show();
            this.Hide();

        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            var documents = useridcollection.Find(new BsonDocument()).ToList();
            dataGridView2.DataSource = documents;

            string username = dataGridView2.Rows[0].Cells[1].Value.ToString();

            var filterdefinition = Builders<curr_user>.Filter.Eq(a => a.userid, username);
            useridcollection.DeleteOne(filterdefinition);

            LoginPage p = new LoginPage();
            p.Show();
            this.Hide();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            menu.Hide();
            bunifuGradientPanel3.Hide();
            bunifuGradientPanel1.Show();
            dataGridView3.Hide();
        }


        private void bunifuLabel2_Click(object sender, EventArgs e)
        {
            menu.Hide();
            bunifuGradientPanel3.Hide();
            bunifuGradientPanel1.Show();
            dataGridView3.Hide();

        }

        private void bunifuImageButton6_Click_1(object sender, EventArgs e)
        {
            menu.Hide();
            bunifuGradientPanel1.Hide();
            bunifuGradientPanel3.Show();
            dataGridView3.Hide();
        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {
            menu.Hide();
            bunifuGradientPanel1.Hide();
            bunifuGradientPanel3.Show();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            var filterDefinition = Builders<Reservations>.Filter;
            var filter = filterDefinition.Eq(a => a.pnr, txtPNR.Text);
            var search = reservationcollection.Find(filter).ToList();

            reservationcollection.DeleteOne(filter);
            MessageBox.Show("Booking Cancelled !!");

        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            var documents = useridcollection.Find(new BsonDocument()).ToList();
            dataGridView4.DataSource = documents;

            string username = dataGridView2.Rows[0].Cells[2].Value.ToString();



            var filterDefinition = Builders<Reservations>.Filter;
            var filter = filterDefinition.Eq(a => a.uid,username);
            var search = reservationcollection.Find(filter).ToList();
            dataGridView3.DataSource = search;
        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {
            menu.Hide();
            bunifuGradientPanel1.Hide();
            bunifuGradientPanel3.Hide();

            var documents = useridcollection.Find(new BsonDocument()).ToList();
            dataGridView4.DataSource = documents;

            string username = dataGridView2.Rows[0].Cells[2].Value.ToString();

      

            var filterDefinition = Builders<Reservations>.Filter;
            var filter = filterDefinition.Eq(a => a.uid, username);
            var search = reservationcollection.Find(filter).ToList();
            dataGridView3.DataSource = search;
        }

        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            menu.Hide();
            bunifuImageButton9.Hide();
            bunifuImageButton1.Show();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            usermenu.Hide();
            bunifuImageButton2.Hide();
            bunifuImageButton3.Show();
        }
    }
}
