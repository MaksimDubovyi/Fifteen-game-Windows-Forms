namespace Пятнашки
{
    public partial class Form1 : Form
    {
        int[] arr = new int[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        List<Button> buttons = new List<Button>();
        int min=0;
        int sec=0;
        public Form1()
        {
            InitializeComponent();
            progressBar1.Step = 1;
            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);
            buttons.Add(button7);
            buttons.Add(button8);
            buttons.Add(button9);
            buttons.Add(button10);
            buttons.Add(button11);
            buttons.Add(button12);
            buttons.Add(button13);
            buttons.Add(button14);
            buttons.Add(button15);
            buttons.Add(button16);
            for (int i = 0; i < arr.Length; i++)
                buttons[i].Enabled = false;
            button18.Enabled = false;
            button19.Visible = false;
        }
        void Time()
        {
            sec++;
            if (sec == 60)
            {
                min++;
                sec = 0;
            }
            label1.Text = string.Format("{0:D2}:{1:D2}", min, sec);
        }
        void mix()
        {
            Random rand = new Random();
            for (int t = 0; t < arr.Length - 1; t++)
            {
                int j = rand.Next(1, 15);
                for (int i = 0; i < j; i++)
                {
                    int tmp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = tmp;

                }
            }
        }
        void Init()
        {
            mix();
            for (int i = 0; i < arr.Length; i++)
                buttons[i].Text = arr[i].ToString();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Time();
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();
                for (int i = 0; i < arr.Length; i++)
                    buttons[i].Enabled =false;
                button18.Enabled = true;
                button19.Visible = true;
            }
        }
        private void button_Click(object sender, EventArgs e)
        {
         Button button = (Button)sender;
            int x = Convert.ToInt32(button.TabIndex);
            int t = progressBar1.Value;

            if (x != 0 && x != 4 && x != 8 && x != 12 && buttons[x-1].Visible ==false)
            {
                int txt = Convert.ToInt32(buttons[x].Text);
                if (txt == buttons[x].TabIndex + 1 && t != 0)
                    progressBar1.Value = --t;

                if (txt == (buttons[x - 1].TabIndex + 1))
                    progressBar1.PerformStep();

                string str = buttons[x - 1].Text;
                buttons[x - 1].Text = buttons[x].Text;
                buttons[x].Text = str;
                buttons[x].Visible = false;
                buttons[x-1].Visible = true;
            }
            else if ( x != 0 && x != 1 && x != 2 && x != 3 && buttons[x - 4].Visible == false)
            {
                int txt = Convert.ToInt32(buttons[x].Text);
                if (txt == buttons[x].TabIndex + 1 && t != 0)
                    progressBar1.Value = --t;

                if (txt == (buttons[x - 4].TabIndex + 1))
                    progressBar1.PerformStep();

                string str = buttons[x - 4].Text;
                buttons[x - 4].Text = buttons[x].Text;
                buttons[x].Text = str;
                buttons[x].Visible = false;
                buttons[x - 4].Visible = true;
            }
            else if (x != 12 && x != 13 && x != 14 && x != 15 && buttons[x + 4].Visible == false)
            {
                int txt = Convert.ToInt32(buttons[x].Text);
                if (txt == buttons[x].TabIndex+1 && t != 0)
                    progressBar1.Value = --t;

                if (txt == (buttons[x + 4].TabIndex + 1))
                    progressBar1.PerformStep();

                string str = buttons[x + 4].Text;
                buttons[x + 4].Text = buttons[x].Text;
                buttons[x].Text = str;
                buttons[x].Visible = false;
                buttons[x + 4].Visible = true;
            }
            else if (x != 3 && x != 7 && x != 11 && x != 15 && buttons[x + 1].Visible == false)
            {
                int txt = Convert.ToInt32(buttons[x].Text);
                if (txt == buttons[x].TabIndex + 1 && t != 0)
                    progressBar1.Value = --t;

                if (txt == (buttons[x + 1].TabIndex + 1))
                    progressBar1.PerformStep();

                string str = buttons[x + 1].Text;
                buttons[x + 1].Text = buttons[x].Text;
                buttons[x].Text = str;
                buttons[x].Visible = false;
                buttons[x + 1].Visible = true;
            }

        }
        void Start() 
        {
            for (int i = 0; i < arr.Length; i++)
                buttons[i].Enabled = true;

            button17.Enabled = false;
            button19.Visible = false;
            button18.Enabled = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 15;
            progressBar1.Value = 0;
            timer1.Start();
            Init();
            min = 0;
            sec = 0;
            buttons[15].Visible = false;
            buttons[15].Text = "0";
        }
        private void Start_Click(object sender, EventArgs e)
        {
            Start();
        }
        private void RE_Start_Click(object sender, EventArgs e)
        {
            Start();
            for (int i = 0; i < arr.Length-1; i++)
                buttons[i].Visible = true;
        }
    }
}