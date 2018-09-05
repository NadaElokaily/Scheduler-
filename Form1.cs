using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace gui1
{

   

    public partial class PrSch : Form
    {

        Label l;
        
        Scheduler NULL;
        char ProcessType;
        int type;
        int processNumber = 0;
        int processCounter = 0;
        int TimeQuantum = 0;
        int Id = 1;
        List<Process> myProcesses ;
        List<Sector> lol ;
        

        public PrSch()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            comboBox1.Items.Add("FCFS");
            comboBox1.Items.Add("SJF (Preemptive)");
            comboBox1.Items.Add("SJF (Non Preemptive)");
            comboBox1.Items.Add("Priority (Preemptive)");
            comboBox1.Items.Add("Priority (Non Preemptive)");
            comboBox1.Items.Add("Round Robin");
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            button1.Enabled = false;
            button3.Hide();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.Equals("FCFS"))
            {
                myProcesses = new List<Process>();
                lol = new List<Sector>();
                ProcessType = 'a';
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = false;
                textBox2.Enabled = false;
            }
            else if (comboBox1.SelectedItem.Equals("SJF (Preemptive)"))
            {
                myProcesses = new List<Process>();
                lol = new List<Sector>();
                ProcessType = 'b';
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = false;
                textBox2.Enabled = false;
            }
            else if (comboBox1.SelectedItem.Equals("SJF (Non Preemptive)"))
            {
                myProcesses = new List<Process>();
                lol = new List<Sector>();
                ProcessType = 'c';
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = false;
                textBox2.Enabled = false;
            }
            else if (comboBox1.SelectedItem.Equals("Priority (Preemptive)"))
            {
                myProcesses = new List<Process>();
                lol = new List<Sector>();
                ProcessType = 'd';
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox2.Enabled = false;
            }
            else if (comboBox1.SelectedItem.Equals("Priority (Non Preemptive)"))
            {
                myProcesses = new List<Process>();
                lol = new List<Sector>();
                ProcessType = 'e';
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox2.Enabled = false;
            }
            else if (comboBox1.SelectedItem.Equals("Round Robin"))
            {
                myProcesses = new List<Process>();
                lol = new List<Sector>();
                ProcessType = 'f';
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox2.Enabled = true;
                textBox5.Enabled = false;


            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (processCounter < processNumber)
            {
                label8.Text = (1 + processCounter).ToString();
                switch (ProcessType)
                {
                    case 'a':
                        
                        label9.Text = "FCFS";
                        type = 0;
                        
                        myProcesses.Add(new Process(int.Parse(textBox3.Text), int.Parse(textBox4.Text), Id));
                        Id++;
                        break;
                     case 'b':
                        label9.Text = "SJF (Preemptive)";
                        type = 5;
                        myProcesses.Add(new Process(int.Parse(textBox3.Text), int.Parse(textBox4.Text), Id));
                        Id++;
                        break;
                    case 'c':
                        
                        label9.Text = "SJF (Non Preemptive)";
                        type = 1;
                        myProcesses.Add(new Process(int.Parse(textBox3.Text), int.Parse(textBox4.Text), Id));
                        Id++;
                        break;
                    case 'd':
                        label9.Text = "Priority (Preemptive)";
                        type = 4;
                        Process p = new Process(int.Parse(textBox3.Text), int.Parse(textBox4.Text), Id);
                        p.setPriority(int.Parse(textBox5.Text));
                        myProcesses.Add(p);

                        Id++;
                        break;
                    case 'e':
                        label9.Text = "Priority (Non Preemptive)";
                        type = 2;
                        Process p1 = new Process(int.Parse(textBox3.Text), int.Parse(textBox4.Text), Id);
                        p1.setPriority(int.Parse(textBox5.Text));
                        myProcesses.Add(p1);

                        Id++;
                        break;
                    case 'f':
                        label9.Text = "Round Robin";
                        type = 3;
                        Process p2 = new Process(int.Parse(textBox3.Text), int.Parse(textBox4.Text), Id);
                        NULL.setQuantum(int.Parse(textBox2.Text));
                        myProcesses.Add(p2);
                        Id++;
                        break;
                }                

            }
            processCounter++;
            

            if (processCounter == processNumber)
            {                
                int x = 10;
                button1.Hide();
                label8.Text = "0";
                switch (ProcessType)
                {
                    case 'a':
                        label9.Text = "FCFS";
                        NULL.setProcesses(myProcesses);
                        lol = NULL.scheduleFCFS();
                        for (int i=0;i< lol.Count(); i++)
                        {
                            l = new Label();
                            l.Text = lol[i].getStart().ToString();
                            if (lol[i].getId()==0) { l.Text += " Idle"; }
                            else { l.Text += " P" + lol[i].getId().ToString(); }                            
                            l.Text += " " + lol[i].getEnd().ToString();

                            l.SetBounds(x, 450, lol[i].getDuration() * 50, 50);
                            l.Location = new Point(x, 450);
                            
                            this.Controls.Add(l);
                            l.BackColor = Color.Aquamarine;
                            l.AutoSize = false;
                            


                            x += (lol[i].getDuration()*50)+10;
                            
                        }
                        if(NULL.getWaiting()<0)
                            label3.Text = "Avrage Waiting Time: " + (-(NULL.getWaiting()) / (float)myProcesses.Count()).ToString();
                        else
                            label3.Text = "Avrage Waiting Time: "+(NULL.getWaiting() / (float)myProcesses.Count()).ToString();
                        break;
                    case 'b':
                        label9.Text = "SJF (Preemptive)";
                        NULL.setProcesses(myProcesses);
                        lol = NULL.scheduleSJFP();

                        for (int i = 0; i < lol.Count(); i++)
                        {
                            l = new Label();
                            l.Text = lol[i].getStart().ToString();
                            if (lol[i].getId() == 0) { l.Text += " Idle"; }
                            else { l.Text += " P" + lol[i].getId().ToString(); }
                            l.Text += " " + lol[i].getEnd().ToString();

                            l.SetBounds(x, 450, lol[i].getDuration() * 50, 50);
                            l.Location = new Point(x, 450);
                            this.Controls.Add(l);
                            
                            l.BackColor = Color.Aquamarine;
                            l.AutoSize = false;
                            
                            x += (lol[i].getDuration() * 50) + 10;

                        }
                        if (NULL.getWaiting() < 0)
                            label3.Text = "Avrage Waiting Time: " + (-(NULL.getWaiting()) / (float)myProcesses.Count()).ToString();
                        else
                            label3.Text = "Avrage Waiting Time: " + (NULL.getWaiting() / (float)myProcesses.Count()).ToString();
                        break;
                    case 'c':
                        label9.Text = "SJF (Non Preemptive)";
                        NULL.setProcesses(myProcesses);
                        lol = NULL.scheduleSJF();

                        for (int i = 0; i < lol.Count(); i++)
                        {
                            l = new Label();

                            l.Text = lol[i].getStart().ToString();
                            if (lol[i].getId() == 0) { l.Text += " Idle"; }
                            else { l.Text += " P" + lol[i].getId().ToString(); }
                            l.Text += " " + lol[i].getEnd().ToString();

                            l.SetBounds(x, 450, lol[i].getDuration() * 50, 50);
                            l.Location = new Point(x, 450);
                            this.Controls.Add(l);
                            l.BackColor = Color.Aquamarine;
                            l.AutoSize = false;
                            
                            x += (lol[i].getDuration() * 50) + 10;

                        }
                        if (NULL.getWaiting() < 0)
                            label3.Text = "Avrage Waiting Time: " + (-(NULL.getWaiting()) / (float)myProcesses.Count()).ToString();
                        else
                            label3.Text = "Avrage Waiting Time: " + (NULL.getWaiting() / (float)myProcesses.Count()).ToString();
                        break;
                    case 'd':
                        label9.Text = "Priority (Preemptive)";
                        NULL.setProcesses(myProcesses);
                        lol = NULL.schedulePriorityP();

                        for (int i = 0; i < lol.Count(); i++)
                        {
                            l = new Label();
                            l.Text = lol[i].getStart().ToString();
                            if (lol[i].getId() == 0) { l.Text += " Idle"; }
                            else { l.Text += " P" + lol[i].getId().ToString(); }
                            l.Text += " " + lol[i].getEnd().ToString();

                            l.SetBounds(x, 450, lol[i].getDuration() * 50, 50);
                            l.Location = new Point(x, 450);
                            this.Controls.Add(l);
                            l.BackColor = Color.Aquamarine;
                            l.AutoSize = false;
                            
                            x += (lol[i].getDuration() * 50) + 10;

                        }

                        if (NULL.getWaiting() < 0)
                            label3.Text = "Avrage Waiting Time: " + (-(NULL.getWaiting()) / (float)myProcesses.Count()).ToString();
                        else
                            label3.Text = "Avrage Waiting Time: " + (NULL.getWaiting() / (float)myProcesses.Count()).ToString();
                        break;
                    case 'e':
                        label9.Text = "Priority (Non Preemptive)";
                        NULL.setProcesses(myProcesses);
                        lol = NULL.schedulePriority();

                        for (int i = 0; i < lol.Count(); i++)
                        {
                            l = new Label();
                            l.Text = lol[i].getStart().ToString();
                            if (lol[i].getId() == 0) { l.Text += " Idle"; }
                            else { l.Text += " P" + lol[i].getId().ToString(); }
                            l.Text += " " + lol[i].getEnd().ToString();

                            l.SetBounds(x, 450, lol[i].getDuration() * 50, 50);
                            l.Location = new Point(x, 450);
                            this.Controls.Add(l);
                            l.BackColor = Color.Aquamarine;
                            l.AutoSize = false;
                            
                            x += (lol[i].getDuration() * 50) + 10;

                        }
                        if (NULL.getWaiting() < 0)
                            label3.Text = "Avrage Waiting Time: " + (-(NULL.getWaiting()) / (float)myProcesses.Count()).ToString();
                        else
                            label3.Text = "Avrage Waiting Time: " + (NULL.getWaiting() / (float)myProcesses.Count()).ToString();
                        break;
                    case 'f':
                        label9.Text = "Round Robin";
                        NULL.setProcesses(myProcesses);
                        lol = NULL.scheduleRR();

                        for (int i = 0; i < lol.Count(); i++)
                        {
                            l = new Label();
                            l.Text = lol[i].getStart().ToString();
                            if (lol[i].getId() == 0) { l.Text += " Idle"; }
                            else { l.Text += " P" + lol[i].getId().ToString(); }
                            l.Text += " " + lol[i].getEnd().ToString();

                            l.SetBounds(x, 450, lol[i].getDuration() * 50, 50);
                            l.Location = new Point(x, 450);
                            this.Controls.Add(l);
                            l.BackColor = Color.Aquamarine;
                            l.AutoSize = false;
                            
                            x += (lol[i].getDuration() * 50) + 10;

                        }
                        if (NULL.getWaiting() < 0)
                            label3.Text = "Avrage Waiting Time: " + (-(NULL.getWaiting()) / (float)myProcesses.Count()).ToString();
                        else
                            label3.Text = "Avrage Waiting Time: " + (NULL.getWaiting() / (float)myProcesses.Count()).ToString();
                        break;
                }
            }
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void label1_Click(object sender, EventArgs e){ }

        private void label2_Click(object sender, EventArgs e) { }       
       
        private void label7_Click(object sender, EventArgs e) { }

        private void textBox5_TextChanged(object sender, EventArgs e) { }

        private void textBox3_TextChanged(object sender, EventArgs e) { }

        private void textBox4_TextChanged(object sender, EventArgs e) { }

        private void label8_Click(object sender, EventArgs e)
        {
            
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button3_Click(object sender, EventArgs e)
        {
           /* Form1_Load( sender, e);
            myProcesses = new List<Process>();
            lol = new List<Sector>();
            button2.Enabled = true;
            textBox1.Enabled = true;
            comboBox1.Enabled = true;
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            label9.Text = "Enter Process";
            button1.Show();
            processNumber = 0;
            processCounter = 0;
            TimeQuantum = 0;
            Id = 1;
            Label Clr = new Label();
            Clr.SetBounds(10, 450,10000, 50);
            Clr.Location = new Point(10, 450);
            this.Controls.Add(Clr);
            Clr.BackColor = Color.PaleTurquoise;
            Clr.AutoSize = false;*/

          

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            textBox1.Enabled = false;
            comboBox1.Enabled = false;
            button1.Enabled = true;
            NULL = new Scheduler(type);
            NULL.setProcessesNum(int.Parse(textBox1.Text));
            
            processNumber = int.Parse(textBox1.Text);
            processCounter = 0;
            Id = 1;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
        }
    }
    public class Process
    {
        int arrival;
        int duration;
        int waiting;
        int remaining;
        int id;
        int priority;
        public Process(int num1, int num2, int num3)
        {
            arrival = num1;
            remaining = num2;
            duration = num2;
            waiting = 0;
            id = num3;
            priority = 0;
        }

        public void setPriority(int num)
        {
            priority = num;
        }
        public void setWaiting(int num)
        {
            waiting = num;
        }
        public void setRemaining(int num)
        {
            remaining = num;
        }

        public int getPriority()
        {
            return priority;
        }
        public int getWaiting()
        {
            return waiting;
        }
        public int getRemaining()
        {
            return remaining;
        }
        public int getDuration()
        {
            return duration;
        }
        public int getArrival()
        {
            return arrival;
        }
        public int getId()
        {
            return id;
        }

    }

    public class Sector
    {
        int start;
        int end;
        Process process;
        int duration;
        public Sector(int num1, int num2, Process p)
        {
            start = num1;
            end = num2;
            process = p;
            duration = end - start;
        }
        public void setEnd(int num)
        {
            end = num;
            duration = end - start;
        }
        public int getStart()
        {
            return start;
        }
        public int getDuration()
        {
            return duration;
        }
        public int getEnd()
        {
            return end;
        }
        public Process getProcess()
        {
            return process;
        }
        public int getId()
        {
            return process.getId();
        }
    }
    public class Scheduler
    {
        public
        int type;
        int ProcessesNum;
        List<Process> myProcesses;
        int counter;
        int quantum;
        int waiting;

        public Scheduler(int num)
        {
            type = num;
            myProcesses = new List<Process>();
            counter = 0;
            quantum = 4;
            waiting = 0;
        }
        public void resetCounter()
        {
            counter = 0;
        }
        public void setQuantum(int num)
        {
            quantum = num;
        }
        public void setProcessesNum(int num)
        {
            ProcessesNum = num;
        }
        public void setProcesses(List<Process> p)
        {
            myProcesses = p;
        }

        public int getType()
        {
            return type;
        }
        public int getWaiting()
        {
            return waiting;
        }
        public int getNum()
        {
            return ProcessesNum;
        }
        public int getQuantum()
        {
            return quantum;
        }

        void swapProcesses(int i, int i2, List<Process> processList)
        {
            Process temp = processList[i];
            processList[i] = processList[i2];
            processList[i2] = temp;
        }
        void SortProcess(String by, List<Process> processes)
        {
            int j, i;
            int n = processes.Count;
            switch (by)
            {
                case "byArriveTime":
                    for (j = 0; j < n; j++)
                        for (i = 0; i < n - 1; i++)
                            if (processes[i].getArrival() > processes[i + 1].getArrival())
                                swapProcesses(i, i + 1, processes);
                    break;


                case "byBurstTime":
                    for (j = 0; j < n; j++)
                        for (i = 0; i < n - 1; i++)
                        {
                            if (processes[i].getDuration() == processes[i + 1].getDuration())
                                if (processes[i].getArrival() > processes[i + 1].getArrival())
                                    swapProcesses(i, i + 1, processes);
                            if (processes[i].getDuration() > processes[i + 1].getDuration())
                                swapProcesses(i, i + 1, processes);
                        }

                    break;

                case "byRemainingTime":
                    for (j = 0; j < n; j++)
                        for (i = 0; i < n - 1; i++)
                        {
                            if (processes[i].getRemaining() == processes[i + 1].getRemaining())
                                if (processes[i].getArrival() > processes[i + 1].getArrival())
                                    swapProcesses(i, i + 1, processes);
                            if (processes[i].getRemaining() > processes[i + 1].getRemaining())
                                swapProcesses(i, i + 1, processes);
                        }

                    break;

                case "byPriority":
                    for (j = 0; j < n; j++)
                        for (i = 0; i < n - 1; i++)
                        {
                            if (processes[i].getPriority() == processes[i + 1].getPriority())
                                if (processes[i].getArrival() > processes[i + 1].getArrival())
                                    swapProcesses(i, i + 1, processes);
                            if (processes[i].getPriority() > processes[i + 1].getPriority())
                                swapProcesses(i, i + 1, processes);
                        }

                    break;

                    /*case "byName":
                        for (j = 0; j < n; j++)
                            for (i = 0; i < n - 1; i++)
                                if (processes[i].getName() > processes[i + 1].getName())
                                    swapProcesses(i, i + 1, processes);
                        break;*/

            }

        }
        public List<Sector> scheduleFCFS()
        {
            SortProcess("byArriveTime", myProcesses);
            List<Sector> sectors = new List<Sector>();
            for (int i = 0; i < ProcessesNum; i++)
            {
                if (counter < myProcesses[i].getArrival())
                {
                    Sector s1 = new Sector(counter, myProcesses[i].getArrival(), new Process(counter, myProcesses[i].getArrival() - counter, 0));
                    sectors.Add(s1);
                    counter = myProcesses[i].getArrival();
                }
                Sector s = new Sector(counter, counter + myProcesses[i].getDuration(), myProcesses[i]);
                myProcesses[i].setWaiting(counter - myProcesses[i].getArrival() - myProcesses[i].getDuration());
                counter += myProcesses[i].getDuration();
                waiting += counter - myProcesses[i].getArrival() - myProcesses[i].getDuration();
                sectors.Add(s);
            }
            return sectors;
        }
        public List<Sector> scheduleRR()
        {
            SortProcess("byArriveTime", myProcesses);
            List<Process> copy = new List<Process>();

            for (int i = 0; i < myProcesses.Count(); i++)
            {
                copy.Add(myProcesses[i]);
            }
            List<Process> ready = new List<Process>();
            List<Sector> sectors = new List<Sector>();
            Process p = null;
            while (copy.Count() > 0 || (ready.Count() > 0) || (p != null && p.getRemaining() > 0))
            {
                for (int i = 0; i < copy.Count(); i++)
                {
                    if (copy[i].getArrival() <= counter)
                    {
                        ready.Add(copy[i]);
                        copy.RemoveAt(i);
                        i--;
                    }
                }
                if (p != null && p.getRemaining() > 0)
                {
                    ready.Add(p);
                }
                if (ready.Count() > 0)
                {
                    int duration = (ready[0].getRemaining() < quantum) ? ready[0].getRemaining() : quantum;
                    ready[0].setRemaining(ready[0].getRemaining() - duration);
                    p = ready[0];
                    ready.RemoveAt(0);
                    Sector s = new Sector(counter, counter + duration, p);
                    sectors.Add(s);
                    counter += duration;
                    if (p.getRemaining() == 0) waiting += counter - p.getArrival() - p.getDuration();
                }
                else
                {
                    Sector s = new Sector(counter, counter + 1, new Process(counter, counter + 1, 0));
                    sectors.Add(s);

                    counter++;

                }
            }
            return sectors;
        }
        public List<Sector> scheduleSJF()
        {
            SortProcess("byArriveTime", myProcesses);
            List<Process> copy = new List<Process>();

            for (int i = 0; i < myProcesses.Count(); i++)
            {
                copy.Add(myProcesses[i]);
            }
            List<Process> ready = new List<Process>();
            List<Sector> sectors = new List<Sector>();

            while (copy.Count() > 0 || (ready.Count() > 0))
            {
                for (int i = 0; i < copy.Count(); i++)
                {
                    if (copy[i].getArrival() <= counter)
                    {
                        ready.Add(copy[i]);
                        copy.RemoveAt(i);
                        i--;
                    }
                }
                SortProcess("byRemainingTime", ready);
                if (ready.Count() > 0)
                {
                    Process p = ready[0];
                    ready.RemoveAt(0);
                    Sector s = new Sector(counter, counter + p.getDuration(), p);
                    sectors.Add(s);
                    counter += p.getDuration();
                    waiting += counter - p.getArrival() - p.getDuration();
                }
                else
                {
                    Sector s = new Sector(counter, counter + 1, new Process(counter, counter + 1, 0));
                    sectors.Add(s);
                    counter++;
                }
            }
            for (int i = 1; i < sectors.Count(); i++)
            {
                if (sectors[i].getId() == 0 && sectors[i - 1].getId() == 0)
                {
                    sectors[i - 1].setEnd(sectors[i - 1].getEnd() + 1);
                    sectors.RemoveAt(i);
                    i--;
                }
            }
            return sectors;
        }
        public List<Sector> schedulePriority()
        {
            SortProcess("byArriveTime", myProcesses);
            List<Process> copy = new List<Process>();
            for (int i = 0; i < myProcesses.Count(); i++)
            {
                copy.Add(myProcesses[i]);
            }
            List<Process> ready = new List<Process>();
            List<Sector> sectors = new List<Sector>();

            while (copy.Count() > 0 || (ready.Count() > 0))
            {
                for (int i = 0; i < copy.Count(); i++)
                {
                    if (copy[i].getArrival() <= counter)
                    {
                        ready.Add(copy[i]);
                        copy.RemoveAt(i);
                        i--;
                    }
                }
                SortProcess("byPriority", ready);
                if (ready.Count() > 0)
                {
                    Process p = ready[0];
                    ready.RemoveAt(0);
                    Sector s = new Sector(counter, counter + p.getDuration(), p);
                    sectors.Add(s);
                    counter += p.getDuration();
                    waiting += counter - p.getArrival() - p.getDuration();
                }
                else
                {
                    Sector s = new Sector(counter, counter + 1, new Process(counter, counter + 1, 0));
                    sectors.Add(s);
                    counter++;
                }
            }
            for (int i = 1; i < sectors.Count(); i++)
            {
                if (sectors[i].getId() == 0 && sectors[i - 1].getId() == 0)
                {
                    sectors[i - 1].setEnd(sectors[i - 1].getEnd() + 1);
                    sectors.RemoveAt(i);
                    i--;
                }
            }
            return sectors;
        }
        public List<Sector> scheduleSJFP()
        {
            SortProcess("byArriveTime", myProcesses);
            List<Process> copy = new List<Process>();
            for (int i = 0; i < myProcesses.Count(); i++)
            {
                copy.Add(myProcesses[i]);
            }
            Dictionary<int, List<Process>> map = new Dictionary<int, List<Process>>();
            for (int i = 0; i < copy.Count(); i++)
            {
                if (!map.ContainsKey(copy[i].getArrival()))
                {
                    List<Process> list = new List<Process>();
                    list.Add(copy[i]);
                    map.Add(copy[i].getArrival(), list);
                }
                else
                {
                    map[copy[i].getArrival()].Add(copy[i]);
                }
            }
            List<Process> ready = new List<Process>();
            List<Sector> sectors = new List<Sector>();
            Process p = null;
            while (map.Count() > 0 || (ready.Count() > 0) || (p != null && p.getRemaining() > 0))
            {
                if (map.ContainsKey(counter))
                {
                    for (int j = 0; j < map[counter].Count(); j++)
                    {
                        ready.Add(map[counter][j]);
                    }
                    map.Remove(counter);
                }
                SortProcess("byRemainingTime", ready);
                if (ready.Count() > 0)
                {
                    if (p == null)
                    {
                        p = ready[0];
                        ready.RemoveAt(0);
                        p.setRemaining(p.getRemaining() -1);
                        Sector s = new Sector(counter, counter + 1, p);
                        sectors.Add(s);
                        if (p.getRemaining() == 0)
                        {
                            waiting += counter - p.getArrival() - p.getDuration();
                            p = null;
                        }
                    }
                    else if (p.getRemaining() > ready[0].getRemaining())
                    {
                        ready.Add(p);
                        p = ready[0];
                        ready.RemoveAt(0);
                        p.setRemaining(p.getRemaining() - 1);
                        Sector s = new Sector(counter, counter + 1, p);
                        sectors.Add(s);
                        if (p.getRemaining() == 0)
                        {
                            waiting += counter - p.getArrival() - p.getDuration();
                            p = null;
                        }
                    }
                    else
                    {
                        p.setRemaining(p.getRemaining() - 1);
                        Sector s = new Sector(counter, counter + 1, p);
                        sectors.Add(s);
                        if (p.getRemaining() == 0)
                        {
                            waiting += counter - p.getArrival() - p.getDuration();
                            p = null;
                        }
                    }
                }
                else if (p != null)
                {
                    p.setRemaining(p.getRemaining() - 1);
                    Sector s = new Sector(counter, counter + 1, p);
                    sectors.Add(s);
                    if (p.getRemaining() == 0)
                    {
                        waiting += counter - p.getArrival() - p.getDuration();
                        p = null;
                    }
                }

                else
                {
                    Sector s = new Sector(counter, counter + 1, new Process(counter, counter + 1, 0));
                    sectors.Add(s);
                }

                counter++;
                if (counter > 2000) { break; }
            }
            for (int i = 1; i < sectors.Count(); i++)
            {
                if (sectors[i].getId() == sectors[i - 1].getId())
                {
                    sectors[i - 1].setEnd(sectors[i - 1].getEnd() + 1);
                    sectors.RemoveAt(i);
                    i--;
                }
            }
            return sectors;
        }
        public List<Sector> schedulePriorityP()
        {

            SortProcess("byArriveTime", myProcesses);
            List<Process> copy = new List<Process>();
            for (int i = 0; i < myProcesses.Count(); i++)
            {
                copy.Add(myProcesses[i]);
            }
            Dictionary<int, List<Process>> map = new Dictionary<int, List<Process>>();
            for (int i = 0; i < copy.Count(); i++)
            {
                if (!map.ContainsKey(copy[i].getArrival()))
                {
                    List<Process> list = new List<Process>();
                    list.Add(copy[i]);
                    map.Add(copy[i].getArrival(), list);
                }
                else
                {
                    map[copy[i].getArrival()].Add(copy[i]);
                }
            }
            List<Process> ready = new List<Process>();
            List<Sector> sectors = new List<Sector>();
            Process p = null;
            while (map.Count() > 0 || (ready.Count() > 0) || (p != null && p.getRemaining() > 0))
            {
                if (map.ContainsKey(counter))
                {
                    for (int j = 0; j < map[counter].Count(); j++)
                    {
                        ready.Add(map[counter][j]);
                    }
                    map.Remove(counter);
                }
                SortProcess("byPriority", ready);

                if (ready.Count() > 0)
                {
                    if (p == null)
                    {
                        p = ready[0];
                        ready.RemoveAt(0);
                        p.setRemaining(p.getRemaining() - 1);
                        Sector s = new Sector(counter, counter + 1, p);
                        sectors.Add(s);
                        if (p.getRemaining() == 0)
                        {
                            waiting += counter - p.getArrival() - p.getDuration();
                            p = null;
                        }
                    }
                    else if (p.getPriority() > ready[0].getPriority())
                    {
                        ready.Add(p);
                        p = ready[0];
                        ready.RemoveAt(0);
                        p.setRemaining(p.getRemaining() - 1);
                        Sector s = new Sector(counter, counter + 1, p);
                        sectors.Add(s);
                        if (p.getRemaining() == 0)
                        {
                            waiting += counter - p.getArrival() - p.getDuration();
                            p = null;
                        }
                    }
                    else
                    {
                        p.setRemaining(p.getRemaining() - 1);
                        Sector s = new Sector(counter, counter + 1, p);
                        sectors.Add(s);
                        if (p.getRemaining() == 0)
                        {
                            waiting += counter - p.getArrival() - p.getDuration();
                            p = null;
                        }
                    }
                }
                else if (p != null)
                {
                    p.setRemaining(p.getRemaining() - 1);
                    Sector s = new Sector(counter, counter + 1, p);
                    sectors.Add(s);
                    if (p.getRemaining() == 0)
                    {
                        waiting += counter - p.getArrival() - p.getDuration();
                        p = null;
                    }
                }

                else
                {
                    Sector s = new Sector(counter, counter + 1, new Process(counter, counter + 1, 0));
                    sectors.Add(s);
                }
                counter++;
            }
            for (int i = 1; i < sectors.Count(); i++)
            {
                if (sectors[i].getId() == sectors[i - 1].getId())
                {
                    sectors[i - 1].setEnd(sectors[i - 1].getEnd() + 1);
                    sectors.RemoveAt(i);
                    i--;
                }
            }
            return sectors;
        }


        public int X()
        {
            int x = 0;
            if (type == 0) x = 525;
            else if (type == 1) x = 555;
            else if (type == 2) x = 505;
            else if (type == 3) x = 450;
            else if (type == 4) x = 385;
            else if (type == 5) x = 420;
            return x;
        }
        public String getString()
        {
            String s = "";
            if (type == 0) s = "FCFS";
            else if (type == 1) s = "SJF";
            else if (type == 2) s = "Proirity";
            else if (type == 3) s = "Round Robin";
            else if (type == 4) s = "Priority Preemptive";
            else if (type == 5) s = "SJF Preemptive";
            return s + " Scheduler";
        }

    }

}
