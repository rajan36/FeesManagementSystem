using SQLite.Net.Attributes;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;
using Windows.Data.Json;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.ApplicationModel.Email;
using System.Xml;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;

using Fee_Management_System.Mail;
using System.Diagnostics;

namespace Fee_Management_System
{
    public sealed partial class MainPage : Page
    {
        Student existingconact;
        ToastTemplateType toastTemplate = ToastTemplateType.ToastText02;
        bool databaseChanged = false;

        public MainPage()
        {
            this.InitializeComponent();
        }

        public class Student
        {
            [SQLite.Net.Attributes.PrimaryKey, SQLite.Net.Attributes.AutoIncrement]
            public int Id
            {
                get;
                set;
            }
            public string Name
            {
                get;
                set;
            }
            public string RollNo
            {
                get;
                set;
            }
            public string Mobile
            {
                get;
                set;
            }
            public string Email
            {
                get;
                set;
            }
            public int Semester
            {
                get;
                set;
            }
            public string Year
            {
                get;
                set;
            }
            public string Branch
            {
                get;
                set;
            }
            public string Programme
            {
                get;
                set;
            }
            public string Backlogs
            {
                get;
                set;
            }
            public string MessFee
            {
                get;
                set;
            }
            public string SemesterFee
            {
                get;
                set;
            }
            public string Dues
            {
                get;
                set;
            }
            public string Accomodation
            {
                get;
                set;
            }

            public Student()
            { }

            public Student(
                string name, 
                string rollno, 
                string mobile, 
                string email, 
                int semester, 
                string year,
                string branch,
                string programme,
                string backlogs,
                string messfee,
                string semesterfee,
                string dues,
                string accomodation)
            {
                Name = name;
                RollNo = rollno;
                Mobile = mobile;
                Email = email;
                Semester = semester;
                Year = year;
                Branch = branch;
                Programme = programme;
                Backlogs = backlogs;
                MessFee = messfee;
                SemesterFee = semesterfee;
                Dues = dues;
                Accomodation = accomodation;
            }
        }

        public class FeeRecord
        {
            [SQLite.Net.Attributes.PrimaryKey, SQLite.Net.Attributes.AutoIncrement]
            public int Id
            {
                get;
                set;
            }
            public string ApplicationNo
            {
                get;
                set;
            }
            public string Name
            {
                get;
                set;
            }
            public string FeeType
            {
                get;
                set;
            }
            public string Email
            {
                get;
                set;
            }
            public string Amount
            {
                get;
                set;
            }
            public string Gateway
            {
                get;
                set;
            }
            public string TransactionID
            {
                get;
                set;
            }
            public string PaymentID
            {
                get;
                set;
            }
            public string DateTime
            {
                get;
                set;
            }

            public FeeRecord()
            { }

            public FeeRecord(
                string applicationno,
                string name,
                string feetype,
                string email,
                string amount,
                string gateway,
                string transactionid,
                string paymentid,
                string datetime)
            {
                ApplicationNo = applicationno;
                Name = name;
                FeeType = feetype;
                Email = email;
                Amount = amount;
                Gateway = gateway;
                TransactionID = transactionid;
                PaymentID = paymentid;
                DateTime = datetime;
                
            }
        }

