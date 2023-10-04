# Dialogue System Notes
The goal of the project is to have an application that reads from a formatted text file and creates a system of nodes that it them moves through, displaying dialogue and following a scene from node to node. 

## To Do
- Edit the DialogueBuilder so that a scene can have multiple next scenes, and reaching an end will communicate which next scene is correct.

- Fix error where dialogue line gets printed twice if we reach the bottom of the console window and the line is allowed to print out completely

## Classes
Figure out what classes need to be written and what information each class would hold within the system.

### Dialogue Builder
a static class that has methods to instantiate all other class objects in the dialogue system. Will be used to automate instantiating objects for a dialogue scene.

### Dialogue Printer
a static class that handles printing text to screen. Takes a node and can print all of its text or print one character at a time.

### Dialogue Scene
an object that denotes a single "scene" or "conversation"
- Holds refference to the first node in the scene

### Dialogue Node
Holds information about the current step in a dialouge
- who is speaking
- what is being said
- is this the last node in a dialogue
- is there a choice to be made, and if so, how many, what are the choices, what nodes to each choice lead to.

### Dialogue Choice
holds information about an individual choice to be made in the dialogue
- a string that displays what the choice is
- the Dialogue Node that this choice belongs to
- the Dialogue Node that making this choice will lead you to

### Dialogue Node (Basic)
A child of Dialogue Node that specifically handles a single step in the Dialogue System that requires no choices
- what node comes after this one

### Dialogue Node (Choice)
A child of Dialogue Node that specifically handles choices
- How many choices are there
- an array holding each choice
- logic to read user input to determine which choice is chosen

### Dialogue Text
An object that conains the current line of dialogue
- holds a string with the current dialogue

### Speaker
Holds information about the current speaker.
- string speakerName
- reference to an image
    - potentially multiple images if trying to represent various emotions
- text font or text color

### Dialogue Manager
An object that holds the logic to continue through an entire scene, moving from node to node.
- Holds the current node
- Moves on from the current node after user input
- Checks if there is a node to move to after the current node, and either moves to the next node or ends the dialogue of there is no next node
- Displays the dialogue text and current speaker 