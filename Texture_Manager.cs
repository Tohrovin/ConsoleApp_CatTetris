using System;
using SFML.Graphics;
using SFML.Window;

namespace Cat_Tetris_i_hope
{
    class TextureManager
    {
        public static string ProjectBasePath =
            AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin", StringComparison.Ordinal));

        static Texture mockTexture;
        static Texture mockTexture2;
        static Texture backgroundTexture;
        static Texture emptyTexture;


        public static Texture MockTexture()
        {
            Random random = new Random();
            Texture[] texture_list = new Texture[] { mockTexture, mockTexture2 };
            int rand = random.Next(0, texture_list.Length);
            Texture mock_texture = texture_list[rand];
            return mock_texture;
        }
        public static Texture BackgroundTexture { get { return backgroundTexture; } }
        public static Texture EmptyTexture { get { return emptyTexture; } }
        public static void LoadTexture()
        {
            mockTexture = new Texture($@"{ProjectBasePath}\\bin\\Assets\\Textures\\mock_block.png");
            mockTexture2 = new Texture($@"{ProjectBasePath}\\bin\\Assets\\Textures\\mock_block2.png");
            emptyTexture = new Texture($@"{ProjectBasePath}\\bin\\Assets\\Textures\\empty.png");
            backgroundTexture = new Texture($@"{ProjectBasePath}\\bin\\Assets\\Textures\\mock_backgroundTexture.jpg");
        }
    }

}