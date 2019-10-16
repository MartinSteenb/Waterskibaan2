using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Waterskibaan2;

namespace WaterskibaanApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Game game = new Game();
        public List<Rectangle> Rectangles { get; set; } = new List<Rectangle>();
        public List<Line> Lines { get; set; } = new List<Line>();
        public List<TextBox> TextBoxes { get; set; } = new List<TextBox>();

        public MainWindow()
        {
            InitializeComponent();

            //ConsoleApp1.Kassa.PrikBord += Kassa_PrikBord;
            //In main window luisteren naar je timerevent
            //timer event moet herschrijven naar dispatchertimer
            
            game.Initialize(myCanvas);
            game.timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        { 
            lblHoeveelheidLijnen.Content = $"Aantal lijnen op voorraad = {game.waterskibaan.voorraad.GetAantalLijnen()}";
            lblTotaalAantalBezoekers.Content = $"Bezoekers totaal = {game.logger.totaalAantalBezoekers()}";
            lblHoogsteScore.Content = $"Hoogste score = {game.logger.hoogsteScore()}";
            lblBezoekersMetRoodShirt.Content = $"Aantal bezoekers met rood shirt = {game.logger.hoeveelheidBezoekersMetRodeKleding()}";
            lblTotaalAantalRondjes.Content = $"Totaal aantal rondjes = {game.logger.totaalAantalRondjes()}";
            lblUniekeMoves.Content = $"Unieke moves van sporters = {game.logger.uniekeMovesVanBezoekersAanLijn()}";
            lblBezoekersGesorteerdOpLichtheid.Content = $"Lichtheid = ( \n {game.logger.lijstGesorteerdOpKledingMetLichtsteKleur()})";

            if (Rectangles.Count > 0)
            {
                foreach (Rectangle rec in Rectangles)
                {
                    myCanvas.Children.Remove(rec);
                }
            }

            if (Lines.Count > 0)
            {
                foreach (Line line in Lines)
                {
                    myCanvas.Children.Remove(line);
                }
            }

            if (TextBoxes.Count > 0)
            {
                foreach (TextBox text in TextBoxes)
                {
                    myCanvas.Children.Remove(text);
                }
            }

            int wachtrijInstructieCounter = 0;
            foreach(Sporter sporter in game.wachtrijinstructie.GetAlleSporters())
            {
                PositionRectangle(CreateARectangle(sporter.KledingKleur), 0, wachtrijInstructieCounter, 0, new Springen());
                wachtrijInstructieCounter++;
            }

            int instructieGroepCounter = 0;
            foreach (Sporter sporter in game.instructieGroep.GetAlleSporters())
            {
                PositionRectangle(CreateARectangle(sporter.KledingKleur), 1, instructieGroepCounter, 0, new Springen());
                instructieGroepCounter++;
            }

            int wachtrijStartenCounter = 0;
            foreach (Sporter sporter in game.wachtrijStarten.GetAlleSporters())
            {
                PositionRectangle(CreateARectangle(sporter.KledingKleur), 2, wachtrijStartenCounter, 0, new Springen());
                wachtrijStartenCounter++;
            }

            int kabelCounter = 0;
            foreach (Lijn lijn in game.waterskibaan.kabel._lijnen)
            {
                PositionRectangle(CreateARectangle(lijn.sporter.KledingKleur), 6, lijn.PositieOpDeKabel, lijn.nummer, lijn.sporter.HuidigeMove);
                kabelCounter++;
            }
            drawKabel();
        }

        public void drawLine(int x, int y, int i)
        {
            Line myLine = new Line();
            myLine.Stroke = System.Windows.Media.Brushes.Black;
            if(i >= 5)
            {
                myLine.X1 =  x + 20;
                myLine.X2 = x  + 50;
                myLine.Y1 = y + 20;
                myLine.Y2 = y + 75;
            }
            else
            {
                myLine.X1 = myCanvas.ActualWidth - x - 20;
                myLine.X2 = myCanvas.ActualWidth - x - 50;
                myLine.Y1 = y;
                myLine.Y2 = y - 50;
            }
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = 2;
            myCanvas.Children.Add(myLine);
            Lines.Add(myLine);
        }

        public void drawKabel()
        {
            Line myLine = new Line();
            myLine.Stroke = System.Windows.Media.Brushes.Black;
            myLine.X1 = 100;
            myLine.X2 = 700;
            myLine.Y1 = 250;
            myLine.Y2 = 250;
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = 2;
            myCanvas.Children.Add(myLine);
            Lines.Add(myLine);
        }

        public Rectangle CreateARectangle(Color kledingkleur)
        { 
            Rectangle rec = new Rectangle();
            rec.Height = 10;
            rec.Width = 10;
            
            SolidColorBrush color = new SolidColorBrush();
            color.Color = kledingkleur;
            rec.Fill = color;
            Rectangles.Add(rec);

            return rec;
        }

        public void PositionRectangle(Rectangle rec, int wachtrij, int i, int lijnNmr, IMoves huidigeMove)
        {
            int x = 10 + (20 * i);
            int y = 50 * wachtrij;
            myCanvas.Children.Add(rec);
            Canvas.SetRight(rec, x);
            Canvas.SetTop(rec, y);

            // OP DE BAAN
            if(wachtrij == 6)   
            {
                if(i < 5)
                {
                    x = 100 + (125 * i);
                    rec.Height = 20;
                    rec.Width = 20;
                    Canvas.SetRight(rec, x);
                    Canvas.SetTop(rec, y);
                    drawLine(x, y, i);
                    CreateLabel(x, y, i, lijnNmr, huidigeMove);
                }
                else
                {
                    x = 50 + (100 * (i - 4));
                    y = y - 125;
                    rec.Height = 20;
                    rec.Width = 20;
                    Canvas.SetLeft(rec, x);
                    Canvas.SetTop(rec, y);
                    drawLine(x, y, i);
                    CreateLabel(x, y, i, lijnNmr, huidigeMove);
                }
                
            }
        }

        public void CreateLabel(int x, int y, int i, int lijnNmr, IMoves huidigeMove)

        {
            TextBox move = new TextBox();
            if (huidigeMove != null)
            {
                move.Text = huidigeMove.ToString();
                move.Background = Brushes.Transparent;
                move.BorderThickness = new Thickness(0);
                myCanvas.Children.Add(move);
            }
           
            TextBox text = new TextBox();
            text.Text = $"{lijnNmr}";
            text.Background = Brushes.Transparent;
            text.BorderThickness = new Thickness(0);
            myCanvas.Children.Add(text);

            if (i < 5)
            {
                Canvas.SetRight(text, (x + 10));
                Canvas.SetTop(text, (y - 25));
                Canvas.SetRight(move, x);
                Canvas.SetTop(move, y + 25);
            }
            else
            {
                Canvas.SetLeft(text, (x + 10));
                Canvas.SetTop(text, (y + 25));
                Canvas.SetLeft(move, x);
                Canvas.SetTop(move, y - 25);
            }
            
            TextBoxes.Add(text);
            TextBoxes.Add(move);
        }



        public void PutOnGrid(Rectangle rec, int i)
        {
            myGrid.SetValue(Grid.RowProperty, 4);
            myGrid.SetValue(Grid.ColumnProperty, 4);
            myGrid.Children.Add(rec);
            Grid.SetRow(rec, 4);
            Grid.SetColumn(rec, 4);
        }
    }
}
