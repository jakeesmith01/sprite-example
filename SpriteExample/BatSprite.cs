using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Threading;

namespace SpriteExample
{

    public enum Direction
    {
        Down = 0,
        Right = 1,
        Up = 2,
        Left = 3
    }

    /// <summary>
    /// A class representing a bat sprite
    /// </summary>
    public class BatSprite
    {
        /// <summary>
        /// The texture of the bat
        /// </summary>
        private Texture2D texture;

        /// <summary>
        /// Timer for updating the direction of the bat
        /// </summary>
        private double directionTimer;

        /// <summary>
        /// Timer for updating the animation of the bat
        /// </summary>
        private double animationTimer;

        /// <summary>
        /// The current frame of the bat
        /// </summary>
        private short animationFrame = 1;

        /// <summary>
        /// Direction of the bat
        /// </summary>
        public Direction Direction;

        /// <summary>
        /// Position of the bat
        /// </summary>
        public Vector2 Position;

        /// <summary>
        /// Loads the content of the texture for the bat
        /// </summary>
        /// <param name="content"></param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("32x32-bat-sprite");
        }

        /// <summary>
        /// Updates the bat's position and direction
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            // Update the direction timer
            directionTimer += gameTime.ElapsedGameTime.TotalSeconds;

            // Switch direction every 2 seconds
            if (directionTimer > 2)
            {
                switch (Direction)
                {
                    case Direction.Up:
                        Direction = Direction.Down;
                        break;
                    case Direction.Down:
                        Direction = Direction.Right;
                        break;
                    case Direction.Right:
                        Direction = Direction.Left;
                        break;
                    case Direction.Left:
                        Direction = Direction.Up;
                        break;
                    default:
                        break;
                }

                directionTimer -= 2.0;
            }

            //Move the bat
            switch (Direction)
            {
                case Direction.Up:
                    Position += new Vector2(0, -1) * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case Direction.Down:
                    Position += new Vector2(0, 1) * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case Direction.Right:
                    Position += new Vector2(1, 0) * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case Direction.Left:
                    Position += new Vector2(-1, 0) * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// Draw method for the animated bat sprite
        /// </summary>
        /// <param name="gameTime">The game time</param>
        /// <param name="spriteBatch">the spritebatch to draw with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //Update animation timer
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

            //Update animation frame
            if(animationTimer > 0.3)
            {
                animationFrame++;
                if (animationFrame > 3) animationFrame = 1;
                animationTimer -= 0.3;

            }

            //Draw the sprite
            var source = new Rectangle(animationFrame * 32, (int)Direction * 32, 32, 32);
            spriteBatch.Draw(texture, Position, source, Color.White);
        }

    }

    
}