        public async void FormDatabase()
        {
            Insert(new Student("AAKASH HASIJA", "UG201310001",          "9999900000", "ug201310001@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("AAYUSH SHARDA", "UG201310002",          "9999900000", "ug201310002@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Day Scholar"));
            Insert(new Student("ABHAY KUMAR SINGH", "UG201310003",      "9999900000", "ug201310003@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("AMAN SINGH", "UG201310004",             "9999900000", "ug201310004@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("AMIT JAIN", "UG201310005",              "9999900000", "ug201310005@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("ANJALI MALAV", "UG201310006",           "9999900000", "ug201310006@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Day Scholar"));
            Insert(new Student("ARCHIT AGRAWAL", "UG201310007",         "9999900000", "ug201310007@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("ARNAV CHOPRA", "UG201310008",           "9999900000", "ug201310008@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("ARNAV JINDAL", "UG201310009",           "9999900000", "ug201310009@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("AVAN JAYENDRA RATHOD", "UG201310010",   "9999900000", "ug201310010@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("BHARTI", "UG2013100011",                "9999900000", "ug201310011@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Day Scholar"));
            Insert(new Student("BHARTI ARYA", "UG201310012",            "9999900000", "ug201310012@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("DISHANT GOYAL", "UG201310013",          "9999900000", "ug201310013@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("KARTIK SINGH", "UG201310015",           "9999900000", "ug201310015@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("KOMANDURI SAI RAGHAVA", "UG201310016",  "9999900000", "ug201310016@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Day Scholar"));
            Insert(new Student("KUSHAGRA SURANA", "UG201310017",        "9999900000", "ug201310017@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("MAKARAND GOMASHE", "UG201310019",       "9999900000", "ug201310019@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("MUTTINENI NAVYA", "UG201310020",        "9999900000", "ug201310020@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Day Scholar"));
            Insert(new Student("NIKHIL TAJI", "UG201310021",            "9999900000", "ug201310021@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("NITHIN V", "UG201310022",               "9999900000", "ug201310022@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("PIYUSH YADAV", "UG201310023",           "9999900000", "ug201310023@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("PRIYANK ARYA", "UG201310024",           "9999900000", "ug201310024@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("RAJKUMAR MEENA", "UG201310025",         "9999900000", "ug201310025@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("RAMKESH MEENA", "UG201310026",          "9999900000", "ug201310026@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("RAVI PRAKASH GUPTA", "UG201310027",     "9999900000", "ug201310027@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Day Scholar"));
            Insert(new Student("RAVINDRA KUMAR SAINI", "UG201310028",   "9999900000", "ug201310028@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("RITEEK SRIVASTAV", "UG201310029",       "9999900000", "ug201310029@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("SHIV BHAGWAN", "UG201310030",           "9999900000", "ug201310030@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("SHIV KUMAR SEN", "UG201310031",         "9999900000", "ug201310031@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("SHIV MOHAN", "UG201310032",             "9999900000", "ug201310032@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("SHUBHAM SAXENA", "UG201310033",         "9999900000", "ug201310033@iitj.ac.in", 6, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("SOURAV KHOSO", "UG201310035",           "9999900000", "ug201310035@iitj.ac.in", 1, "I", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("SURESH GEHLOT", "UG201310036",          "9999900000", "ug201310036@iitj.ac.in", 2, "I", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("TAPAN BHATNAGAR", "UG201310037",        "9999900000", "ug201310037@iitj.ac.in", 3, "II", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("UPENDRA SINGH CHAUHAN", "UG201310038",  "9999900000", "ug201310038@iitj.ac.in", 4, "II", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Day Scholar"));
            Insert(new Student("VAGHELA RAJAN", "UG201310039",          "9999900000", "ug201310039@iitj.ac.in", 5, "III", "CSE", "B.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("VAIBHAV PALIWAL", "UG201310040",        "9999900000", "ug201310040@iitj.ac.in", 2, "II", "CSE", "M.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Hosteler"));
            Insert(new Student("KSHITIJ MINOCHA", "UG201310043",        "9999900000", "ug201311021@iitj.ac.in", 1, "I", "CSE", "M.Tech", "None", "Unpaid", "Unpaid", "Cleared", "Day Scholar"));

            MessageDialog message = new MessageDialog("Sample Student Database created successfully!");
            await message.ShowAsync();
        }

        public static void CreateDatabase()
        {
            var sqlpath = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "FeeRecorddb.sqlite");
            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath))
            {
                conn.CreateTable<FeeRecord>();
            }
        }

        public void Insert(Student objContact)
        {
            var sqlpath = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Studentdb.sqlite");
            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath))
            {
                conn.RunInTransaction(() =>
                {
                    conn.Insert(objContact);
                });
            }
        }

        public void InsertFR(FeeRecord objContact)
        {
            var sqlpath = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "FeeRecorddb.sqlite");
            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath))
            {
                conn.RunInTransaction(() =>
                {
                    conn.Insert(objContact);
                });
            }
        }

        public Student ReadContact(int contactid)
        {
            var sqlpath = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Studentdb.sqlite");
            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath))
            {
                var existingconact = conn.Query<Student>("select * from Students where Id =" + contactid).FirstOrDefault();
                return existingconact;
            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            string name = " Kshitij";
            UpdateDetails(name);
        }

        public ObservableCollection<Student> ReadAllStudents()
        {
            var sqlpath = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Studentdb.sqlite");
            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath))
            {
                List<Student> myCollection = conn.Table<Student>().ToList<Student>();
                ObservableCollection<Student> StudentsList = new ObservableCollection<Student>(myCollection);
                return StudentsList;
            }
        }

        public ObservableCollection<FeeRecord> ReadStudentFeeRecords(string applicationno)
        {
            var sqlpath = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "FeeRecorddb.sqlite");
            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath))
            {
                List<FeeRecord> myCollection = conn.Table<FeeRecord>().ToList<FeeRecord>();

                for(int i=0; i<myCollection.Count; i++)
                {
                    if (myCollection[i].ApplicationNo == applicationno)
                        continue;
                    else
                    {
                        myCollection.RemoveAt(i);
                        i--;
                    }
                }

                ObservableCollection<FeeRecord> RecordList = new ObservableCollection<FeeRecord>(myCollection);
                return RecordList;
            }
        }

        public ObservableCollection<FeeRecord> ReadAllFeeRecords()
        {
            var sqlpath = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "FeeRecorddb.sqlite");
            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath))
            {
                List<FeeRecord> myCollection = conn.Table<FeeRecord>().ToList<FeeRecord>();
                ObservableCollection<FeeRecord> RecordList = new ObservableCollection<FeeRecord>(myCollection);
                return RecordList;
            }
        }

        public void UpdateDetails(string name)
        {
            var sqlpath = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Studentdb.sqlite");
            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath))
            {
                var existingconact = conn.Query<Student>("select * from Students where Name =" + name).FirstOrDefault();
                if (existingconact != null)
                {
                    existingconact.Name = name;
                    existingconact.Mobile = "962623233";
                    conn.RunInTransaction(() =>
                    {
                        conn.Update(existingconact);
                    });
                }
            }
        }

