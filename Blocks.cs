using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Numerics;

namespace Cat_Tetris_i_hope
{
    class Block
    {
        private Sprite sprite;
        public const float BLOCK_SPEED = 40f;
        public const float BLOCK_ROTATION = 90f;
        Vector2f position;
        float rotation;
        bool[] has_done = new bool[] {false, false};
        public Sprite BlockSprite { get { return sprite; } }
        public Vector2f Position { get { return position; } }
        public float Rotation { get { return rotation; } }




        public Block()
        {
            this.sprite = new Sprite();
            this.sprite.Texture = TextureManager.MockTexture();
            this.position.X = 280;
            this.position.Y = 0;
            this.rotation = 0;
            this.sprite.Position = this.position;
            this.sprite.Rotation = this.rotation;
        }

        public bool[] keyHandler(bool hasRotated = false, bool hasMoved = false)
        {
            bool moveLeft = Keyboard.IsKeyPressed(Keyboard.Key.A);
            bool moveRight = Keyboard.IsKeyPressed(Keyboard.Key.D);
            bool rotateLeft = Keyboard.IsKeyPressed(Keyboard.Key.W);
            bool rotateRight = Keyboard.IsKeyPressed(Keyboard.Key.S);

            bool isMove = moveLeft || moveRight;
            bool isRotate = rotateRight || rotateLeft;


            if (isMove && hasMoved == false)
            {
                if (moveLeft && position.X > 0) position.X -= BLOCK_SPEED;
                if (moveRight && position.X < 560) position.X += BLOCK_SPEED;

            }

            if (isRotate && hasRotated == false)
            {

                if (rotateLeft && position.X < 560) rotation -= BLOCK_ROTATION;
                if (rotateRight && position.X > 0) rotation += BLOCK_ROTATION;
            }

            if (isRotate) hasRotated = true;
            else hasRotated = false;

            if (isMove) hasMoved = true;
            else hasMoved = false;

            bool[] movement = new bool[] {hasRotated, hasMoved};
            return movement;

        }


        public void update() 
        {
            has_done = this.keyHandler(has_done[0], has_done[1]);
            position.Y += 1.5f;
            this.sprite.Position = this.position;
            this.sprite.Rotation = this.rotation;
        }

        public void draw(RenderTarget window)
        {
            window.Draw(this.sprite);
        }

    


    }
}