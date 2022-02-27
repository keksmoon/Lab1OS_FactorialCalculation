using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1OS_FactorialCalculation
{
    public partial class AppForm : Form
    {
        public AppForm()
        {
            InitializeComponent();
        }

        public object qlocker = null;
        /// <summary>
        /// Метод, инкрементирующий прогресс-бар по мере выполнения задачи.
        /// </summary>
        public void AddToProgress()
        {
            if (InvokeRequired)
            {
                Invoke((Action)AddToProgress);
            }
            else
            {
                progress.Value++;

            }
        }

        public void InvertAllThreadsIsStopped()
        {
            if (InvokeRequired)
            {
                Invoke((Action)InvertAllThreadsIsStopped);
            }
            else
            {
                allThreadsIsStopped = allThreadsIsStopped ? false : true;

            }
        }


        public void SendResultToForm()
        {
            if (InvokeRequired)
            {
                Invoke((Action)SendResultToForm);
            }
            else
            {
                richTextBox1.Text = fractal.result.ToString();
            }
        }

        Fractal fractal = null;
        /// <summary>
        /// Метод, вызываемый при срабатывании события на передвижение ползунка трекбара.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarScroll(object sender, EventArgs e)
        {
            //if (fractal != null)
            //    fractal.stopCalculation();
            //progress.Value = 0;

            ////В дальнейшем эту заглушку надо передалать так, чтобы ползунок можно было передвигать
            ////без проблем, а расчет начинался непосредтвенно после его остановки и небольшой
            ////задержки, а не вовремя изменения как есть сейчас
            //MessageBox.Show(trackBar.Value.ToString());

            //int input = trackBar.Value;
            //progress.Maximum = input;

            //fractal = new Fractal(input, AddToProgress, SendResultToForm);
            //fractal.fractalCalculate();
        }

        bool allThreadsIsStopped = false;
        private void mouseUp(object sender, MouseEventArgs e)
        {
            if (fractal != null)
            {
                fractal.stopCalculation();
            }

            

            while (allThreadsIsStopped != true)
            {
                if (fractal == null)
                    break;

                if (allThreadsIsStopped == true)
                {
                    progress.Value = 0;
                }

                allThreadsIsStopped = false;
            }

            if (allThreadsIsStopped)
            {
                progress.Value = 0;
                allThreadsIsStopped = false;
            }

            //В дальнейшем эту заглушку надо передалать так, чтобы ползунок можно было передвигать
            //без проблем, а расчет начинался непосредтвенно после его остановки и небольшой
            //задержки, а не вовремя изменения как есть сейчас
            MessageBox.Show(trackBar.Value.ToString());

            int input = trackBar.Value;
            progress.Maximum = input;

            fractal = new Fractal(input, AddToProgress, SendResultToForm, InvertAllThreadsIsStopped);
            fractal.fractalCalculate();
        }
    }
    /// <summary>
    /// Класс, высчитывающий часть факториала. Запускается и выполняет свою работу при создании.
    /// </summary>
    public class ThreadFracSegment
    {
        public BigInteger result { get; private set; } = 1;
        public Action addToProgress { get; private set; }

        public int start { get; private set; }
        public int end { get; private set; }
        public bool threadEnded { get; private set; } = false;
        public bool threadJob { get; private set; } = true;

        public Thread ThreadFrac;

        public object locker;

        public void segmentFractalCalculate()
        {
            BigInteger result = new BigInteger(1);

            for (int i = start; i <= end; i++)
            {
                if (threadJob == false)
                {
                    break;
                }
                lock (locker)
                {
                    result *= i;
                    addToProgress.Invoke();
                }
            }

            this.result = result;
            this.threadEnded = true;
        }

        public void stopCalculation()
        {
            //if (ThreadFrac.IsAlive)
            //    ThreadFrac.Abort();
            //ThreadFrac = null;
            threadJob = false;
        }

        public ThreadFracSegment(int start, int end, Action addToProgress, ref object locker)
        {
            this.start = start;
            this.end = end;
            this.addToProgress = addToProgress;
            this.locker = locker;

            ThreadFrac = new Thread(new ThreadStart(this.segmentFractalCalculate));
            ThreadFrac.Start();
        }
    }
    /// <summary>
    /// Класс, управляющий потоками вычисления фрактала и сохраняющий результат по завершении.
    /// </summary>
    public class Fractal
    {
        public BigInteger result { get; private set; }

        public int input { get; private set; }
        public int procent { get; set; } = 0;

        public Action AddToProgress;
        public Action InvertAllThreadsIsStopped;
        public object locker = new object();

        private Thread masterThread;

        // Объекты, выполняющие частичное вычисление фрактала.
        public Stack<ThreadFracSegment> segments;

        public void fractalCalculate()
        {
            segments.Push(new ThreadFracSegment(1, input / 8, AddToProgress, ref locker));
            segments.Push(new ThreadFracSegment(input / 8 + 1, input / 8 * 2, AddToProgress, ref locker));
            segments.Push(new ThreadFracSegment(input / 8 * 2 + 1, input / 8 * 3, AddToProgress, ref locker));
            segments.Push(new ThreadFracSegment(input / 8 * 3 + 1, input / 8 * 4, AddToProgress, ref locker));
            segments.Push(new ThreadFracSegment(input / 8 * 4 + 1, input / 8 * 5, AddToProgress, ref locker));
            segments.Push(new ThreadFracSegment(input / 8 * 5 + 1, input / 8 * 6, AddToProgress, ref locker));
            segments.Push(new ThreadFracSegment(input / 8 * 6 + 1, input / 8 * 7, AddToProgress, ref locker));
            segments.Push(new ThreadFracSegment(input / 8 * 7 + 1, input, AddToProgress, ref locker));

            masterThread.Start();
        }

        public void stopCalculation()
        {

            masterThread.Abort();
            //lock (locker)
            //{
                while (segments.Count > 0)
                {
                    segments.Peek().stopCalculation();
                    
                    segments.Pop();
                }
            //}

            //Thread.Sleep(100);

            InvertAllThreadsIsStopped.Invoke();
        }

        public Fractal(int input, Action AddToProgress, Action SendResultToForm, Action InvertAllThreadsIsStopped)
        {
            this.input = input;
            this.AddToProgress = AddToProgress;
            this.InvertAllThreadsIsStopped = InvertAllThreadsIsStopped;

            segments = new Stack<ThreadFracSegment>();

            // Отслеживает работу всех потоков, и подводит ?промежуточный результат.
            masterThread = new Thread(new ThreadStart(() => {
                while (true)
                {
                    int goodjob = 0;
                        foreach (var segment in segments)
                        {
                            if (segment.threadEnded)
                                goodjob++;
                        }

                    if (goodjob == 8)
                    {
                        break;
                    }
                }

                //надо разрешить продолжить работать проге тк все потоки убиты
                //InvertAllThreadsIsStopped.Invoke();

                result = 1;
                foreach (var segment in segments)
                {
                    result *= segment.result;
                }

                //Здесь должен быть Action на управление записью результата в RichBox
                //MessageBox.Show("OK");

                SendResultToForm.Invoke();
            }));
        }
    }
}
