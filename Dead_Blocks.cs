using SFML.Graphics;
using SFML.System;


namespace Cat_Tetris_i_hope
{
    class DeadBlock
    {
        private Sprite sprite;
        Vector2f position;
        float rotation;
        public Sprite DeadBlockSprite { get { return sprite; } }
        public Vector2f Position { get { return position; } }
        public float Rotation { get { return rotation; } }

        public DeadBlock(Block block)
        {
            this.sprite = new Sprite();
            this.sprite.Texture = block.BlockSprite.Texture;
            this.position = block.Position;
            this.rotation = block.Rotation;
            this.sprite.Position = this.position;
            this.sprite.Rotation = this.rotation;
        }

        public DeadBlock()
        {
            this.sprite = new Sprite();
            this.sprite.Texture = TextureManager.EmptyTexture;
            this.position.Y = 480;
            this.position.X = -40;
            this.rotation = 0;
            this.sprite.Position = this.position;
            this.sprite.Rotation = this.rotation;
        }

 
        public void draw(RenderTarget window)
        {
            window.Draw(this.sprite);
        }

    }
}