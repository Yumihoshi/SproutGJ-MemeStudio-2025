Resonant Steps: A Chorded Aria

*Sprout Game Jam 2025 project*

[![猫猫计数器](https://starry-trace-sky-moe-counter.vercel.app/get/@SproutGJ-MemeStudio-2025?theme=rule34)](https://github.com/StarrySky-skyler/SproutGJ-MemeStudio-2025)

[![编程语言C#](https://img.shields.io/badge/编程语言-CSharp-blue.svg?style=for-the-badge)](#)
[![游戏引擎Unity6000.0.28f1c1](https://img.shields.io/badge/游戏引擎-Unity6000.0.28f1c1-pink.svg?style=for-the-badge)](#)

![游戏截图封面](cover.png)

## Overview

Resonant Steps: A Chorded Aria is a Unity puzzle game built around Sokoban-style box-pushing. Its pixel-art presentation, dialogue-driven story, and varied level mechanics shape a compact adventure in which players move boxes to solve puzzles.

## Technology Stack

- Unity 6000.0.28f1c1 and C#
- Universal Render Pipeline (URP)
- Unity Input System
- Unity Tilemap and Timeline
- Newtonsoft.Json for save data and configuration
- UGUI
- DOTween, Text Animator, IngameDebugConsole, and Pixel Crushers Dialogue System

## Features

- **MVC architecture and data-driven configuration:** Separates model, view, and gameplay responsibilities, with ScriptableObjects used for configuration.
- **State-machine-driven box behavior:** Supports standard boxes, ice-sliding boxes, and teleporting boxes through a shared state-machine system.
- **Level progression and undo:** Organizes level transitions and supports multi-step undo as part of the core puzzle loop.
- **Multiple save slots:** Uses JSON-based save data.
- **Dialogue and text animation:** Integrates Dialogue System and Text Animator for story presentation.
- **Pixel-art presentation:** Organizes art, UI, effects, and audio resources for extension and replacement.

## Project Structure

- `Assets/Scripts/Tsuki/` — Main gameplay code, including MVC components, managers, entities, effects, and interfaces.
- `Assets/Scripts/AnRan12581/` — Framework utilities, singleton patterns, save-system code, and basic interactions.
- `Assets/Scripts/ifancy/` — Shared UI, volume, and scene-transition scripts.
- `Assets/Scenes/Tsuki/` — Level scenes named using the `LevelX-YSceneZ` pattern.
- `Assets/Prefabs/Tsuki/` — Gameplay objects and UI prefabs.
- `Assets/Resources/Tsuki/` — ScriptableObject configuration for game and player models.
- `Assets/StreamingAssets/GameJamSaveSystem/` — Save templates and runtime data.
- `Packages/manifest.json` — Unity package dependencies.

## Build and Run

Open the project in Unity **6000.0.28f1c1** or a compatible Unity 6 installation, then open a gameplay scene under `Assets/Scenes/Tsuki/`. The repository does not specify a single startup scene or standalone build procedure; select the intended scene in Unity before running or building.


# SproutGJ-MemeStudio-2025
萌芽GJ 2025

## 技术栈

- **引擎/语言**: Unity 6000.0.28f1c1 + C#
- **渲染**: Universal Render Pipeline (URP)
- **输入**: Unity Input System（[InputSystem_Actions](https://github.com/Yumihoshi/SproutGJ-MemeStudio-2025/blob/main/Assets/InputSystem_Actions.inputactions)）
- **2D 关卡**: Unity Tilemap
- **序列/流程**: Timeline
- **数据序列化**: Newtonsoft JSON（存档与配置）
- **UI**: UGUI
- **第三方**: DOTween、Text Animator、IngameDebugConsole、Pixel Crushers Dialogue System

## 项目亮点

- **MVC 分层 + ScriptableObject 配置**：逻辑/视图/数据职责清晰，配置资源集中管理（[Models](https://github.com/Yumihoshi/SproutGJ-MemeStudio-2025/blob/main/Assets/Scripts/Tsuki/MVC/Models)）。
- **箱子状态机驱动的核心玩法**：推箱、冰面滑行、传送等统一在状态机中管理（[BoxStateMachine](https://github.com/Yumihoshi/SproutGJ-MemeStudio-2025/blob/main/Assets/Scripts/Tsuki/Entities/Box/FSM/BoxStateMachine.cs)）。
- **关卡流转与撤销**：关卡名解析 + 多步撤销，配合关卡管理器与箱子管理器构成完整玩法循环。
- **存档体系**：多槽位 JSON 存档（[StreamingAssets/GameJamSaveSystem](https://github.com/Yumihoshi/SproutGJ-MemeStudio-2025/blob/main/Assets/StreamingAssets/GameJamSaveSystem)）。
- **对话与文本动画**：Dialogue System + Text Animator 组合实现剧情驱动。
- **像素风资源与特效**：美术资源、UI、特效、音频分层组织，便于扩展与替换。

## 项目结构（重点）

- [Assets/Scripts](https://github.com/Yumihoshi/SproutGJ-MemeStudio-2025/blob/main/Assets/Scripts)
  - **Tsuki**：主玩法代码（MVC、Managers、Entities、Effects、Interfaces）
  - **AnRan12581**：基础框架与工具（Singleton、SaveSystem、基础交互）
  - **ifancy**：UI/音量/场景切换等通用脚本
- [Assets/Scenes](https://github.com/Yumihoshi/SproutGJ-MemeStudio-2025/blob/main/Assets/Scenes)
  - **Tsuki**：按 `LevelX-YSceneZ` 命名的关卡序列
- [Assets/Prefabs](https://github.com/Yumihoshi/SproutGJ-MemeStudio-2025/blob/main/Assets/Prefabs)
  - **Tsuki**：核心对象与 UI 预制体（Boxes/Effects/UI/Managers 等）
- [Assets/Resources](https://github.com/Yumihoshi/SproutGJ-MemeStudio-2025/blob/main/Assets/Resources)
  - **Tsuki**：ScriptableObject 配置（GameModel/PlayerModel）
  - **Music**：背景音乐与音效资源
- [Assets/StreamingAssets](https://github.com/Yumihoshi/SproutGJ-MemeStudio-2025/blob/main/Assets/StreamingAssets)
  - **GameJamSaveSystem**：存档初始模板与运行时数据
- [Assets/Art](https://github.com/Yumihoshi/SproutGJ-MemeStudio-2025/blob/main/Assets/Art)、[Assets/Animations](https://github.com/Yumihoshi/SproutGJ-MemeStudio-2025/blob/main/Assets/Animations)、[Assets/Fonts](https://github.com/Yumihoshi/SproutGJ-MemeStudio-2025/blob/main/Assets/Fonts)
  - 像素风角色/场景/特效/字体资源
- [Packages/manifest.json](https://github.com/Yumihoshi/SproutGJ-MemeStudio-2025/blob/main/Packages/manifest.json)
  - 依赖清单与 Unity 模块版本
