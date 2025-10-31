using Fusion;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SerializeField] private float _speed = 1.0f;

    private Vector2 _networkedMovement = Vector2.zero;

    [Networked] private Color PlayerColor { get; set; }

    public override void Spawned()
    {
        GameStartController.OnInputEvent += GameStartController_OnInputEvent;
    }

    public override void Despawned( NetworkRunner runner, bool hasState )
    {
        GameStartController.OnInputEvent -= GameStartController_OnInputEvent;
    }

    private void GameStartController_OnInputEvent( NetworkRunner runner, NetworkInput input ) //Send data here
    {
        if( !HasInputAuthority )
        {
            return;
        }

        Vector2 movement = Vector2.zero;
        bool request_color = false;

        if( Input.GetKey( KeyCode.A ) )
        {
            movement.x = -1f;
        }
        if( Input.GetKey( KeyCode.D ) )
        {
            movement.x = 1f;
        }
        if( Input.GetKey( KeyCode.W ) )
        {
            movement.y = 1f;
        }
        if( Input.GetKey( KeyCode.S ) )
        {
            movement.y = -1f;
        }

        if( Input.GetKeyDown( KeyCode.Space ) )
        {
            request_color = true;
        }

        PlayerInputs inputs = new PlayerInputs()
        {
            Movement = movement,
            RequestColorChange = request_color
        };

        input.Set( inputs );
    }

    public override void FixedUpdateNetwork() //Store data here
    {
        if( !HasStateAuthority )
        {
            return;
        }

        PlayerInputs? inputs = GetInput<PlayerInputs>() ;

        if( !inputs.HasValue )
        {
            return;
        }

        PlayerInputs value = inputs.Value;

        _networkedMovement = value.Movement;

        if( value.RequestColorChange )
        {
            PlayerColor = Random.ColorHSV();
        }
    }

    public override void Render() // Apply data here
    {
        if( !HasStateAuthority )
        {
            return;
        }

        transform.position += new Vector3( _networkedMovement.x, 0.0f, _networkedMovement.y ) * _speed * Time.deltaTime;
    }

    public struct PlayerInputs : INetworkInput
    {
        public Vector2 Movement;
        public bool RequestColorChange;
    }
}
