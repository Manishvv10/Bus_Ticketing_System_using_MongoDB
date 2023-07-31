using MongoDB.Driver;
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
    public partial class LoginPage : Form
    {

        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("BusReservationSystem");
        static IMongoCollection<usercredentials> usercollection = db.GetCollection<usercredentials>("user_credentials");
        static IMongoCollection<curr_user> useridcollection = db.GetCollection<curr_user>("current_user");
        static IMongoCollection<admincredentials> admincollection = db.GetCollection<admincredentials>("admin_credentials");

        public LoginPage()
        {
            InitializeComponent();
            bunifuGradientPanel1.Hide();
            bunifuGradientPanel3.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Search();
        }

        public void Search()
        {  
            var filterDefinition = Builders<usercredentials>.Filter;
            var filter = filterDefinition.Eq(a => a.username, txtUsername.Text) & filterDefinition.Eq(a => a.password, txtPassword.Text);
            var search = usercollection.Find(filter).ToList();
            var result = usercollection.Find(filter).ToString();
            dataGridView1.DataSource = search;

#pragma warning disable CS0252 // Possible unintended reference comparison; left hand side needs cast
            try
            {
                string fname = dataGridView1.Rows[0].Cells[1].Value.ToString();
                string usernamecompare = dataGridView1.Rows[0].Cells[2].Value.ToString();
                string passwordcompare = dataGridView1.Rows[0].Cells[3].Value.ToString();


                if (usernamecompare == txtUsername.Text && passwordcompare == txtPassword.Text)
                {
                    var insert = new curr_user
                    {
                        Fname = fname,
                        userid = usernamecompare
                    };

                    useridcollection.InsertOne(insert);

                    MainPage form = new MainPage();
                    form.Show();
                    this.Hide();
                }
#pragma warning restore CS0252 // Possible unintended reference comparison; left hand side needs cast
                
            }
            catch(ArgumentOutOfRangeException)
            {
                 MessageBox.Show("Incorrect Username And Password!!..."); 
            }

            //dataGridView1.DataSource = search;
            
        }


        public void AdminSearch()
        {
            var filterDefinition = Builders<admincredentials>.Filter;
            var filter = filterDefinition.Eq(a => a.adminusername, txtAdminUsername.Text) & filterDefinition.Eq(a => a.adminpassword, txtAdminPass.Text);
            var search = admincollection.Find(filter).ToList();
            dataGridView2.DataSource = search;

#pragma warning disable CS0252 // Possible unintended reference comparison; left hand side needs cast
            try
            {
                string adminusernamecompare = dataGridView2.Rows[0].Cells[2].Value.ToString();
                string adminpasswordcompare = dataGridView2.Rows[0].Cells[3].Value.ToString();


                if (adminusernamecompare == txtAdminUsername.Text && adminpasswordcompare == txtAdminPass.Text)
                {
                    AdminPage a = new AdminPage();
                    a.Show();
                    this.Hide();
                }
#pragma warning restore CS0252 // Possible unintended reference comparison; left hand side needs cast

            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Incorrect Username And Password!!...");
            }

            //dataGridView1.DataSource = search;

        }


        private void button2_Click(object sender, EventArgs e)
        {
            bunifuGradientPanel2.Hide();
            bunifuGradientPanel1.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var login = new usercredentials
            {
                fname = txtFName.Text,
                username = txtRegisUsername.Text,
                password = txtRegisPassword.Text
            };

            usercollection.InsertOne(login);
            MessageBox.Show("User Successfully Registered!!!");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            bunifuGradientPanel1.Hide();
            bunifuGradientPanel2.Show();

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {
            bunifuGradientPanel3.Show();
            bunifuGradientPanel1.Hide();
            bunifuGradientPanel2.Hide();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            AdminSearch();
        }
    }
}
