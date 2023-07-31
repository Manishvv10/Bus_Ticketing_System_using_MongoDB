using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
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
    public partial class BookingPage : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("BusReservationSystem");
        static IMongoCollection<Buses> buscollection = db.GetCollection<Buses>("buses");
        static IMongoCollection<Reservations> reservationcollection = db.GetCollection<Reservations>("reservations");
        static IMongoCollection<curr_user> useridcollection = db.GetCollection<curr_user>("current_user");

        public string bus { get; set; }

        public string uniqq { get; set; }

        public Int32 availseat { get; set; }

        public string BusId { get; set; }

        public string PNR;

        public BookingPage()
        {
            InitializeComponent();
        }



        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            //var filterDefinition = Builders<curr_user>.Filter;
            // var filter = filterDefinition.Eq( )
            var documents = useridcollection.Find(new BsonDocument()).ToList();
            dataGridView3.DataSource = documents;

            string username = dataGridView3.Rows[0].Cells[1].Value.ToString();


            Random r = new Random();
            int randomno = r.Next(0, availseat);

            PNR = RandomString(10);
            Ticket t = new Ticket();
            t.pnrr = PNR;


            var reserv = new Reservations
            {
                uid = username,
                pnr = PNR,
                p_name = txtName.Text,
                busnum = Convert.ToString(bus),
                p_age = Int32.Parse(txtAge.Text),
                p_gen = txtGender.Text,
                Seatno = randomno,
                email = txtEmail.Text,
                phone = txtPhone.Text,
                uni = uniqq,
                currtime = DateTime.Now.ToString("dddd , MMM dd yyyy,hh:mm:ss"),
            };
            reservationcollection.InsertOne(reserv);

            MessageBox.Show("Ticket Successfully Booked!!\n Press Ok to View Ticket");

            t.uniquee = uniqq;
            updateseat();


            MainPage page = new MainPage();
            page.Show();

            t.Show();
            this.Hide();
        }


        private void BookingPage_Load(object sender, EventArgs e)
        {
            LoadDetails();
        }

        public void LoadDetails()
        {
            var filterDefinition = Builders<Buses>.Filter;
            var filter = filterDefinition.Eq(a => a.BusId,BusId );
            var search = buscollection.Find(filter).ToList();
            dataGridView1.DataSource = search;
    
            label9.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            label10.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
            label11.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
            label12.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
            label13.Text = dataGridView1.Rows[0].Cells[9].Value.ToString();
            label15.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();
            label16.Text = dataGridView1.Rows[0].Cells[7].Value.ToString();
        }

        private static Random random = new Random();
        
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void updateseat()
        {   
            var filterDefinition = Builders<Buses>.Filter;
            var filter = filterDefinition.Eq(a => a.unique, uniqq);
            var search = buscollection.Find(filter).ToList();
            dataGridView2.DataSource = search;
          
           
            Int32 updatedseat = Convert.ToInt32(dataGridView1.Rows[0].Cells[9].Value.ToString());
            updatedseat = updatedseat - 1;
            var filterdefinition = Builders<Buses>.Filter.Eq(a => a.unique, uniqq);
            var updatedefinition = Builders<Buses>.Update.
                Set(a => a.AvailSeats, availseat-1);

            buscollection.UpdateOne(filterdefinition, updatedefinition);
  
        }
    }
}
