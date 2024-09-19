# The Great Escape: Miner's Revenge - Game Planning Document

## 1. Story and Setting

### 1.1 Backstory
- Player character is a mining worker unjustly punished and locked in a cave
- The cave entrance is sealed by a massive, fortified door
- The goal is to escape by drilling through this door, which requires an enormous drill

### 1.2 Game World
- Start in a small chamber with the sealed entrance and a workbench
- Vast cave system filled with various minerals and obstacles
- Hidden caches of advanced mining technology and additional blueprints left by previous workers

## 2. Core Gameplay Mechanics

### 2.1 Blueprint System
- Game starts with player finding an initial blueprint for a basic drill
- Blueprint tab unlocks upgrade tree, showing possible future upgrades
- Additional blueprints can be found throughout the cave, unlocking new upgrade paths

### 2.2 Workbench Mechanics
- Central workbench in starting area used for crafting and upgrades
- Player must return to workbench to apply collected resources and create upgrades
- Workbench interface shows available upgrades based on collected blueprints and resources

### 2.3 Mining and Movement

#### 2.3.1 Mining Mechanics
- Each mineral type has a base mining time
- Drill efficiency affects actual mining time
- Mining formula: Actual Mining Time = Base Mining Time / Drill Efficiency
- Different rock types with varying hardness affecting base mining time

#### 2.3.2 Movement
- Initial movement is at base walking speed
- Player can craft a mining vehicle to increase base movement speed
- Vehicle can be upgraded for further speed improvements
- Carrying minerals decreases movement speed incrementally based on total weight
- Movement speed formula: Actual Speed = Base Speed * (1 - (Current Weight / Max Capacity))

### 2.4 Resource Management
- Collect various minerals required for upgrades
- Each mineral type has a specific weight
- Manage limited cargo space and weight capacity
- Balance between carrying capacity and movement speed

### 2.5 Drill Upgrades
- Start by crafting a small, basic drill using the initial blueprint
- Upgrade drill size progressively (1x1 -> 2x2 -> 3x3 -> etc.) as new blueprints are found
- Improve drill efficiency to reduce mining time
- Final goal: Construct the enormous drill capable of breaking through the door

### 2.6 Navigation
- Limited vision (initially 3 surrounding tiles, can be upgraded)
- Minimap or radar system (unlocked/upgraded later)

## 3. Cave System Design

### 3.1 Cave Structure
- Procedurally generated cave system branching out from the starting point
- Increasing difficulty and resource rarity as player ventures deeper
- Hidden areas containing rare minerals, upgrade components, or new blueprints

### 3.2 Resource Distribution
- Common minerals near the starting area with shorter base mining times and lower weights
- Rarer, more valuable resources in hard-to-reach areas with longer base mining times and higher weights
- Strategic placement of lighter, less valuable minerals for easier initial progress
- Blueprints hidden in challenging locations

### 3.3 Obstacles and Hazards
- Dense rock formations requiring upgraded drills
- Unstable areas that can cause cave-ins
- Old mining equipment that can be salvaged for parts or blueprints

## 4. Upgrade System

### 4.1 Blueprint-based Upgrades
- Each upgrade requires a corresponding blueprint
- Blueprints reveal resource requirements and potential benefits of upgrades

### 4.2 Drill Upgrades
- Size increases (main progression path)
- Efficiency improvements (reduces mining time)

### 4.3 Vehicle Upgrades
- Initial vehicle crafting blueprint
- Speed improvements (increases base speed)
- Weight capacity increases (allows carrying more minerals with less speed penalty)
- Maneuverability enhancements

### 4.4 Utility Upgrades
- Vision range improvements
- Cargo capacity increases

### 4.5 Special Abilities
- Scanner for detecting resources and blueprints

## 5. Progression System

### 5.1 Blueprint Discovery
- Finding new blueprints serves as major progression points
- Each new blueprint unlocks potential for accessing new areas or resources

### 5.2 Milestone Upgrades
- Major drill upgrades allow access to new areas of the cave
- Vehicle crafting and upgrades serve as movement milestones

### 5.3 Narrative Elements
- Discover logs or messages from other trapped miners
- Uncover the truth behind the player's imprisonment as they explore

### 5.4 Achievements
- Milestones for blueprints found, areas explored, resources collected, upgrades applied
- Special achievements for efficient drilling, fast mineral extraction, or discovery of hidden areas
- Vehicle-related achievements (speed records, distance traveled)

## 6. User Interface

### 6.1 HUD (Heads-Up Display)
- Cargo weight indicator (current weight / max capacity)
- Current movement speed
- Current drill size, efficiency, and upgrade progress
- Vehicle speed and status (if crafted)
- Minimap (if unlocked)
- Blueprint discovery notifications
- Current mineral mining progress and estimated time

### 6.2 Menus
- Main menu (New Game, Load Game, Options, Exit)
- Pause menu
- Blueprint and upgrade menu (shows collected blueprints, available and locked upgrades)
- Workbench interface for crafting and upgrading
- Cave map screen (reveals explored areas and found blueprints)
