using UnityEngine;

public interface IMove
{
    public void Move(Vector2 input);
    public float speed { get; set; }
    public void ResetSpeed();
}
