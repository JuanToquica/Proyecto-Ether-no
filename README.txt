Estructura carpetas------------------------------

Assets/
├── Art/
│   ├── Models/
│   ├── Textures/
│   ├── Animations/
├── Audio/
│   ├── Music/
│   ├── SFX/
├── Scripts/
│   ├── Player/
│   ├── Enemies/
│   ├── UI/
├── Prefabs/
├── Scenes/
│   ├── MainMenu.unity
│   ├── Level1.unity
├── Materials/
├── Plugins/
├── Resources/

-------------------------------------------------
Scripts básicos para establecer patrones y evitar desorden:

GameManager: Control de estado global.
InputManager: Manejo centralizado de entrada.
SceneLoader: Cambiar entre escenas.
PlayerController: Movimientos y acciones del jugador.

-------------------------------------------------

Convenciones de nombres--------------------------

Carpetas: Usar PascalCase (e.j., PlayerScripts)
Prefabs: Prefab_EnemyType
Scripts: PlayerMovement.cs, EnemyAI.cs...