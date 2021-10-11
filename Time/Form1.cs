using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;

namespace Time
{
    public partial class Form1 : Form
    {
        private static int SIZE = 256;
        public static string DATE_FORMAT = "d MMMM yyyy - HH:mm - dddd";
        public static Single[] s = new Single[SIZE];
        int count = 0;
        public static string time, start, end;
        public static string[] sFiles = new string[SIZE];
        public static int fl;
        public static Single[] sendListS = new Single[SIZE];
        public static int k, exactLocation = 0, ex = 0;
        public static string location, selectedPerson;
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
        public static void findLocation()
        {
            StreamReader sr = new StreamReader("Default.txt");
            location = sr.ReadLine();
            sr.Close();
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
                if ((!chkInterval.Checked && s[i].date[0].Date.CompareTo(dtpStart.Value.Date) == 0) || chkInterval.Checked && s[i].date[0].Date.CompareTo(dtpStart.Value.Date) > -1 && s[i].date[0].Date.CompareTo(dtpEnd.Value.Date) < 0)
                {
                    sendListS[k] = new Single(s[i].classroom);
                    int cnt = 0;
                    for (int j = 0; j < s[i].date.Length && s[i].date[j] != DateTime.MinValue; j++)
                    {
                        if (s[i].person[j] == "-" || (cbxPerson.SelectedIndex > 0 && !s[i].person[j].Equals(selectedPerson))) continue;
                        sendListS[k].SetAll(cnt++, s[i].date[j], s[i].topic[j], s[i].person[j], s[i].type[j]);
                    }
                    if (cnt != 0) k++;
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
        private bool AskForLocation()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                location = folderBrowserDialog1.SelectedPath;
                StreamWriter sw = new StreamWriter("Default.txt");
                sw.WriteLine(location);
                sw.Close();
                return true;
            }
            return false;
        }
        private void dosyaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AskForLocation();
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
                for (int j = 0; j < Form1.s[i].person.Length && Form1.s[i].person[j] != null; j++)
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

