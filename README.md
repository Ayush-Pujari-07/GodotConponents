# Godot Modular Template

This project is a modular template for Godot 4.x, designed to provide reusable components that can be easily integrated into future Godot projects. The goal is to build a library of basic, working components that promote code reusability and modularity.

## Features

- **Modular Components**: Pre-built, reusable scripts and scenes for common UI and animation functionalities.
- **C# Support**: Utilizes Godot's C# scripting for type safety and performance.
- **Theming**: Includes customizable themes for consistent UI styling.
- **Easy Integration**: Components are designed to be attached or instantiated with minimal setup.

## Setup

1. Ensure you have Godot 4.5+ and .NET 8.0 installed.
2. Clone or download this repository.
3. Open the project in Godot Editor.
4. Build the C# scripts using the integrated build system or via VS Code tasks.

To build from VS Code:
- Use the "build" task in `.vscode/tasks.json`.

## Usage

### Running the Project

- Set the main scene to `MainMenu/main_menu.tscn` in `project.godot`.
- Run the project to see the main menu with animated buttons.

### Adding Components

Components are located in the `MainMenu/Scripts` directory and can be attached to nodes in your scenes.

#### AnimationComponent

A reusable component for adding hover scale animations to Control nodes.

- Attach `MainMenu/Scripts/AnimationComponent.cs` as a child node to any Control (e.g., Button).
- Configure exports in the Inspector:
  - `fromCenter`: Centers the pivot for scaling.
  - `hoverScale`: Target scale on hover (e.g., Vector2(1.2, 1.1)).
  - `delay`: Animation duration in seconds.
  - `transitionType`: Tween transition type.

Example usage in a scene:
```tscn
[node name="Button" type="Button"]
text = "Example Button"

[node name="AnimationComponent" type="Node" parent="."]
script = ExtResource("res://MainMenu/Scripts/AnimationComponent.cs")
hoverScale = Vector2(1.2, 1.1)
delay = 0.5
transitionType = 9
```

## Project Structure

- `MainMenu/`: Contains the main menu scene, scripts, themes, and assets.
- `Scripts/`: Reusable C# scripts (e.g., `AnimationComponent.cs`).
- `Themes/`: UI themes and style boxes for consistent styling.
- `.vscode/`: VS Code configuration for building and launching.

## Contributing

Feel free to add new modular components by following the existing structure. Ensure components are well-documented and reusable.

## License

This project is licensed under the MIT License. See `LICENSE` for details.
