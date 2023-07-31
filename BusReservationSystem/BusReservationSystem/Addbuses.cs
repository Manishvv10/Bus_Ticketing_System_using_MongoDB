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
    public partial class Addbuses : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("BusReservationSystem");
        static IMongoCollection<Buses> buscollection = db.GetCollection<Buses>("buses");

        public Addbuses()
        {
            InitializeComponent();
            dateTimePicker1.MinDate = System.DateTime.Now;
            dateTimePicker1.Value = System.DateTime.Now;
            dateTimePicker4.MinDate = System.DateTime.Now;
            dateTimePicker4.Value = System.DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Add = new Buses
            {
                unique = txtUnique.Text,
                Origin = txtOrigin.Text,
                Destination = txtDestination.Text,
                DepartureDate = dateTimePicker1.Value.ToShortDateString(),
                DepartureTime = dateTimePicker2.Value.ToShortTimeString(),
                ArrDate = dateTimePicker4.Value.ToShortDateString(),
                ArrTime = dateTimePicker3.Value.ToShortTimeString(),
                AvailSeats = Int32.Parse(txtAvailSeats.Text),
                fare = Int32.Parse(txtFare.Text),               
            };

            buscollection.InsertOne(Add);
            MessageBox.Show("Bus Added!!!");

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            var filterdefinition = Builders<Buses>.Filter.Eq(a => a.unique, txtUnique.Text);
            var updatedefinition = Builders<Buses>.Update.
                Set(a => a.Origin, txtOrigin.Text).Set(a => a.Destination, txtDestination.Text).Set(a => a.AvailSeats, Int32.Parse(txtAvailSeats.Text)).
                Set(a => a.fare, Int32.Parse(txtFare.Text)).Set(a => a.DepartureDate, dateTimePicker1.Value.ToShortDateString()).
                Set(a => a.DepartureTime, dateTimePicker2.Value.ToShortTimeString()).Set(a => a.ArrDate, dateTimePicker4.Value.ToShortDateString()).
                Set(a => a.ArrTime, dateTimePicker3.Value.ToShortTimeString());

            buscollection.UpdateOne(filterdefinition, updatedefinition);
            MessageBox.Show("Details Updated!!!");
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            var filterdefinition = Builders<Buses>.Filter.Eq(a => a.unique, txtUnique.Text);
            buscollection.DeleteOne(filterdefinition);

            MessageBox.Show("Bus Deleted !!!");

        }
    }
}
