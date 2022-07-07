// See https://aka.ms/new-console-template for more information
using System;
using SFML.Graphics;
using SFML.Window;

//Console.WriteLine("Hello, World!");

//namespace Kittens_I_hope
//{
//    class Program
//    {
//        public static string ProjectBasePath =
//            AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin", StringComparison.Ordinal));

//        static void Main(string[] args)
//        {
//            var rWindow = new RenderWindow(new VideoMode(700, 500), "Kitki are coming...");
//            var font = new Font($@"{ProjectBasePath}\\Resources\\Fonts\\Beyond Wonderland.ttf");
//            var text = new Text("Hello cat folk! I am doing something!!! Woooooooo!!!!!", font, 20);

//            rWindow.Closed += (sender, eventArgs) =>
//            {
//                Environment.Exit(-1);
//            };

//            while (rWindow.IsOpen)
//            {
//                rWindow.DispatchEvents();
//                rWindow.Clear(new Color(255, 0, 255));
//                rWindow.Draw(text);
//                rWindow.Display();
//            };
//        }

//    }
//}

namespace Cat_Tetris_i_hope
{

    class Cat_Game
    {
        private const int WIDTH = 600;
        private const int HEIGHT = 480;
        private const string TITLE = "Kitki are coming...";
        private VideoMode mode = new VideoMode(WIDTH, HEIGHT);
        private RenderWindow window;
        Sprite background;
        BlockManager mock_block;



        public Cat_Game()
        {
            this.window = new RenderWindow(this.mode, TITLE);

            this.window.SetVerticalSyncEnabled(true);
            this.window.Closed += (sender, args) =>
            {
                this.window.Close();
            };


            TextureManager.LoadTexture();

            background = new Sprite();
            background.Texture = TextureManager.BackgroundTexture;
            mock_block = new BlockManager();
        }

        public void run()
        {
            while (this.window.IsOpen)
            {
                this.handleEvents();
                this.update();
                if (mock_block.end) mock_block.endGame(window);
                this.draw();
            }
        }



        private void handleEvents()
        {
            this.window.DispatchEvents();
        }

        private void update() 
        {
            mock_block.update();

        }
        private void draw()
        {
            this.window.Clear(new Color(255, 0, 255));
            this.window.Draw(this.background);
            this.mock_block.draw(this.window);
            this.window.Display();
        }

    }



}










