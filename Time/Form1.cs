using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
//TEST
namespace Time
{
    public partial class Form1 : Form
    {
        private static int SIZE = 256;
        public static string DATE_FORMAT = "d MMMM yyyy - HH:mm - dddd";
        public static  Single[] s = new Single[SIZE];
        public static string time, start, end;
        public static string[] sFiles = new string[SIZE];
        public static int fl;
        public static Single[] sendListS = new Single[SIZE];
        public static int k, exactLocation = 0, ex = 0;
        public static string location = Directory.GetCurrentDirectory() + "\\xl", selectedPerson;
        public static bool interval = false, personal = false, comboFilled = false;
        public static string[] hour, topic, classroom, person;
        public Host[] h = new Host[512];
        CancellationTokenSource cts = new CancellationTokenSource();
        public static int minBeforeRemind;
        Task continues = null;
        public Form1()
        {
            InitializeComponent();
        }
        public enum Month
        {
            Eylül,
            Ekim,
            Kasım,
            Aralık,
            Ocak,
            Şubat,
            Mart,
            Nisan,
            Haziran,
            Temmuz,
            Ağustos
        }
        public static void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        public static string WhichMonth(Month month)
        {
            switch (month)
            {
                case Month.Ocak:
                    return "1";
                case Month.Şubat:
                    return "2";
                case Month.Mart:
                    return "3";
                case Month.Nisan:
                    return "4";
                case Month.Haziran:
                    return "6";
                case Month.Temmuz:
                    return "7";
                case Month.Ağustos:
                    return "8";
                case Month.Eylül:
                    return "9";
                case Month.Ekim:
                    return "10";
                case Month.Kasım:
                    return "11";
                case Month.Aralık:
                    return "12";
                default:
                    return "";
            }
        }
        private void listAtDate(object sender, EventArgs e)
        {
            start = dtpStart.Value.ToShortDateString();
            end = dtpEnd.Value.ToShortDateString();
            sendListS = new Single[256];
            k = 0;
            interval = true;
            for (int i = 0; s[i] != null; i++)
            {
                if ((!chkInterval.Checked && s[i].date[0].Date.CompareTo(dtpStart.Value.Date) == 0) || chkInterval.Checked && s[i].date[0].Date.CompareTo(dtpStart.Value.Date) > -1 && s[i].date[0].Date.CompareTo(dtpEnd.Value.Date) < 1)
                {
                    sendListS[k] = new Single(s[i].classroom);
                    for (int j = 0; j < s[i].date.Count && s[i].date[j] != DateTime.MinValue; j++)
                    {
                        if (s[i].person[j] == "-" || (cbxPerson.SelectedIndex > 0 && !s[i].person[j].Equals(selectedPerson))) continue;
                        sendListS[k].SetAll(s[i].date[j], s[i].topic[j], s[i].person[j], s[i].type[j]);
                    }
                    k++;
                }
            }
            if (k == 0)
            {
                MessageBox.Show("Girilenlere gore ders bulunamadi.");
                return;
            }
            GridSelected gs = new GridSelected();
            gs.ShowDialog();
        }


        private void cikisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rebuildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenExcel();
        }

