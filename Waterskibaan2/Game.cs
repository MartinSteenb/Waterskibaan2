﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace Waterskibaan2
{
    public class Game
    {
        public Waterskibaan waterskibaan;
        public WachtrijStarten wachtrijStarten;
        public InstructieGroep instructieGroep;
        public WachtrijInstructie wachtrijinstructie;
        public Logger logger;

        public delegate void NieuweBezoekerHandler(NieuweBezoekerArgs args);
        public event NieuweBezoekerHandler NieuweBezoeker;

        public delegate void InstructieAfgelopenHandler(InstructieAfgelopenArgs args);
        public event InstructieAfgelopenHandler InstructieAfgelopen;

        public delegate void LijnenVerplaatstHandler();
        public event LijnenVerplaatstHandler LijnenVerplaatst;

        private static System.Timers.Timer aTimer;
        private int loopCounter;
        public Canvas Canvas { get; set; }

        public DispatcherTimer timer { get; set; } = new DispatcherTimer();

        public void Initialize(Canvas canvas)
        {
            Canvas = canvas;
            waterskibaan = new Waterskibaan();
            wachtrijStarten = new WachtrijStarten();
            instructieGroep = new InstructieGroep();
            wachtrijinstructie = new WachtrijInstructie();
            logger = new Logger(waterskibaan.kabel);

            NieuweBezoeker += OnNieuweBezoeker;
            InstructieAfgelopen += OnInstructieAfgelopen;
            LijnenVerplaatst += OnLijnenVerplaatst;

            SetTimer();

            /*Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();
            timer.Stop();
            timer.Dispose();*/

            Console.WriteLine("Terminating the application...");
        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            /*aTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;*/

            
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            loopCounter = 0;
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            //Console.WriteLine($"loopCounter = {loopCounter}");
            if (loopCounter % 3 == 0)
            {
                Sporter sporter = new Sporter(MoveCollection.GetWillekeurigeMoves());
                NieuweBezoeker?.Invoke(new NieuweBezoekerArgs(sporter));
            }

            if (loopCounter % 10 == 0)
            {
                List<Sporter> sporters = instructieGroep.SportersVerlatenRij(wachtrijinstructie.GetAlleSporters().Count);
                InstructieAfgelopen?.Invoke(new InstructieAfgelopenArgs(sporters));
                //Console.WriteLine($"Totaal aantal bezoekers = {logger.totaalAantalBezoekers()}");
                //Console.WriteLine($"Hoogste score tot nu toe = {logger.hoogsteScore()}");
                //Console.WriteLine($"Totaal aantal rondjes gedaan = {logger.totaalAantalRondjes()}");
            }

            if (loopCounter % 4 == 0)
            {
                LijnenVerplaatst?.Invoke();
            }
            loopCounter++;
        }

        private void OnNieuweBezoeker(NieuweBezoekerArgs e)
        {
            wachtrijinstructie.SporterNeemPlaatsInRij(e.Sporter);
            logger.voegBezoekerToe(e.Sporter);
            Console.WriteLine(wachtrijinstructie);
        }

        private void OnInstructieAfgelopen(InstructieAfgelopenArgs e)
        {
            int wriGroep = wachtrijinstructie.GetAlleSporters().Count;
            int maxInstructieGroep = instructieGroep.MAX_LENGTE_RIJ;

            List<Sporter> sporters = wachtrijinstructie.SportersVerlatenRij(Math.Min(wriGroep, maxInstructieGroep));
            foreach (Sporter sporter in sporters)
            {
                instructieGroep.SporterNeemPlaatsInRij(sporter);
            }
            Console.WriteLine(instructieGroep);

            foreach (Sporter sporter in e.Sporters)
            {
                wachtrijStarten.SporterNeemPlaatsInRij(sporter);
            }
            Console.WriteLine(wachtrijStarten);

            
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
