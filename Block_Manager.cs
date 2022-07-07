using SFML.Graphics;

namespace Cat_Tetris_i_hope
{
   class BlockManager
    {
        public Block block = new Block();
        public List<DeadBlock> deadblocks = new List<DeadBlock>();
        public bool end = false;

        
        public BlockManager()
        {
            deadblocks.Add(new DeadBlock());
        }

        public void update()
        {
            block.update();


            for (int i = 0; i < deadblocks.Count; i++)
            {
                if (IsCollision(deadblocks[i], block))
                {
                    if (block.Position.Y > 20)
                    {
                        deadblocks.Add(new DeadBlock(block));
                        block = new Block();
                    }
                    else
                    {
                        end = true;
                    }

                }

            }

        }

        public bool IsCollision(DeadBlock deadblock, Block block)
        {
            if (block.BlockSprite.GetGlobalBounds().Intersects(deadblock.DeadBlockSprite.GetGlobalBounds()))
            {              
                return true;
            }
            else
            {
                return false;
            }
           
        }


        public void draw(SFML.Graphics.RenderTarget window)
        {

            block.draw(window);

            for (int i = 0; i < deadblocks.Count; i++)
            {
                deadblocks[i].draw(window);
            }
        }

        public void endGame(RenderWindow window)
        {
            window.Close();
        }
    }
}