        public static string reverse(string str)
        {
            string nstr = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                nstr += str[i];
            }
            return nstr;
        }
        private void dosyaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }
        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void rbNow_CheckedChanged(object sender, EventArgs e)
        {
            dtpStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.0f);
            dtpHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.0f);
        }

        private void rbClosest_CheckedChanged(object sender, EventArgs e)
        {
            dtpStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.0f);
            dtpHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.0f);
        }

        private DateTime ExtractDateTime(string dt)
        {
            string[] dateTime = dt.Split(' '); 
            string[] date = dateTime[0].Split('/');
            return new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0]), Convert.ToInt32(dateTime[1]), 0, 0);
        }
        public void TryUpdate()
        {

            //WebClient webClient = new WebClient();
            //webClient.DownloadFile(new Uri("https://github.com/ErenalpKesici/Ders-Hatirlatici/releases/download/v1.0/Ders.zip"), Directory.GetCurrentDirectory()+"\\Update.zip");
            ZipFile.ExtractToDirectory(Directory.GetCurrentDirectory() + "\\Update.zip", Directory.GetCurrentDirectory() + "\\Update");
            foreach (string file in Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Update"))
            {
                if (File.Exists(file))
                {
                    string[] currFile = file.Split('\\');
                    string currFileName = currFile[currFile.Length - 1];
                    string dest = Directory.GetCurrentDirectory() + "\\" + currFileName;
                    string back = Directory.GetCurrentDirectory() + "\\Backups\\" + currFileName + ".bak";
                    File.Delete(dest);
                    //File.Replace(file, dest, back);
                }
            }
        }
        private void FillPeople()
        {
            if (cbxPerson.SelectedIndex == 0)
                personal = false;
            personal = true;
            if (comboFilled)
                return;
            bool exists = false;
            for (int i = 0; s[i] != null; i++)
            {
                for (int j = 0; j < Form1.s[i].person.Count && Form1.s[i].person[j] != null; j++)
                {
                    if (Form1.s[i].person[j] == null || Form1.s[i].person[j] == "-")
                        continue;
                    for (int t = 0; h[t] != null; t++)
                    {
                        if (Form1.s[i].person[j] == h[t].name)
                        {
                            exists = true;
                            break;
                        }
                    }
                    if (!exists)
                    {
                        h[ex] = new Host();
                        h[ex++].name = s[i].person[j];
                    }
                    else
                        exists = false;
                }
            }
            for (int i = 0; h[i] != null; i++)
                cbxPerson.Items.Add(h[i].name);
            cbxPerson.SelectedItem = cbxPerson.Items[0];
            if (h.Length > 0)
                comboFilled = true;
        }
        private void downloadAndUnzip()
        {

            WebClient webClient = new WebClient();
            webClient.DownloadFile(new Uri("https://github.com/ErenalpKesici/Ders-Hatirlatici-Mobil/releases/download/Attachments/xl.zip"), Directory.GetCurrentDirectory() + "\\xl.zip");
            ZipFile.ExtractToDirectory(Directory.GetCurrentDirectory() + "\\xl.zip", location);
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            ntiTray.ContextMenuStrip = new ContextMenuStrip();
            ntiTray.ContextMenuStrip.Items.Add("Kapat", null, close_Click);
            SetLblInfoText("Hazir.");
            FileInfo fi = new FileInfo(Directory.GetCurrentDirectory() + "\\xl.zip");
            if (!fi.Exists)
                downloadAndUnzip();
            else if(NetworkInterface.GetIsNetworkAvailable())
            {
                WebRequest req = WebRequest.Create("https://github.com/ErenalpKesici/Ders-Hatirlatici-Mobil/releases/download/Attachments/xl.zip");
                req.Method = "HEAD";
                using (WebResponse resp = req.GetResponse())
                    if (long.TryParse(resp.Headers.Get("Content-Length"), out long contentLength))
                        if (fi.Length != contentLength)
                        {
                            if (Directory.Exists(Directory.GetCurrentDirectory() + "\\xl"))
                                Directory.Delete(Directory.GetCurrentDirectory() + "\\xl", true);
                            if (File.Exists(Directory.GetCurrentDirectory() + "\\Save.txt"))
                                File.Delete(Directory.GetCurrentDirectory() + "\\Save.txt");
                            downloadAndUnzip();
                        }
            }
            string[] currentFiles = Directory.GetFiles(location);
            string saveFile = Directory.GetCurrentDirectory() + "\\" + "Save.txt";
            if (!File.Exists(saveFile))
            {
                File.Create(saveFile).Close();
                await Task.Run(() => OpenExcel());
            }
            else
            {
                StreamReader sr = new StreamReader("Save.txt");
                string savedFiles = sr.ReadLine();
                if (savedFiles == null)
                {
                    sr.Close();
                    await Task.Run(() => OpenExcel());
                }
                else //read the save file
                {
                    string read;
                    int cnt = -1;
                    while ((read = sr.ReadLine()) != null)
                    {
                        string[] single = read.Split('*');
                        if (cnt > -1 && s[cnt].date[0].Date == ExtractDateTime(single[0]).Date && s[cnt].classroom == single[1])
                        {
                            s[cnt].SetAll(ExtractDateTime(single[0]), single[2], single[3], single[4]);
                        }
                        else
                        {
                            s[++cnt] = new Single(single[1]);
                            s[cnt].SetAll(ExtractDateTime(single[0]), single[2], single[3], single[4]);
                        }

                    }
                    sr.Close();
                }
            }
            FillPeople();
        }

        private void btnVideo_Click(object sender, EventArgs e)
        {
            Check c = new Check();
            c.Show();
        }

        private void ddPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPerson = cbxPerson.SelectedItem.ToString();
            if (cbRemind.Checked)
                ExecuteReminder();

        }

        private void secilenKlasorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(location);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            OpenExcel();
        }

        private void startDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEnd.Visible)
                dtpStart.MaxDate = dtpEnd.Value;
            dtpEnd.MinDate = dtpStart.Value;
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEnd.Visible)
                dtpStart.MaxDate = dtpEnd.Value;
            dtpEnd.MinDate = dtpStart.Value;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                ntiTray.Visible = true;
            }
        }


        private void ntiTray_MouseClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            ntiTray.Visible = false;

        }
        private int ScheduleTheReminder()
        {
            for (int i = 0; s[i] != null; i++)
            {
                int comparison = s[i].date[0].Date.CompareTo(DateTime.Now.Date);
                if (comparison != -1)
                {
                    int k = 0;
                    for (int j = 0; j < s[i].date.Count && s[i].date[j] != DateTime.MinValue; j++)
                    {
                        if (comparison == 0 && s[i].date[j].Hour > DateTime.Now.Hour && s[i].date[j].Hour - DateTime.Now.Hour < 2)
                        {
                            if (cbxPerson.SelectedIndex == 0 || (cbxPerson.SelectedIndex > 0 && cbxPerson.SelectedItem.ToString() == s[i].person[j]))
                            {
                                sendListS[k] = new Single(s[i].classroom);
                                sendListS[k++].SetAll(s[i].date[j], s[i].topic[j], s[i].person[j], s[i].type[j]);
                                cts.Cancel();
                                int msLeft = Convert.ToInt32((s[i].date[j].Subtract(DateTime.Now)).TotalMilliseconds);
                                if (msLeft < 0)
                                    return 0;
                                int msLeftEarlier = msLeft - Convert.ToInt32(cbxRemind.SelectedItem) * 60000;
                                if (msLeftEarlier < 0)
                                    return msLeft - msLeftEarlier;
                                return msLeftEarlier;
                            }
                        }
                    }
                }
            }
            return 0;
        }
        private void ExecuteReminder()
        {
            if (continues != null && !continues.IsCompleted)
                cts.Cancel();
            TaskScheduler uiThread = TaskScheduler.FromCurrentSynchronizationContext();
            int msToRemind = ScheduleTheReminder();
            Console.WriteLine(msToRemind / 60000);
            if (msToRemind != 0)
            {
                Popup p = new Popup(msToRemind, true);
                if (cts.IsCancellationRequested) cts = new CancellationTokenSource();
                if (msToRemind < 0)
                    msToRemind = 0;
                continues = Task.Delay(msToRemind).ContinueWith(_ => p.Show(), cts.Token, TaskContinuationOptions.ExecuteSynchronously, uiThread); 
            }
        }

        private void cbRemind_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRemind.Checked)
            {
                cbxRemind.Visible = true;
                lblRemind.Visible = true;
                ExecuteReminder();
            }
            else
            {
                cbxRemind.Visible = false;
                lblRemind.Visible = false;
            }
        }

        private void programKlasorunuAcToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Process.Start(Directory.GetCurrentDirectory());
        }

        private void cbxRemind_SelectedIndexChanged(object sender, EventArgs e)
        {
            minBeforeRemind = Convert.ToInt32(cbxRemind.SelectedItem);
            ExecuteReminder();
        }


        private void btnSum_Click(object sender, EventArgs e)
        {
            FindSum f = new FindSum();
            f.ShowDialog();
        }

        private void chkInterval_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInterval.Checked)
            {
                lblStart.Visible = true;
                chkInterval.Text = "Bitis: ";
                dtpEnd.Visible = true;
            }
            else
            {
                chkInterval.Text = "Aralik Sec ";
                dtpEnd.Visible = false;
                lblStart.Visible = false;
                dtpStart.MaxDate = dtpStart.Value.AddYears(1);
            }
        }

        private void SetLblInfoText(string text)
        {
            if (InvokeRequired)
            {
                Invoke((Action<string>)SetLblInfoText, text);
                return;
            }
            lblInfo.Text = text;
        }
        private void SetCursor(bool wait)
        {
            if (InvokeRequired)
            {
                Invoke((Action<bool>)SetCursor, wait);
                return;
            }
            if(wait)
                Cursor = Cursors.WaitCursor;
            else
                Cursor = Cursors.Default;
        }
        public void OpenExcel()
        {
            SetLblInfoText("Dosyalar Okunuyor...");
            SetCursor(true);
            string[] dFiles = Directory.GetFiles(location);
            string[] files = new string[128];
            string[] tmpString = new string[dFiles.Length];
            int cn = 0;
            List<int> onesToDo = new List<int>();
            string tstr = "", isg = "";
            bool acquired = false, wrong = false;
            for (int i = 0; i < dFiles.Length; i++, cn++)
            {
                for (int j = dFiles[i].Length - 1; j >= 0; j--)
                {
                    if (dFiles[i][j] == '$')
                    {
                        wrong = true;
                        break;
                    }
                    if (dFiles[i][j] != '\\')
                    {
                        files[cn] += dFiles[i][j];
                    }
                    else
                        break;
                }
                if (wrong)
                {
                    wrong = false;
                    continue;
                }
                files[cn] = reverse(files[cn]);
            }
            cn = 0;
            for (int i = 0; i < dFiles.Length; i++)
            {
                if (files[i][0] == '-' || files[i][0] == '$')
                    continue;
                isg = isg + files[i][0] + files[i][1] + files[i][2];
                if (isg == "isg")
                {
                    isg = "";
                    sFiles[fl++] = dFiles[i];
                    continue;
                }
                isg = "";
                for (int j = 0; j < files[i].Length; j++)
                {
                    tstr = "";
                    if (char.IsLetter(files[i][j]))
                    {
                        tstr += files[i][j];
                        while ((j + 1) < files[i].Length && char.IsDigit(files[i][j + 1]))
                        {
                            acquired = true;
                            tstr += files[i][j + 1];
                            j++;
                        }
                        if (acquired)
                            break;
                    }
                }
                if (acquired && tstr != "")
                {
                    acquired = false;
                    onesToDo.Add(i);
                    tmpString[cn++] = tstr;
                    tstr = "";
                }
            }
            Excel[] e = new Excel[cn];
            StreamWriter sw = new StreamWriter("Save.txt");
            for (int i = 0; i < onesToDo.Count; i++)
            {
                string[] tmpSave = dFiles[onesToDo[i]].Split('\\');
                sw.Write(tmpSave[tmpSave.Length - 1] + "*");
                e[i] = new Excel(dFiles[onesToDo[i]], 1);
            }
            sw.WriteLine();
            sw.Close();
            int count = 0;
            for (int ov = 0; ov < e.Length; ov++)
            {
                SetLblInfoText(e[ov].path);
                for (int i = 1; e[ov].ReadCell(i, 1).ToString() != "";i++)
                {
                    string currentCell = e[ov].ReadCell(i, 1).ToString();
                    int lastJ = 0;
                    if(s[count] != null)
                        count++;
                    string[] dates = currentCell.Split(' ');
                    for (int j = i + 1; (currentCell =  e[ov].ReadCell(j, 1).ToString()).Contains("."); j++) 
                    {
                        lastJ++;
                        if (e[ov].ReadCell(j, 6).ToString() == "-") continue;
                        if(s[count] == null)
                            s[count] = new Single(tmpString[ov]);
                        s[count].SetAll(new DateTime(Convert.ToInt32(dates[2]), Convert.ToInt32(WhichMonth((Month)Enum.Parse(typeof(Month), dates[1]))), Convert.ToInt32(dates[0]), Convert.ToInt32(Convert.ToDouble(currentCell) * 24), 0, 0), e[ov].ReadCell(j, 3).ToString(), e[ov].ReadCell(j, 6).ToString(), e[ov].ReadCell(j, 4).ToString());
                        //Console.WriteLine(count+": " + dates[0] + dates[1]+dates[2]+"  and  " + new DateTime(Convert.ToInt32(dates[2]), Convert.ToInt32(WhichMonth((Month)Enum.Parse(typeof(Month), dates[1]))), Convert.ToInt32(dates[0]), Convert.ToInt32(Convert.ToDouble(currentCell) * 24), 0, 0));
                        //Console.WriteLine(s[count-1].date[0]);
                    }
                    i += lastJ;
                    //sTmp = e[ov].ReadCell(i + readSingle, 1).ToString();
                    //string[] dates = sTmp.Split(' ');
                    //string currentTime;
                    //bool created = false;
                    //for (int j = i + 2; (currentTime = e[ov].ReadCell(j, 1).ToString()) != "" && currentTime.Contains("."); j++)
                    //{
                    //    readSingle++;
                    //    if (e[ov].ReadCell(j, 6) == "-")
                    //    {
                    //        continue;
                    //    }
                    //    if(!created)
                    //    {
                    //        s[++count] = new Single(tmpString[ov]);
                    //        created = true;
                    //    }
                    //    s[count].SetAll(new DateTime(Convert.ToInt32(dates[2]), Convert.ToInt32(WhichMonth((Month)Enum.Parse(typeof(Month), dates[1]))), Convert.ToInt32(dates[0]), Convert.ToInt32(Convert.ToDouble(currentTime) * 24), 0, 0), e[ov].ReadCell(j, 3).ToString(), e[ov].ReadCell(j, 6).ToString().Split('-')[1].Trim(), e[ov].ReadCell(j, 4).ToString());
                    //}
                }

                e[ov].Quit();
            }
            Console.WriteLine();
                List<Single> nS = new List<Single>();
            for(int i = 0; s[i] != null; i++)
                if (s[i].date[0] != DateTime.MinValue)
                    nS.Add(s[i]);
            s = nS.ToArray();
            Array.Sort(s, (a, b) => a.date[0].CompareTo(b.date[0]));

           
            Single[] expandedS = new Single[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                if (i >= s.Length)
                    break;
                expandedS[i] = s[i];
            }
            s = expandedS;
            SaveAll(s); for (int i = 0; s[i] != null; i++)
            {
                Console.WriteLine(s[i].date[0].Month + " " + s[i].date[0].Day);
            }
            SetCursor(false);
            SetLblInfoText("Tamamlandi.");
        }

        private void SaveAll(Single[] s)
        {
            StreamWriter sw = new StreamWriter("Save.txt", true);
            for(int i =0;s[i] != null;i++)
            {
                for (int j = 0; j < s[i].date.Count && s[i].date[j] != DateTime.MinValue; j++)
                    sw.WriteLine(s[i].date[j].Day+"/"+ s[i].date[j].Month+ "/"+s[i].date[j].Year+" "+ s[i].date[j].Hour + "*" + s[i].classroom+"*"+ s[i].topic[j]+"*"+ s[i].person[j]+"*"+s[i].type[j]);
            }
            sw.Close();
        }

        public void findNow(object sender, EventArgs e)
        {
            sendListS = new Single[256];
            Popup p;  
            DateTime dateCompared;
            dateCompared = DateTime.Now;
            bool found = false;
            for (int i = 0; s[i] != null; i++)
            {
                if (found) break;
                int comparison = s[i].date[0].Date.CompareTo(dateCompared.Date);
                if (comparison != -1)
                {
                    int k = 0;
                    for (int j = 0; j < s[i].date.Count && s[i].date[j] != DateTime.MinValue; j++)
                    {
                        if ((rbNow.Checked && comparison == 0 && s[i].date[j].Hour == dateCompared.Hour) || rbClosest.Checked && ((comparison == 0 && s[i].date[j].Hour > dateCompared.Hour) || (comparison == 1)))
                        {
                            if (cbxPerson.SelectedIndex == 0 || (cbxPerson.SelectedIndex > 0 && cbxPerson.SelectedItem.ToString() == s[i].person[j]))
                            {
                                sendListS[k] = new Single(s[i].classroom);
                                sendListS[k++].SetAll(s[i].date[j], s[i].topic[j], s[i].person[j], s[i].type[j]);
                                found = true;
                                p = new Popup(Convert.ToInt32(s[i].date[j].Subtract(dateCompared).TotalMilliseconds), false);
                                p.Show();
                                break;
                            }
                        }
                    }
                }
            }
            if(!found)
                MessageBox.Show("Ders bulunmadi.");
        }
        public class Single
        {
            public List<DateTime> date = new List<DateTime>();
            public List<string> topic = new List<string>();
            public List<string> person = new List<string>();
            public List<string> type = new List<string>();
            public string classroom;
            public Single(string classroom) {
                this.classroom = classroom;
            }
            public void SetAll(DateTime date, string topic, string person, string type)
            {
                this.date.Add(date);
                this.topic.Add(topic);
                this.person.Add(person);
                this.type.Add(type);
            }
            //public void SetAllAt(int at, DateTime date, string topic, string person, string type)
            //{
            //    this.date[at] = date;
            //    this.topic[at] = topic;
            //    this.person[at] = person;
            //    this.type[at] = type;
            //}

        }
        public class Host
        {
            public string name { get; set; }
            public int frequency { get; set; }
        }
    }
}