        private async void Form1_Load(object sender, EventArgs e)
        {
            ntiTray.ContextMenuStrip = new ContextMenuStrip();
            ntiTray.ContextMenuStrip.Items.Add("Kapat", null, close_Click);
            SetLblInfoText("Hazir.");
            string defaultFile = Directory.GetCurrentDirectory() + "\\" + "Default.txt";
            if (!File.Exists(defaultFile))
                File.Create(defaultFile).Close();
            else
                findLocation();
            if (location == null || !Directory.Exists(location))
            {
                MessageBox.Show("Bilgilerin bulundugu klasoru secin");
                if (!AskForLocation()) Environment.Exit(-1);
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
                else //check for new files
                {
                    string[] readFiles = savedFiles.Split('*');
                    List<string> newFiles = new List<string>();
                    for (int i = 0; i < currentFiles.Length; i++)
                    {
                        string[] file = currentFiles[i].Split('\\');
                        if (file[file.Length - 1][0] == '~') continue;
                        int cnt = 0;
                        for (int j = 0; j < readFiles.Length - 1; j++)
                            if (file[file.Length - 1] != readFiles[j])
                                cnt++;
                        if (cnt == readFiles.Length - 1)
                            newFiles.Add(file[file.Length - 1]);
                    }
                    if (newFiles.Count > 0)
                    {
                        sr.Close();
                        await Task.Run(() => OpenExcel());
                    }
                    else //read from txt
                    {
                        string read;
                        int cnt = -1, j = 1;
                        while ((read = sr.ReadLine()) != null)
                        {
                            string[] single = read.Split('*');
                            if (cnt > -1 && s[cnt].date[0].Date == ExtractDateTime(single[0]).Date && s[cnt].classroom == single[1])
                            {
                                s[cnt].SetAll(j++, ExtractDateTime(single[0]), single[2], single[3], single[4]);
                            }
                            else
                            {
                                j = 1;
                                s[++cnt] = new Single(single[1]);
                                s[cnt].SetAll(0, ExtractDateTime(single[0]), single[2], single[3], single[4]);
                            }

                        }
                        sr.Close();
                    }
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
            findLocation();
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
                    int k = 0, innerK;
                    for (int j = 0; j < s[i].date.Length && s[i].date[j] != DateTime.MinValue; j++)
                    {
                        innerK = 0;
                        if (comparison == 0 && s[i].date[j].Hour > DateTime.Now.Hour && s[i].date[j].Hour - DateTime.Now.Hour < 2)
                        {
                            if (cbxPerson.SelectedIndex == 0 || (cbxPerson.SelectedIndex > 0 && cbxPerson.SelectedItem.ToString() == s[i].person[j]))
                            {
                                sendListS[k] = new Single(s[i].classroom);
                                sendListS[k++].SetAll(innerK++, s[i].date[j], s[i].topic[j], s[i].person[j], s[i].type[j]);
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
            findLocation();
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
                    if (Char.IsLetter(files[i][j]))
                    {
                        tstr += files[i][j];
                        while ((j + 1) < files[i].Length && Char.IsDigit(files[i][j + 1]))
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
            int tmp = 0, ignore = 1;
            for (int ov = 0; ov < e.Length; ov++)
            {
                SetLblInfoText(e[ov].path);
                count = tmp;
                string sTmp;
                for (int i = 1; (sTmp = e[ov].ReadCell(i, 1).ToString()) != ""; i += 7, count++, ignore = 1)
                {
                    s[count] = new Single(tmpString[ov]);
                    string[] dates = sTmp.Split(' ');
                    string currentTime;
                    for (int j = i + 1; (j - i - 1 < 6) && (currentTime = e[ov].ReadCell(j, 1).ToString()) != ""; j++)
                    {
                        if (e[ov].ReadCell(j, 6) == "-")
                        {
                            ignore++;
                            continue;
                        }
                        s[count].SetAll(j - i - ignore, new DateTime(Convert.ToInt32(dates[2]), Convert.ToInt32(WhichMonth((Month)Enum.Parse(typeof(Month), dates[1]))), Convert.ToInt32(dates[0]), Convert.ToInt32(Convert.ToDouble(currentTime) * 24), 0, 0), e[ov].ReadCell(j, 3).ToString(), e[ov].ReadCell(j, 6).ToString().Split('-')[1].Trim(), e[ov].ReadCell(j, 4).ToString());
                    }
                }
                tmp = count;
                e[ov].Quit();
            }
            List<Single> nS = new List<Single>();
            for(int i = 0; s[i] != null; i++)
                if (s[i].date[0] != DateTime.MinValue && s[i] != null)
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
            SaveAll(s);
            SetCursor(false);
            SetLblInfoText("Tamamlandi.");
        }

        private void SaveAll(Single[] s)
        {
            StreamWriter sw = new StreamWriter("Save.txt", true);
            for(int i =0;s[i] != null;i++)
            {
                for (int j = 0; s[i].date[j] != DateTime.MinValue; j++)
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
                    int k = 0, innerK = 0;
                    for (int j = 0; j < s[i].date.Length && s[i].date[j] != DateTime.MinValue; j++)
                    {
                        if ((rbNow.Checked && comparison == 0 && s[i].date[j].Hour == dateCompared.Hour) || rbClosest.Checked && ((comparison == 0 && s[i].date[j].Hour > dateCompared.Hour) || (comparison == 1)))
                        {
                            if (cbxPerson.SelectedIndex == 0 || (cbxPerson.SelectedIndex > 0 && cbxPerson.SelectedItem.ToString() == s[i].person[j]))
                            {
                                sendListS[k] = new Single(s[i].classroom);
                                sendListS[k++].SetAll(innerK++, s[i].date[j], s[i].topic[j], s[i].person[j], s[i].type[j]);
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
            public DateTime[] date = new DateTime[12];
            public string[] topic = new string[12];
            public string[] person = new string[12];
            public string[] type = new string[12];
            public string classroom;
            public Single(string classroom) {
                this.classroom = classroom;
            }
            public void SetAll(int at, DateTime date, string topic, string person, string type)
            {
                this.date[at] = date;
                this.topic[at] = topic;
                this.person[at] = person;
                this.type[at] = type;
            }
        }
        public class Host
        {
            public string name { get; set; }
            public int frequency { get; set; }
        }
    }
}
