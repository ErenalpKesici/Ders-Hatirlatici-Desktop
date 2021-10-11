using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Time
{
    public partial class Check : Form
    {
        public static List<MeList> listNotFound;
        private String[] people = new String[64];
        string[] individualDate = new string[512];
        static List<MeList> listToCheck = new List<MeList>();
        public static string start, end;
        private string selectedPerson;
        public Check()
        {
            InitializeComponent();
        }

        public struct MeList
        {
            public DateTime date { get; set; }
            public string sinif { get; set; }
            public MeList(DateTime date, int hour, string sinif) { this.date = date; this.sinif = sinif; }
        }

        private void Check_Load(object sender, EventArgs e)
        {
            bool exists = false;
            int k = 0;
            for (int i = 0; Form1.s[i] != null; i++)
            {
                for (int j = 0; Form1.s[i].person[j] != null; j++)
                {
                    if (Form1.s[i].person[j].Length < 3) continue;
                    for (int t = 0; people[t] != null; t++)
                    {
                        if (Form1.s[i].person[j] == people[t])
                        {
                            exists = true;
                            break;
                        }
                    }
                    if (!exists)
                        people[k++] = Form1.s[i].person[j];
                    else
                        exists = false;
                }
            }
            for (int i = 0; people[i] != null; i++)
                ddPerson.Items.Add(people[i]);
            ddPerson.SelectedIndex = 0;
        }

        private void ddPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPerson = ddPerson.SelectedItem.ToString();
        }

        private void dtStart_ValueChanged(object sender, EventArgs e)
        {
            start = dtStart.Value.ToShortDateString();
        }

        private void dtEnd_ValueChanged(object sender, EventArgs e)
        {
            end = dtEnd.Value.ToShortDateString();
        }
        private List<string> GetDirects()
        {
            string[] directories = Directory.GetDirectories(Form1.location);
            List<string> directs = new List<string>();
            foreach (string directory in directories)
            {
                string[] tmpDir = directory.Split('\\');
                if (tmpDir[tmpDir.Length - 1][0] != '2') continue;
                directs.Add(directory);
            }
            return directs;
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            List<string> directs = GetDirects();
            if (chkInnerDelete.Checked)
            {
                if (Form1.location == "")
                    Form1.findLocation();
                int delCount = 0;
                long totalSize = 0, deletedSize = 0;
                foreach (string directory in directs)
                {
                    string[] files = Directory.GetFiles(directory);
                    foreach (string file in files)
                    {
                        FileInfo f = new FileInfo(file);
                        totalSize += f.Length;
                        string extension = "";
                        for (int z = file.Length - 1; file[z] != '.'; z--)
                        {
                            extension += file[z];
                        }
                        if (Form1.reverse(extension) != textBox1.Text)
                        {
                            File.Delete(file);
                            delCount++;
                        }
                    }
                }
                if (delCount > 0)
                {
                    foreach (string directory in directs)
                    {
                        string[] files = Directory.GetFiles(directory);
                        foreach (string file in files)
                        {
                            FileInfo f = new FileInfo(file);
                            deletedSize += f.Length;
                        }
                    }
                    MessageBox.Show(delCount + " dosya silindi. " + " Azaltilan Boyut: " + ((totalSize - deletedSize) / 1000000).ToString() + "MB");
                }
                else
                    MessageBox.Show("Hicbir dosya silinmedi.");

            }
            if (chkDelete.Checked)
            {
                directs = GetDirects();
                if (Form1.location == "")
                    Form1.findLocation();
                string[] dirs = Directory.GetDirectories(Form1.location);
                int nDeleted = 0;
                long dirByte;
                foreach (string directory in directs)
                {
                    dirByte = 0;
                    string[] files = Directory.GetFiles(directory);
                    foreach (string file in files)
                    {
                        FileInfo f = new FileInfo(file);
                        dirByte += f.Length;
                    }
                    string[] t = Directory.GetDirectories(directory);
                    if (t.Length == 0 && dirByte / 1000000 <= Convert.ToDouble(txtDelete.Text))
                    {
                        Directory.Delete(directory, true);
                        nDeleted++;
                    }
                }
                if (nDeleted > 0)
                    MessageBox.Show(nDeleted + " klasor silindi.");
                else
                    MessageBox.Show("Hicbir klasor silinmedi.");
            }
            if (chkFix.Checked)
            {
                directs = GetDirects();
                if (Form1.location == "")
                    Form1.findLocation();
                foreach (string directory in directs)
                {
                    string[] dir = directory.Split('\\');
                    string dirName = dir[dir.Length - 1];
                    for (int i = 0; Form1.s[i] != null; i++)
                    {
                        string[] folder = dirName.Split(' ');
                        string[] date = folder[0].Split('-');
                        string[] time = folder[1].Split('.');
                        DateTime tmpDt = new DateTime(Convert.ToInt32(date[0]), Convert.ToInt32(date[1]), Convert.ToInt32(date[2]), Convert.ToInt32(time[0]), Convert.ToInt32(time[1]), 0);
                        if (tmpDt.Date.CompareTo(Form1.s[i].date[0].Date) == 0)
                        {
                            for(int j = 0; Form1.s[i].date[j] != DateTime.MinValue; j++)
                            {
                                if (Belongs(Form1.s[i].date[j], tmpDt)) {
                                    string src = directory;
                                    string dest = Form1.location + '\\' + Form1.s[i].classroom;
                                    Directory.CreateDirectory(dest);
                                    Directory.Move(src, dest + "\\" + Form1.s[i].topic[j] +" " + dirName) ;
                                    directs = GetDirects();
                                    break;
                                }
                            }
                        }
                    }
                }
                MessageBox.Show("Klasorler duzeltildi.");
            }
        }

        private void chkName_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private bool Belongs(DateTime d1, DateTime d2)
        {
            return d1.Date.CompareTo(d2.Date) == 0 && ((d1.Hour == d2.Hour && d2.Minute < 40) || ((d2.Hour - d1.Hour == -1 && d2.Minute > 40)));
        }
        private void btnNoMatch_Click(object sender, EventArgs e)
        {
            if (Form1.location == "")
                Form1.findLocation();
            List<string> directs = GetDirects();
            listToCheck = new List<MeList>();
            for (int i = 0; Form1.s[i] != null; i++)
                for(int j=0;Form1.s[i].date[j] != DateTime.MinValue; j++)
                    if (Form1.s[i].type[j] == "ÖE" && Form1.s[i].person[j].Equals(selectedPerson) && Form1.s[i].date[j].CompareTo(dtStart.Value.Date) > -1 && Form1.s[i].date[j].CompareTo(dtEnd.Value.Date) < 1)
                        listToCheck.Add(new MeList(Form1.s[i].date[j], Form1.s[i].date[j].Hour, Form1.s[i].classroom));
            listNotFound = new List<MeList>();
            bool found = false;
            foreach (MeList item in listToCheck)
            {
                for(int i = 0; i < directs.Count; i++)
                {
                    string[] actualName = directs[i].Split('\\');
                    string[] dateNTime = actualName[actualName.Length-1].Split(' ');
                    string[] date = dateNTime[0].Split('-');
                    string[] time = dateNTime[1].Split('.');
                    DateTime tmpDt = new DateTime(Convert.ToInt32(date[0]), Convert.ToInt32(date[1]), Convert.ToInt32(date[2]), Convert.ToInt32(time[0]), Convert.ToInt32(time[1]), 0);
                    if (Belongs(item.date, tmpDt)) 
                    {
                        found = true;
                        break;
                    }
                }
                if (!found) 
                    listNotFound.Add(item);
                else 
                    found = false;
            }
            if(listToCheck.Count > 0)
            {
                GridNotFound gnf = new GridNotFound();
                gnf.Show();
            }
        }
        //private void fillList()
        //{
        //    string[] inDate = new string[4];
        //    listToCheck = new List<MeList>();
        //    for (int i = 0; Form1.s[i] != null; i++)
        //    {
        //        inDate = Form1.s[i].date.Split(' ');
        //        inDate[1] = Form1.WhichMonth((Form1.Month)(Enum.Parse(typeof(Form1.Month), inDate[1])));
        //        if (Convert.ToInt32(inDate[1]) < Convert.ToInt32(dtpStart.Value.Month.ToString()) || (Convert.ToInt32(inDate[1]) == Convert.ToInt32(dtpStart.Value.Month) && Convert.ToInt32(inDate[2]) == Convert.ToInt32(dtpStart.Value.Year) && Convert.ToInt32(inDate[0]) < Convert.ToInt32(dtpStart.Value.Day)) || (Convert.ToInt32(inDate[1]) == Convert.ToInt32(dtpEnd.Value.Month) && Convert.ToInt32(inDate[2]) == Convert.ToInt32(dtpEnd.Value.Year) && Convert.ToInt32(inDate[0]) > Convert.ToInt32(dtpEnd.Value.Day)))
        //            continue;
        //        for (int j = 0; j < Form1.s[i].hours.Length; j++)
        //        {
        //            if (Form1.s[i].person[j] == comboBox1.SelectedItem.ToString())
        //                listToCheck.Add(new MeList(i, j, Form1.s[i].sinif));
        //        }
        //    }
        //}
        //private void button3_Click(object sender, EventArgs e)
        //{
        //    if (comboBox1.SelectedItem == null)
        //    {
        //        MessageBox.Show("Kisi secilmeli");
        //        return;
        //    }
        //    Form1.findLocation();
        //    start = dtpStart.Value.Day + "/"+ dtpStart.Value.Month +"/"+ dtpStart.Value.Year;
        //    end = dtpEnd.Value.Day + "/" + dtpEnd.Value.Month + "/" + dtpEnd.Value.Year;
        //    listNotFound = new List<MeList>();
        //    fillList();
        //    string[] fullFolders = Directory.GetDirectories(Form1.location);
        //    string[] folders = new string[fullFolders.Length];
        //    for (int i = 0, k = 0; i < fullFolders.Length; i++, k++)
        //    {
        //        for (int j = fullFolders[i].Length - 1; j >= 0; j--)
        //        {
        //            if (fullFolders[i][j] == '\\')
        //                break;
        //            folders[k] += fullFolders[i][j];
        //        }
        //        folders[k] = Form1.reverse(folders[k]);
        //    }
        //    string fullDate = "";
        //    bool inOver = false, checkedDone = false;
        //    foreach (MeList item in listToCheck)
        //    {
        //        for (int i = 0; i < folders.Length; i++, fullDate = "")
        //        {
        //            if (folders[i].Length < 5)
        //                continue;
        //            string tmp = "";
        //            for (int j = 0; j < folders[i].Length; j++)
        //            {
        //                if (folders[i][j] == ' ' || folders[i][j] == '-')
        //                {
        //                    if (tmp.Length > 3)
        //                    {
        //                        fullDate += tmp;
        //                        for (int inx = j; !Char.IsLetter(folders[i][inx]); inx++)
        //                        {
        //                            fullDate += folders[i][inx];
        //                            inOver = true;
        //                        }
        //                    }
        //                    if (inOver)
        //                    {
        //                        inOver = false;
        //                        break;
        //                    }
        //                    tmp = "";
        //                    continue;
        //                }
        //                tmp += folders[i][j];
        //            }
        //            if (fullDate.Length < 5)
        //                continue;
        //            individualDate = fullDate.Split('-', ' ');
        //            string hour = individualDate[3].Split('.')[0];
        //            string minute = individualDate[3].Split('.')[1];
        //            fullDate = "";
        //            string[] inDates = Form1.s[item.day].date.Split(' ');
        //            inDates[1] = Form1.WhichMonth((Form1.Month)(Enum.Parse(typeof(Form1.Month), inDates[1])));
        //            if (individualDate[0] == inDates[2] && Convert.ToInt32(individualDate[1]) == Convert.ToInt32(inDates[1]) && Convert.ToInt32(individualDate[2]) == Convert.ToInt32(inDates[0]))
        //            {
        //                if ((Convert.ToInt32(24 * Form1.s[item.day].hours[item.hour]) == Convert.ToInt32(hour) && Convert.ToInt32(minute) < 45 )|| Convert.ToInt32(hour) + 1 == Convert.ToInt32(24 * Form1.s[item.day].hours[item.hour]) && Convert.ToInt32(minute) >= 45)
        //                {
        //                    checkedDone = true;
        //                    break;
        //                }
        //            }
        //        }
        //        if (!checkedDone)
        //            listNotFound.Add(item);
        //        else
        //            checkedDone = false;
        //    }
        //    GridNotFound gnf = new GridNotFound();
        //    gnf.Show();
        //}



        //private void button2_Click(object sender, EventArgs e)
        //{

        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //}

        //private void button4_Click(object sender, EventArgs e)
        //{

        //}

        //private void chkDelete_CheckedChanged(object sender, EventArgs e)
        //{

        //}

        //private void button4_Click_1(object sender, EventArgs e)
        //{
        //    if (chkDelete.Checked || chkInnerDelete.Checked)
        //    {
        //        DialogResult dr = MessageBox.Show("Klasorler silinebilir eminmisiniz?", "?", MessageBoxButtons.YesNo);
        //        if (dr == DialogResult.No)
        //            return;
        //    }
        //    if (chkInnerDelete.Checked)
        //    {
        //        if (Form1.location == "")
        //            Form1.findLocation();
        //        string[] dirs = Directory.GetDirectories(Form1.location);
        //        int delCount = 0;
        //        long totalSize = 0, deletedSize = 0;
        //        foreach (string directory in dirs)
        //        {
        //            string[] files = Directory.GetFiles(directory);
        //            foreach (string file in files)
        //            {
        //                FileInfo f = new FileInfo(file);
        //                totalSize += f.Length;
        //                string extension = "";
        //                for (int z = file.Length - 1; file[z] != '.'; z--)
        //                {
        //                    extension += file[z];
        //                }
        //                if (Form1.reverse(extension) != textBox1.Text)
        //                {
        //                    File.Delete(file);
        //                    delCount++;
        //                }
        //            }
        //        }
        //        if (delCount > 0)
        //        {
        //            foreach (string directory in dirs)
        //            {
        //                string[] files = Directory.GetFiles(directory);
        //                foreach (string file in files)
        //                {
        //                    FileInfo f = new FileInfo(file);
        //                    deletedSize += f.Length;
        //                }
        //            }
        //            MessageBox.Show(delCount + " dosya silindi. " + " Azaltilan Boyut: " + ((totalSize - deletedSize) / 1000000).ToString() + "MB");
        //        }
        //        else
        //            MessageBox.Show("Hicbir dosya silinmedi.");
        //    }
        //    if (chkDelete.Checked)
        //    {
        //        if (Form1.location == "")
        //            Form1.findLocation();
        //        string[] dirs = Directory.GetDirectories(Form1.location);
        //        int nDeleted = 0;
        //        long dirByte;
        //        foreach (string directory in dirs)
        //        {
        //            dirByte = 0;
        //            string[] files = Directory.GetFiles(directory);
        //            foreach (string file in files)
        //            {
        //                FileInfo f = new FileInfo(file);
        //                dirByte += f.Length;
        //            }
        //            string[] t = Directory.GetDirectories(directory);
        //            if (t.Length == 0 && dirByte / 1000000 <= Convert.ToDouble(txtDelete.Text))
        //            {
        //                Directory.Delete(directory, true);
        //                nDeleted++;
        //            }
        //        }
        //        if (nDeleted > 0)
        //            MessageBox.Show(nDeleted + " klasor silindi.");
        //        else
        //            MessageBox.Show("Hicbir klasor silinmedi.");

        //    }
        //    if (chkName.Checked)
        //    {
        //        if (comboBox1.SelectedItem == null)
        //        {
        //            MessageBox.Show("Kisi secilmeli.");
        //            return;
        //        }
        //        fillList();
        //        string[] fullFolders = Directory.GetDirectories(Form1.location);
        //        string[] folders = new string[fullFolders.Length];
        //        bool internalSuccess = false;
        //        string internalFolderName = "";
        //        int howMany = 0;
        //        for (int i = 0, k = 0; i < fullFolders.Length; i++, k++)
        //        {
        //            for (int j = fullFolders[i].Length - 1; j >= 0; j--)
        //            {
        //                if (fullFolders[i][j] == '\\')
        //                    break;
        //                folders[k] += fullFolders[i][j];
        //            }
        //            folders[k] = Form1.reverse(folders[k]);
        //            if (folders[k].Length < 5)
        //                continue;
        //            string[] date = new string[4];
        //            string[] currentDate = new string[4];
        //            individualDate = folders[k].Split('-', ' ');
        //            try
        //            {
        //                currentDate[0] = individualDate[2];//DateTime.Now.Day.ToString();
        //            }
        //            catch (IndexOutOfRangeException)
        //            {
        //                continue;
        //            }
        //            currentDate[1] = individualDate[1]; //DateTime.Now.Month.ToString();
        //            currentDate[2] = individualDate[0]; //DateTime.Now.Year.ToString();
        //            string[] str = individualDate[3].Split('.');
        //            foreach (MeList item in listToCheck)
        //            {
        //                date = Form1.s[item.day].date.Split(' ');
        //                date[1] = Form1.WhichMonth((Form1.Month)(Enum.Parse(typeof(Form1.Month), date[1])));
        //                if (Convert.ToInt32(date[0]) == Convert.ToInt32(currentDate[0]) && Convert.ToInt32(date[1]) == Convert.ToInt32(currentDate[1]) && Convert.ToInt32(date[2]) == Convert.ToInt32(currentDate[2]))
        //                {
        //                    int hourx = Convert.ToInt32(Form1.s[item.day].hours[item.hour] * 24);
        //                    if (Form1.s[item.day].person[item.hour] == comboBox1.SelectedItem.ToString() && ((hourx - 1 == Convert.ToInt32(str[0])) && Int32.Parse(str[1]) > 45) || hourx == Convert.ToInt32(str[0])) 
        //                    {
        //                        internalFolderName = Form1.s[item.day].topic[item.hour];
        //                        internalSuccess = true;
        //                    }
        //                }
        //                if (internalSuccess)
        //                {
        //                    internalSuccess = false;
        //                    Directory.CreateDirectory(Form1.location + '\\' + item.sinif);
        //                    Directory.Move(fullFolders[k], Form1.location + '\\' + item.sinif + '\\' + internalFolderName + " " + folders[k]);
        //                    howMany++;
        //                    break;
        //                }
        //            }
        //        }
        //        if (howMany > 0)
        //            MessageBox.Show(howMany + " tane dosya duzeltildi.");
        //        else
        //            MessageBox.Show("Hicbir dosya duzeltilmedi.");
        //    }


        //}

    }
}
