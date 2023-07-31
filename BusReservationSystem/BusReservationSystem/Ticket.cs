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
    public partial class Ticket : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("BusReservationSystem");
        static IMongoCollection<Buses> buscollection = db.GetCollection<Buses>("buses");
        static IMongoCollection<Reservations> reservationcollection = db.GetCollection<Reservations>("reservations");
        
        
        public string pnrr { get; set; }

        public string uniquee { get; set; }

        public Ticket()
        {
            InitializeComponent();
            
        }

        private void Ticket_Load(object sender, EventArgs e)
        {
            loadTicket();
        }

        public void loadTicket()
        {
            var filterDefinition = Builders<Reservations>.Filter;
            var filter = filterDefinition.Eq(a => a.pnr, pnrr);
            var search = reservationcollection.Find(filter).ToList();
            dataGridView1.DataSource = search;

            ticketno.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            pnrno.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            pnr2.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            pname.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
            page.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
            pgen.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();
            pseatno.Text = dataGridView1.Rows[0].Cells[7].Value.ToString();
            booktime.Text = dataGridView1.Rows[0].Cells[11].Value.ToString();







            string c = dataGridView1.Rows[0].Cells[10].Value.ToString();
            MessageBox.Show(c);
            var filterDef = Builders<Buses>.Filter;
            var filtera = filterDef.Eq(b => b.unique,c);
            var searchs = buscollection.Find(filtera).ToList();
            dataGridView2.DataSource = searchs;


            org.Text = dataGridView2.Rows[0].Cells[2].Value.ToString();
            des.Text = dataGridView2.Rows[0].Cells[3].Value.ToString();
            dorigin.Text = dataGridView2.Rows[0].Cells[2].Value.ToString();
            ddest.Text = dataGridView2.Rows[0].Cells[3].Value.ToString();
            bpoint.Text = dataGridView2.Rows[0].Cells[2].Value.ToString();
            dpoint.Text = dataGridView2.Rows[0].Cells[3].Value.ToString();
            ddate2.Text = dataGridView2.Rows[0].Cells[4].Value.ToString();
            ddate.Text = dataGridView2.Rows[0].Cells[4].Value.ToString();
            dtime.Text = dataGridView2.Rows[0].Cells[5].Value.ToString();
            adate.Text = dataGridView2.Rows[0].Cells[6].Value.ToString();
            atime.Text = dataGridView2.Rows[0].Cells[7].Value.ToString();
            fare.Text = dataGridView2.Rows[0].Cells[9].Value.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dtime_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel8_Click(object sender, EventArgs e)
        {

        }
    }
}
