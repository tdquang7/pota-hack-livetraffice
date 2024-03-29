﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Entity;

namespace GenerateDataForTesting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Help in generating data for testing based on time
        private void button1_Click(object sender, EventArgs e)
        {            
            //double[] gpsLocations = new double[] { 10.859459, 106.790097, 
            //    10.860249, 106.791475, 
            //    10.860186,106.791502,
            //    10.859364,106.789946,
            //    10.859301,106.79007,
            //    10.85947,106.790316};

            //string connectionString = "workstation id=LiveTraffic.mssql.somee.com;packet size=4096;user id=hatu;pwd=iloveyou;data source=LiveTraffic.mssql.somee.com;persist security info=False;initial catalog=LiveTraffic";
            //SqlConnection connection = new SqlConnection(connectionString);
            //connection.Open();

            //// Clear all previous data
            //string sql = "delete from TrafficReport";
            //SqlCommand cmd = new SqlCommand(sql, connection);
            //cmd.ExecuteNonQuery();

            //// Insert new data
            //int count = gpsLocations.Length / 2; // Number of gps location pair of latitude and longitude
            //string username = "Tester1";
            //string status = "busy";
            //string country = "Vietnam";
            //string city = "Thành Phố Hồ Chí Minh";
            //string district = "";
            ////string street = "XA LỘ Hà Nội";
            //string street = "ĐƯỜNG D1";

            //for (int i = 0; i < count; i++)
            //{
            //    double latitude = gpsLocations[i * 2];
            //    double longitude = gpsLocations[i * 2 + 1];

            //    TrafficReport report = new TrafficReport();
            //    report.UpdateStreetStatus(username, country, city, district, street, latitude, longitude, "busy");
            //}

            //connection.Close();

            ServiceReference1.MobileServiceClient client = new ServiceReference1.MobileServiceClient();
            client.GenerateData();

            MessageBox.Show("Data generated");
        }

        private void btnGetTrafficStatus_Click(object sender, EventArgs e)
        {
            TrafficReport report = new TrafficReport();
            double latitude = 0;
            double longitude = 0;

            List<string> list = report.GetStreetStatus("", "", "", "ĐƯỜNG D1", latitude, longitude, "busy");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ServiceReference1.MobileServiceClient client = new ServiceReference1.MobileServiceClient();
            string[] list = client.GetNearbyTrafficJam(10.8552904129028, 106.788439750671, "Thành Phố Hồ Chí Minh", "Quận 9", "ĐƯỜNG D1");

            //TrafficReport report = new TrafficReport();
            //List<string> list = report.GetNearbyTrafficJam(10.8552904129028, 106.788439750671, "Thành Phố Hồ Chí Minh", "Quận 9", "ĐƯỜNG D1");
        }
    }
}
