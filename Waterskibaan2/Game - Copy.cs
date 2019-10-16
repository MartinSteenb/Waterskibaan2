using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using static System.Net.Mime.MediaTypeNames;

namespace Waterskibaan2
{
    public class Game
    {
        public Waterskibaan waterskibaan;
        public WachtrijStarten wachtrijStarten;
        public InstructieGroep instructieGroep;
        public WachtrijInstructie wachtrijinstructie;

        public delegate void NieuweBezoekerHandler(NieuweBezoekerArgs args);
        public event NieuweBezoekerHandler NieuweBezoeker;

        public delegate void InstructieAfgelopenHandler(InstructieAfgelopenArgs args);
        public event InstructieAfgelopenHandler InstructieAfgelopen;

        public delegate void LijnenVerplaatstHandler();
        public event LijnenVerplaatstHandler LijnenVerplaatst;

        private static System.Timers.Timer aTimer;
        private int loopCounter;

        public void Initialize()
        {
            waterskibaan = new Waterskibaan();
            wachtrijStarten = new WachtrijStarten();
            instructieGroep = new InstructieGroep();
            wachtrijinstructie = new WachtrijInstructie();

            NieuweBezoeker += OnNieuweBezoeker;
            InstructieAfgelopen += OnInstructieAfgelopen;
            LijnenVerplaatst += OnLijnenVerplaatst;

            SetTimer();

            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();
            aTimer.Stop();
            aTimer.Dispose();

            Console.WriteLine("Terminating the application...");
        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(MoveCollection.random.Next(2000, 3001));
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            loopCounter = 0;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            /*Sporter sporter = new Sporter(MoveCollection.GetWillekeurigeMoves());
            
            waterskibaan.SporterStart(sporter);
            Console.WriteLine(waterskibaan);
            waterskibaan.VerplaatsKabel();
            Console.WriteLine();*/


            if (loopCounter % 3 == 0)
            {
                Sporter sporter = new Sporter(MoveCollection.GetWillekeurigeMoves());
                NieuweBezoeker?.Invoke(new NieuweBezoekerArgs(sporter));
            }

            if (loopCounter % 20 == 0)
            {
                List<Sporter> sporters = instructieGroep.SportersVerlatenRij(wachtrijinstructie.GetAlleSporters().Count);
                InstructieAfgelopen?.Invoke(new InstructieAfgelopenArgs(sporters));
            }

            if (loopCounter % 4 == 0)
            {
                LijnenVerplaatst?.Invoke();
            }
        }

        private void OnNieuweBezoeker(NieuweBezoekerArgs e)
        {
            wachtrijinstructie.SporterNeemPlaatsInRij(e.Sporter);
            //Console.WriteLine(wachtrijinstructie);
        }

        private void OnInstructieAfgelopen(InstructieAfgelopenArgs e)
        {
            foreach (Sporter sporter in e.Sporters)
            {
                wachtrijStarten.SporterNeemPlaatsInRij(sporter);
            }
            //Console.WriteLine(wachtrijStarten);

            int wriGroep = wachtrijinstructie.GetAlleSporters().Count;
            int maxInstructieGroep = instructieGroep.MAX_LENGTE_RIJ;

            List<Sporter> sporters = wachtrijinstructie.SportersVerlatenRij(Math.Min(wriGroep, maxInstructieGroep));
            foreach (Sporter sporter in sporters)
            {
                instructieGroep.SporterNeemPlaatsInRij(sporter);
            }
            //Console.WriteLine(instructieGroep);
        }

        private void OnLijnenVerplaatst()
        {
            if (waterskibaan.kabel.IsStartPositieLeeg())
            {
                List<Sporter> sporters = wachtrijStarten.SportersVerlatenRij(1);
                if (sporters.Count != 0)
                {
                    Sporter sporter = sporters[0];
                    sporter.Zwemvest = new Zwemvest();
                    sporter.Skies = new Skies();

                    waterskibaan.SporterStart(sporter);
                }
            }
            Console.WriteLine(waterskibaan);
            waterskibaan.VerplaatsKabel();
        }

    }
}
