using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace WpfApplication1
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Globals
        private static readonly int max_Aliens = 5;
        private static readonly int max_SpaceShips = 1;
        public Ship[] Aliens = new Ship[max_Aliens];
        public Ship[] Missiles = new Ship[1];
        public List<Image> myImageList = new List<Image>();
        public Ship[] SpaceShips = new Ship[max_SpaceShips];

        public MainWindow()
        {
            // stuff that happens when the WPF form loads

            // built in behinds the scenes C# stuff
            InitializeComponent();

            // instantiate alien objects
            for (var i = 0; i < max_Aliens; i++)
            {
                var Alien = new Ship("C:\\Alien1.png", 0, i, i, "Level1", false, 1);
                Aliens[i] = Alien;
            }

            // display images linked to these objects
            var X = 0;
            for (X = 0; X < max_Aliens; X++)
            {
                // using the very complicated C# process of ImageLists etc
                var myImage = new BitmapImage(new Uri(Aliens[X].Getimagefile()));
                var myImageControl = new Image();
                myImageControl.Source = myImage;
                Grid.SetRow(myImageControl, Aliens[X].Getenemyrowposition());
                Grid.SetColumn(myImageControl, Aliens[X].Getenemycolposition());
                GameGrid.Children.Add(myImageControl);
                myImageList.Add(myImageControl);
            }

            // instantiate a spaceship object
            var SpaceShip = new Ship("C:\\Spaceship.png", 0, 9, 5, "SpaceShip", false, 1);
            SpaceShips[0] = SpaceShip;

            // add spaceship image using previous image adding method
            var mySpaceShip = new BitmapImage(new Uri(SpaceShips[0].Getimagefile()));

            var mySpaceShipControl = new Image();
            mySpaceShipControl.Source = mySpaceShip;
            Grid.SetRow(mySpaceShipControl, SpaceShips[0].Getenemyrowposition());
            Grid.SetColumn(mySpaceShipControl, SpaceShips[0].Getenemycolposition());
            GameGrid.Children.Add(mySpaceShipControl);
            myImageList.Add(mySpaceShipControl);

            // kick off timer object to "tick" every 1000ms
            var dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // move things when the timer ticks
            for (var i = 0; i < max_Aliens; i++)
                // if alien is not dead
                if (Aliens[i] != null)
                    updateDisplay(myImageList[i], Aliens[i], Aliens[i].Getenemyrowposition(),
                        Aliens[i].Getenemycolposition() + Aliens[i].Getdirection());

            // if missiles exist
            if (Missiles[0] != null)
            {
                // remove them when they go off the board
                if (Missiles[0].Getenemyrowposition() < 1)
                {
                    Missiles[0] = null;
                    GameGrid.Children.Remove(myImageList[6]);
                }

                else
                {
                    // update their position
                    updateDisplay(myImageList[6], Missiles[0], Missiles[0].Getenemyrowposition() - 1,
                        Missiles[0].Getenemycolposition());

                    // for all missiles and aliens
                    for (var i = 0; i < max_Aliens; i++)
                        // if they exist, and the missile's coords are same as alien coords
                        if (Aliens[i] != null && Aliens[i].Getenemycolposition() == Missiles[0].Getenemycolposition() &&
                            Aliens[i].Getenemyrowposition() == Missiles[0].Getenemyrowposition())
                        {
                            // dead alien, remove it...
                            Aliens[i] = null;
                            GameGrid.Children.Remove(myImageList[i]);
                        }
                }
            }
        }

        private void leftbutton_Click(object sender, RoutedEventArgs e)
        {
            if (SpaceShips[0].Getenemycolposition() > 0)
                updateDisplay(myImageList[5], SpaceShips[0], SpaceShips[0].Getenemyrowposition(),
                    SpaceShips[0].Getenemycolposition() - 1);
        }

        private void rightbutton_Click(object sender, RoutedEventArgs e)
        {
            if (SpaceShips[0].Getenemycolposition() < 8)
                updateDisplay(myImageList[5], SpaceShips[0], SpaceShips[0].Getenemyrowposition(),
                    SpaceShips[0].Getenemycolposition() + 1);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // FIRE!!!!!!!!!!!!!!!!!!!!!

            // create missile
            var Missile = new Ship("C:\\missile.jpg", 0, SpaceShips[0].Getenemyrowposition() - 1,
                SpaceShips[0].Getenemycolposition(), "Missile", false, 1);
            Missiles[0] = Missile;
            var myMissile = new BitmapImage(new Uri(Missiles[0].Getimagefile()));

            // add to grid
            var myMissileControl = new Image();
            myMissileControl.Source = myMissile;
            Grid.SetRow(myMissileControl, Missiles[0].Getenemyrowposition());
            Grid.SetColumn(myMissileControl, Missiles[0].Getenemycolposition());
            GameGrid.Children.Add(myMissileControl);
            myImageList.Add(myMissileControl);
        }


        private void updateDisplay(Image myImage, Ship myEnemy, int row, int col)
        {
            // removes image then adds it. Yes, I know...
            GameGrid.Children.Remove(myImage);
            myEnemy.Setenemyrowposition(row);
            myEnemy.Setenemycolposition(col);
            Grid.SetRow(myImage, myEnemy.Getenemyrowposition());
            Grid.SetColumn(myImage, myEnemy.Getenemycolposition());
            GameGrid.Children.Add(myImage);

            // changes direction if going off edge.
            if (myEnemy.Getenemycolposition() > 8 || myEnemy.Getenemycolposition() < 1)
            {
                myEnemy.Setdirection(-myEnemy.Getdirection());
                myEnemy.Setenemyrowposition(myEnemy.Getenemyrowposition() + 1);
                if (myEnemy.Getenemyrowposition() > 5)
                {
                    GameGrid.Children.Remove(myImage);
                    myEnemy.Setenemyrowposition(0);
                }
            }
        }

        public class Ship
        {
            private int direction;
            private int enemycolposition;
            private int enemydamagepoints;
            private bool enemyhit;
            private int enemyrowposition;

            private string enemytype;
            // object properties 

            private string imagefile;


            public Ship(string imagefile, int enemydamagepoints, int enemyrowposition, int enemycolposition,
                string enemytype, bool enemyhit, int direction)
            {
                //contructor with overloads
                Setimagefile(imagefile);
                Setenemydamagepoints(enemydamagepoints);
                Setenemyrowposition(enemyrowposition);
                Setenemycolposition(enemycolposition);
                Setenemytype(enemytype);
                Setenemyhit(enemyhit);
                Setdirection(direction);
            }

            //get/set stuff here
            public void Setimagefile(string s)
            {
                imagefile = s;
            }

            public string Getimagefile()
            {
                return imagefile;
            }

            public void Setenemydamagepoints(int i)
            {
                enemydamagepoints = i;
            }

            public int Getenemydamagepoints()
            {
                return enemydamagepoints;
            }

            public void Setenemyrowposition(int i)
            {
                enemyrowposition = i;
            }

            public int Getenemyrowposition()
            {
                return enemyrowposition;
            }

            public void Setenemycolposition(int i)
            {
                enemycolposition = i;
            }

            public int Getenemycolposition()
            {
                return enemycolposition;
            }

            public void Setenemytype(string e)
            {
                enemytype = e;
            }

            public string Getenemytype()
            {
                return enemytype;
            }

            public void Setenemyhit(bool b)
            {
                enemyhit = b;
            }

            public bool Getenemyhit()
            {
                return enemyhit;
            }

            public void Setdirection(int i)
            {
                direction = i;
            }

            public int Getdirection()
            {
                return direction;
            }

            // no methods yet
        }
    }
}