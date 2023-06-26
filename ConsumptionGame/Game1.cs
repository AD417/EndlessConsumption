using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Devcade;

using ConsumptionGame.App;

// MAKE SURE YOU RENAME ALL PROJECT FILES FROM DevcadeGame TO YOUR YOUR GAME NAME
namespace ConsumptionGame;

public class Game1 : Game
{
	private GraphicsDeviceManager _graphics;
	private SpriteBatch _spriteBatch;
	
	/// <summary>
	/// Stores the window dimensions in a rectangle object for easy use
	/// </summary>
	private Rectangle windowSize;

	private Vector2 PlayerPos;
	private int PlayerSize = 100;
	
	/// <summary>
	/// Game constructor
	/// </summary>
	public Game1()
	{
		_graphics = new GraphicsDeviceManager(this);
		Content.RootDirectory = "Content";
		IsMouseVisible = false;
		Window.AllowUserResizing = true;
	}

	/// <summary>
	/// Performs any setup that doesn't require loaded content before the first frame.
	/// </summary>
	protected override void Initialize()
	{
		// Sets up the input library
		Input.Initialize();

		// Set window size if running debug (in release it will be fullscreen)
		#region Set to Devcade Resolution
#if DEBUG
		_graphics.PreferredBackBufferWidth = 420;
		_graphics.PreferredBackBufferHeight = 980;
		_graphics.ApplyChanges();
#else
		_graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
		_graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
		_graphics.ApplyChanges();
#endif
		#endregion
		
		// TODO: Add your initialization logic here

		windowSize = GraphicsDevice.Viewport.Bounds;
		
		base.Initialize();
	}

	/// <summary>
	/// Performs any setup that requires loaded content before the first frame.
	/// </summary>
	protected override void LoadContent()
	{
		_spriteBatch = new SpriteBatch(GraphicsDevice);
		Display.Initialize(_spriteBatch);

		Asset.Player = Content.Load<Texture2D>("PlayerCircle");
		Asset.Edible = Content.Load<Texture2D>("Edible");
	}

	/// <summary>
	/// Your main update loop. This runs once every frame, over and over.
	/// </summary>
	/// <param name="gameTime">This is the gameTime object you can use to get the time since last frame.</param>
	protected override void Update(GameTime gameTime)
	{
		Input.Update(); // Updates the state of the input library

		// Exit when both menu buttons are pressed (or escape for keyboard debugging)
		// You can change this but it is suggested to keep the keybind of both menu
		// buttons at once for a graceful exit.
		if (Keyboard.GetState().IsKeyDown(Keys.Escape) ||
			(Input.GetButton(1, Input.ArcadeButtons.Menu) &&
			Input.GetButton(2, Input.ArcadeButtons.Menu)))
		{
			Exit();
		}

		KeyboardState keys = Keyboard.GetState();

		if (keys.IsKeyDown(Keys.W) || keys.IsKeyDown(Keys.Up)) PlayerPos.Y--;
		if (keys.IsKeyDown(Keys.S) || keys.IsKeyDown(Keys.Down)) PlayerPos.Y++;
		if (keys.IsKeyDown(Keys.A) || keys.IsKeyDown(Keys.Left)) PlayerPos.X--;
		if (keys.IsKeyDown(Keys.D) || keys.IsKeyDown(Keys.Right)) PlayerPos.X++;

		PlayerSize++;
		if (PlayerSize > 150) PlayerSize = 50;

		// TODO: Add your update logic here

		base.Update(gameTime);
	}

	/// <summary>
	/// Your main draw loop. This runs once every frame, over and over.
	/// </summary>
	/// <param name="gameTime">This is the gameTime object you can use to get the time since last frame.</param>
	protected override void Draw(GameTime gameTime)
	{
		GraphicsDevice.Clear(Color.Black);
		
		// Batches all the draw calls for this frame, and then performs them all at once
		_spriteBatch.Begin();
		
		Display.Player(PlayerPos, PlayerSize);
		
		_spriteBatch.End();

		base.Draw(gameTime);
	}
}