        public void DeleteAllContact()
        {
            var sqlpath = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Studentdb.sqlite");
            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath))
            {
                conn.DropTable<Student>();
                conn.CreateTable<Student>();
                conn.Dispose();
                conn.Close();
            }
        }

        public void DeleteContact(int Id)
        {
            var sqlpath = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Studentdb.sqlite");
            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath))
            {
                var existingconact = conn.Query<Student>("select * from Studentdb where Id =" + Id).FirstOrDefault();
                if (existingconact != null)
                {
                    conn.RunInTransaction(() =>
                    {
                        conn.Delete(existingconact);
                    });
                }
            }
        }

        private void FP_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            Username.IsEnabled = false;
            Password.IsEnabled = false;
            Role.IsEnabled = false;
            Login.IsEnabled = false;
            Loading.Visibility = Visibility.Visible;

            if(Username.Text=="Admin" && Password.Password=="Admin" && Role.SelectedIndex==2)
            {
                Status.Text = "Logging in...";
                Status.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                LoginGrid.Visibility = Visibility.Collapsed;
                AdminView.Visibility = Visibility.Visible;
            }
            else
            {
                Status.Visibility = Visibility.Visible;
                Username.IsEnabled = true;
                Password.IsEnabled = true;
                Role.IsEnabled = true;
                Login.IsEnabled = true;
                Loading.Visibility = Visibility.Collapsed;
            }

            if (Username.Text == "Staff" && Password.Password == "Staff" && Role.SelectedIndex == 1)
            {
                Status.Text = "Logging in...";
                Status.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                LoginGrid.Visibility = Visibility.Collapsed;
                StaffView.Visibility = Visibility.Visible;
            }
            else
            {
                Status.Visibility = Visibility.Visible;
                Username.IsEnabled = true;
                Password.IsEnabled = true;
                Role.IsEnabled = true;
                Login.IsEnabled = true;
                Loading.Visibility = Visibility.Collapsed;
            }

            var sqlpath = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Studentdb.sqlite");
            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath))
            {
                existingconact = conn.Query<Student>("select * from Student where RollNo = \"" + Username.Text + "\"").FirstOrDefault();
            }

            if (existingconact==null)
            {
                Status.Visibility = Visibility.Visible;
                Username.IsEnabled = true;
                Password.IsEnabled = true;
                Role.IsEnabled = true;
                Login.IsEnabled = true;
                Loading.Visibility = Visibility.Collapsed;
            }
            else
            {
                if(Username.Text!=Password.Password)
                {
                    Status.Visibility = Visibility.Visible;
                    Username.IsEnabled = true;
                    Password.IsEnabled = true;
                    Role.IsEnabled = true;
                    Login.IsEnabled = true;
                    Loading.Visibility = Visibility.Collapsed;
                }
                else
                {
                    if(Role.SelectedIndex!=0)
                    {
                        Status.Visibility = Visibility.Visible;
                        Username.IsEnabled = true;
                        Password.IsEnabled = true;
                        Role.IsEnabled = true;
                        Login.IsEnabled = true;
                        Loading.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        Status.Text = "Logging in...";
                        Status.Visibility = Visibility.Visible;
                        await Task.Delay(2000);
                        LoginGrid.Visibility = Visibility.Collapsed;
                        fillStudentDetails(existingconact);
                        StudentView.Visibility = Visibility.Visible;
                    }
                }
            }
        }

        private void fillStudentDetails(Student User)
        {
            SName.Text = User.Name;
            SContact.Text = User.Mobile;
            SRollNo.Text = User.RollNo;
            SEmail.Text = User.Email;
            SYear.Text = User.Year;
            SSemester.Text = User.Semester.ToString();
            SBranch.Text = User.Branch;
            SProgramme.Text = User.Programme;
            SBacklogs.Text = User.Backlogs;
            SSFee.Text = User.SemesterFee;
            SMFee.Text = User.MessFee;

            if(User.Accomodation=="Hosteler")
            {
                if (User.Programme == "B.Tech")
                    Amount.Text = BH.Text;
                else if (User.Programme == "M.Tech")
                    Amount.Text = MH.Text;
                else if (User.Programme == "P.hD")
                    Amount.Text = PH.Text;
                else
                    Amount.Text = MSH.Text;
            }
            else
            {
                if (User.Programme == "B.Tech")
                    Amount.Text = BH.Text;
                else if (User.Programme == "M.Tech")
                    Amount.Text = MH.Text;
                else if (User.Programme == "P.hD")
                    Amount.Text = PH.Text;
                else
                    Amount.Text = MSH.Text;
            }
        }

        private void logOut_Click(object sender, RoutedEventArgs e)
        {
            Username.Text = "";
            Password.Password = "";
            Username.IsEnabled = true;
            Password.IsEnabled = true;
            Role.IsEnabled = true;
            Login.IsEnabled = true;
            Status.Text = "Invalid Credentials!";
            Loading.Visibility = Visibility.Collapsed;
            Status.Visibility = Visibility.Collapsed;
            StudentView.Visibility = Visibility.Collapsed;
            LoginGrid.Visibility = Visibility.Visible;
        }

        private void FeeStructure_Click(object sender, RoutedEventArgs e)
        {
            StudentView.Visibility = Visibility.Collapsed;
            FeeStructureSV.Visibility = Visibility.Visible;
            Back.Visibility = Visibility.Visible;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FeeStructureSV.Visibility = Visibility.Collapsed;
            Back.Visibility = Visibility.Collapsed;
            StudentView.Visibility = Visibility.Visible;
        }

        private void FeeType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FeeType.SelectedIndex == 1)
            {
                Amount.Text = "INR 12,000";
            }
        }

        private async void Request_Click(object sender, RoutedEventArgs e)
        {
            EmailMessage emailMessage = new EmailMessage();
            emailMessage.To.Add(new EmailRecipient("ug201311021@iitj.ac.in"));
            string messageBody = "Re: Edit in Student Profile";
            emailMessage.Body = "Hello Sir, please make the following changes in my student profile: ";
            await EmailManager.ShowComposeNewEmailAsync(emailMessage);
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            HeaderGrid.Visibility = Visibility.Collapsed;
            StudentView.Visibility = Visibility.Collapsed;
            GatewayGrid.Visibility = Visibility.Visible;
            AmountToPay.Text = "Pay " + Amount.Text + " to Merchant.com for Order ID XYZ";
        }

        private void GatewayBack_Click(object sender, RoutedEventArgs e)
        {
            GatewayGrid.Visibility = Visibility.Collapsed;
            StudentView.Visibility = Visibility.Visible;
            HeaderGrid.Visibility = Visibility.Visible;
            CardNo.IsEnabled = true;
            NAME.IsEnabled = true;
            CVV.IsEnabled = true;
            MM.IsEnabled = true;
            YY.IsEnabled = true;
            Proceed.IsEnabled = true;
            ProceedLoader.Visibility = Visibility.Collapsed;
            NAME.Text = "";
        }

        private async void Proceed_Click(object sender, RoutedEventArgs e)
        {
            CardNo.IsEnabled = false;
            NAME.IsEnabled = false;
            CVV.IsEnabled = false;
            MM.IsEnabled = false;
            YY.IsEnabled = false;
            Proceed.IsEnabled = false;
            ProceedLoader.Visibility = Visibility.Visible;
            await Task.Delay(2000);

            ReceiptGrid.Visibility = Visibility.Visible;
            HeaderGrid.Visibility = Visibility.Visible;
            GatewayGrid.Visibility = Visibility.Collapsed;
            CardNo.IsEnabled = true;
            NAME.IsEnabled = true;
            CVV.IsEnabled = true;
            MM.IsEnabled = true;
            YY.IsEnabled = true;
            Proceed.IsEnabled = true;
            ProceedLoader.Visibility = Visibility.Collapsed;
            NAME.Text = "";

            FeeRecord newRecord = new FeeRecord();

            RApplicationNo.Text = existingconact.RollNo;
            newRecord.ApplicationNo = existingconact.RollNo;
            RName.Text = existingconact.Name;
            newRecord.Name = existingconact.Name;

            if (FeeType.SelectedIndex == 0)
            {
                RFeeFor.Text = "Semester Fee";
                newRecord.FeeType = "Semester Fee";
            }
            else
            {
                RFeeFor.Text = "Mess Fee";
                newRecord.FeeType = "Mess Fee";
            }

            RE_Mail.Text = existingconact.Email;
            newRecord.Email = existingconact.Email;
            RAmount.Text = Amount.Text;
            newRecord.Amount = Amount.Text;
            RGateway.Text = "Merchant.com";
            newRecord.Gateway = "Merchant.com";
            RResponse.Text = "Success";
            RTransactionID.Text = "XXXXXXXXXX";
            newRecord.TransactionID = "XXXXXXXXXX";
            RPaymentID.Text = "YYYYYYYYYYY";
            newRecord.PaymentID = "YYYYYYYYYY";
            RError.Text = "None";
            RTime.Text = DateTime.Now.ToString();
            newRecord.DateTime = DateTime.Now.ToString();

            toast();
            sendConfirmationMail();
            InsertFR(newRecord);
        }

        private void RLogOut_Click(object sender, RoutedEventArgs e)
        {
            ReceiptGrid.Visibility = Visibility.Collapsed;
            LoginGrid.Visibility = Visibility.Visible;
            Username.Text = "";
            Password.Password = "";
            Username.IsEnabled = true;
            Password.IsEnabled = true;
            Role.IsEnabled = true;
            Login.IsEnabled = true;
            Status.Text = "Invalid Credentials!";
            Loading.Visibility = Visibility.Collapsed;
            Status.Visibility = Visibility.Collapsed;
        }

        void toast()
        {
            Windows.Data.Xml.Dom.XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

            Windows.Data.Xml.Dom.XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");

            toastTextElements[0].AppendChild(toastXml.CreateTextNode("Fee Payment Confirmation"));
            toastTextElements[1].AppendChild(toastXml.CreateTextNode("Application No: " + existingconact.RollNo));
            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((Windows.Data.Xml.Dom.XmlElement)toastNode).SetAttribute("duration", "long");
            ToastNotification toast = new ToastNotification(toastXml);
            toast.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(3600);

            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        void editToast()
        {
            Windows.Data.Xml.Dom.XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

            Windows.Data.Xml.Dom.XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");

            toastTextElements[0].AppendChild(toastXml.CreateTextNode("Master Database Edit"));
            toastTextElements[1].AppendChild(toastXml.CreateTextNode("Date|Time of Edit: " + DateTime.Now.ToString()));
            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((Windows.Data.Xml.Dom.XmlElement)toastNode).SetAttribute("duration", "long");
            ToastNotification toast = new ToastNotification(toastXml);
            toast.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(3600);

            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        async void sendConfirmationMail()
        {
            try
            {
                string smtpServer;
                int port;
                Boolean ssl;
                smtpServer = "smtp.gmail.com";
                port = 465;
                ssl = true;
                string receipt = "\t\t\tPayment Receipt\nApplication No.:    \t\t" + existingconact.RollNo + "\nName:               \t\t" + existingconact.Name + "\nAmount:             \t\t" + Amount.Text + "\nTransaction ID:     \t\tXXXXXXXXXX\nPayment ID:         \t\tYYYYYYYYYY\nError:              \t\tNone\nDate|Time of Payment:\t\t" + DateTime.Now.ToString();

                SmtpClient client = new SmtpClient(smtpServer, port, "kshitij.minocha@gmail.com", "XXXXXXXXXXX", ssl);

                SmtpMessage message = new SmtpMessage("kshitij.minocha@gmail.com", existingconact.Email, null, "Fee Payment Confirmation Receipt", receipt);

                await client.SendMail(message);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        private void PHistory_Click(object sender, RoutedEventArgs e)
        {
            StudentView.Visibility = Visibility.Collapsed;
            HistoryGrid.Visibility = Visibility.Visible;
            ObservableCollection<FeeRecord> list = ReadStudentFeeRecords(existingconact.RollNo);
            Records.ItemsSource = list.ToList();
        }

        private void HistoryBack_Click(object sender, RoutedEventArgs e)
        {
            StudentView.Visibility = Visibility.Visible;
            HistoryGrid.Visibility = Visibility.Collapsed;
        }

        private void AdminSD_Click(object sender, RoutedEventArgs e)
        {
            AdminView.Visibility = Visibility.Collapsed;
            SDGrid.Visibility = Visibility.Visible;

            if (databaseChanged == false)
            {
                var list = ReadAllStudents();
                SDRecords.ItemsSource = list.ToList();
                databaseChanged = true;
            }
            else
            {

            }
        }

        private void SDRecordsBack_Click(object sender, RoutedEventArgs e)
        {
            SDGrid.Visibility = Visibility.Collapsed;
            AdminView.Visibility = Visibility.Visible;
            Edit.IsEnabled = true;
            SDRecords.IsEnabled = false;
        }

        private void AdminLogOut_Click(object sender, RoutedEventArgs e)
        {
            AdminView.Visibility = Visibility.Collapsed;
            Username.Text = "";
            Password.Password = "";
            Username.IsEnabled = true;
            Password.IsEnabled = true;
            Role.IsEnabled = true;
            Login.IsEnabled = true;
            Status.Text = "Invalid Credentials!";
            Loading.Visibility = Visibility.Collapsed;
            Status.Visibility = Visibility.Collapsed;
            LoginGrid.Visibility = Visibility.Visible;
        }

        private void AdminFeeStructure_Click(object sender, RoutedEventArgs e)
        {
            AdminView.Visibility = Visibility.Collapsed;
            FeeStructureAdmin.Visibility = Visibility.Visible;
            AdminFeeStructureBack.Visibility = Visibility.Visible;
        }

        private void AdminFeeStructureBack_Click(object sender, RoutedEventArgs e)
        {
            AdminFeeStructureBack.Visibility = Visibility.Collapsed;
            FeeStructureAdmin.Visibility = Visibility.Collapsed;
            AdminView.Visibility = Visibility.Visible;
        }

        private void StaffLogOut_Click(object sender, RoutedEventArgs e)
        {
            StaffView.Visibility = Visibility.Collapsed;
            Username.Text = "";
            Password.Password = "";
            Username.IsEnabled = true;
            Password.IsEnabled = true;
            Role.IsEnabled = true;
            Login.IsEnabled = true;
            Status.Text = "Invalid Credentials!";
            Loading.Visibility = Visibility.Collapsed;
            Status.Visibility = Visibility.Collapsed;
            LoginGrid.Visibility = Visibility.Visible;
        }

        private void AdminFeeSummary_Click(object sender, RoutedEventArgs e)
        {
            AdminView.Visibility = Visibility.Collapsed;
            FeeSummaryGrid.Visibility = Visibility.Visible;

            var list = ReadAllFeeRecords();
            FeeRecords.ItemsSource = list.ToList();
        }

        private void SummaryBack_Click(object sender, RoutedEventArgs e)
        {
            AdminView.Visibility = Visibility.Visible;
            FeeSummaryGrid.Visibility = Visibility.Collapsed;
        }

        private void StaffSummary_Click(object sender, RoutedEventArgs e)
        {
            StaffView.Visibility = Visibility.Collapsed;
            StaffFeeSummaryGrid.Visibility = Visibility.Visible;

            var list = ReadAllFeeRecords();
            StaffFeeRecords.ItemsSource = list.ToList();
        }

        private void StaffSummaryBack_Click(object sender, RoutedEventArgs e)
        {
            StaffView.Visibility = Visibility.Visible;
            StaffFeeSummaryGrid.Visibility = Visibility.Collapsed;
        }

        private void StaffFeeStructure_Click(object sender, RoutedEventArgs e)
        {
            StaffView.Visibility = Visibility.Collapsed;
            StaffFeeStructureSV.Visibility = Visibility.Visible;
            StaffBack.Visibility = Visibility.Visible;
        }

        private void StaffBack_Click(object sender, RoutedEventArgs e)
        {
            StaffBack.Visibility = Visibility.Collapsed;
            StaffFeeStructureSV.Visibility = Visibility.Collapsed;
            StaffView.Visibility = Visibility.Visible;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            SDRecords.IsEnabled = true;
            Edit.IsEnabled = false;
            editToast();
        }

        private void btnCreateSD_Click(object sender, RoutedEventArgs e)
        {
            if(ApplicationData.Current.LocalSettings.Values.ContainsKey("Database")==false)
            {
                var sqlpath = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Studentdb.sqlite");
                using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath))
                {
                    conn.CreateTable<Student>();
                }

                var sqlpath2 = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "FeeRecorddb.sqlite");
                using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath2))
                {
                    conn.CreateTable<FeeRecord>();
                }

                FormDatabase();

                ApplicationData.Current.LocalSettings.Values["Database"] = true;
                btnCreateSD.IsEnabled = false;
            }
            else
            {
                btnCreateSD.IsEnabled = false;
            }
        }
    }
}
