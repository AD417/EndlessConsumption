using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Devcade;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;

using ConsumptionGame.App;
using ConsumptionGame.App.Util;
using ConsumptionGame.Render;

// MAKE SURE YOU RENAME ALL PROJECT FILES FROM DevcadeGame TO YOUR YOUR GAME NAME
namespace ConsumptionGame;

public class Game1 : Game
{
	private GraphicsDeviceManager _graphics;
	private SpriteBatch _spriteBatch;
	private OrthographicCamera _camera;
	
	/// <summary>
	/// Stores the window dimensions in a rectangle object for easy use
	/// </summary>
	private Rectangle windowSize;
	
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
		EdibleContainer.Initialize();

		// Set window size if running debug (in release it will be fullscreen)
		#region Set to Devcade Resolution
		ViewportAdapter viewport;
#if DEBUG
		_graphics.PreferredBackBufferWidth = 420;
		_graphics.PreferredBackBufferHeight = 980;
		_graphics.ApplyChanges();
		viewport = new BoxingViewportAdapter(Window, GraphicsDevice, 420, 980);
#else
		_graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
		_graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
		_graphics.ApplyChanges();
		viewport = new BoxingViewportAdapter(
				Window, 
				GraphicsDevice, 
				GraphicsDevice.DisplayMode.Width, 
				GraphicsDevice.DisplayMode.Height
		)
#endif
		#endregion
		_camera = new OrthographicCamera(viewport);
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

		// Avoiding CS1612. I hate it.
		Player p = EdibleContainer.PlayingEdible;

		if (keys.IsKeyDown(Keys.W) || keys.IsKeyDown(Keys.Up)) p.Move(0, -1);
		if (keys.IsKeyDown(Keys.S) || keys.IsKeyDown(Keys.Down)) p.Move(0, 1);
		if (keys.IsKeyDown(Keys.A) || keys.IsKeyDown(Keys.Left)) p.Move(-1, 0);
		if (keys.IsKeyDown(Keys.D) || keys.IsKeyDown(Keys.Right)) p.Move(1, 0);
		EdibleContainer.Update(gameTime);
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
		Matrix transformMatrix = _camera.GetViewMatrix();
		_spriteBatch.Begin(transformMatrix: transformMatrix);
		
		Display.Player(EdibleContainer.PlayingEdible);
		foreach (Edible e in EdibleContainer.Edibles) {
			Display.Edible(e);
		}

		_spriteBatch.End();

		base.Draw(gameTime);
	}
}