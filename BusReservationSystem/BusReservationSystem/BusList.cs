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
    public partial class BusList : Form
    {
        public Int32 buttonrow;
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("BusReservationSystem");
        static IMongoCollection<Buses> buscollection = db.GetCollection<Buses>("buses");

        public string Origin { get; set; }

        public string Destination { get; set; }

        public string DepartureDate { get; set; }


        public BusList()
        {
            InitializeComponent();
        }

        public void Search()
        {
            
            var filterDefinition = Builders<Buses>.Filter;
            var filter = filterDefinition.Eq(a => a.Origin,Origin) & filterDefinition.Eq(a => a.Destination, Destination) & filterDefinition.Eq(a => a.DepartureDate, DepartureDate);
            var search = buscollection.Find(filter).ToList();
            dataGridView1.DataSource = search;
            bunifuDataGridView1.DataSource = search;

        }

        public void Search2()
        {
               
            var filterDefinition = Builders<Buses>.Filter;
            var filter = filterDefinition.Eq(a => a.Origin, Origin) & filterDefinition.Eq(a => a.Destination, Destination) & filterDefinition.Eq(a => a.DepartureDate, DepartureDate);
            var search = buscollection.Find(filter).ToList();
            dataGridView1.DataSource = search;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Origin = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        }

        private void BusList_Load(object sender, EventArgs e)
        {
            Search();
        }


        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 
            var grid = (DataGridView)sender;

                if (e.RowIndex < 0)
                {
                //They clicked the header column, do nothing
                    MessageBox.Show("Not!!");
                    return;
                }

                if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
                {
                    buttonrow = e.RowIndex;
                    ButtonTrigger();
                }


        }

        public void ButtonTrigger()
        {
            var filterDefinition = Builders<Buses>.Filter;
            var filter = filterDefinition.Eq(a => a.Origin, Origin) & filterDefinition.Eq(a => a.Destination, Destination) & filterDefinition.Eq(a => a.DepartureDate, DepartureDate);
            var search = buscollection.Find(filter).ToList();
            dataGridView1.DataSource = search;
            bunifuDataGridView1.DataSource = search;

            string uniqid = dataGridView1.Rows[buttonrow].Cells[2].Value.ToString();
            Int32 seats = Convert.ToInt32(dataGridView1.Rows[buttonrow].Cells[9].Value.ToString());
            string org = dataGridView1.Rows[buttonrow].Cells[3].Value.ToString();
            string dest = dataGridView1.Rows[buttonrow].Cells[4].Value.ToString();
            string depdate = dataGridView1.Rows[buttonrow].Cells[7].Value.ToString();
            string id = dataGridView1.Rows[buttonrow].Cells[1].Value.ToString();
          

            BookingPage p = new BookingPage();
            p.uniqq = uniqid;
            p.availseat = seats;
            p.BusId = id;
            p.Show();
            this.Hide();


        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Origin = txtOrigin.Text;
            Destination = txtDestination.Text;
            DepartureDate = dateTimePicker1.Value.ToShortDateString();

            Search2();
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

    }
}
