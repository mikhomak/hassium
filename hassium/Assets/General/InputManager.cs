using UnityEngine;

public class InputManager : MonoBehaviour
{
    private float horInput;
    private float verInput;
    public static InputManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void FixedUpdate()
    {
        horInput = Input.GetAxis("Horizontal");
        verInput = Input.GetAxis("Vertical");
    }

    public Vector2 getAxisInputs()
    {
        return new Vector2(horInput, verInput);
    }
}