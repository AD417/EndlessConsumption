using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;

public class RescalingCamera {
    private OrthographicCamera camera;
    public float Range { get => 1 / camera.Zoom; set => camera.Zoom = 1 / value; }
    public float TargetRange { get; set; }
    public Vector2 Position { get => camera.Position; set => camera.Position = value; }

    public RescalingCamera(ViewportAdapter viewportAdapter) {
        camera = new OrthographicCamera(viewportAdapter);
        Range = 1;
        TargetRange = 1;
    }

    public Matrix GetViewMatrix() => camera.GetViewMatrix();
}