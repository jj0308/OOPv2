using DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA
{
    public partial class RankMatchFrom : UserControl
    {
        //ovo da mozemo ispisati u pdfu
        public string LocationText
        {
            get { return lblLocation.Text; }
           
        }

        public string HomeTeamText
        {
            get { return lblHomeTeam.Text; }
            
        }

        public string AwayTeamText
        {
            get { return lblAwayTeam.Text; }
        }

        public string AttendanceText
        {
            get { return lblAttendance.Text; }
        }

        public RankMatchFrom()
        {
            InitializeComponent();
        }

        public RankMatchFrom(SoccerMatch soccerMatch)
        {
            InitializeComponent();
            lblLocation.Text = soccerMatch.Venue;
            lblHomeTeam.Text = soccerMatch.HomeTeam.Country;
            lblAwayTeam.Text = soccerMatch.AwayTeam.Country;
            lblAttendance.Text = soccerMatch.Attendance;
        }
    }
}
