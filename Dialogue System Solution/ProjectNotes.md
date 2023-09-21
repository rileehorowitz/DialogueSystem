# Dialogue System Notes
The goal of the project is to have an application that reads from a formatted text file and creates a system of nodes that it them moves through, displaying dialogue and following a scene from node to node. 

## To Do
- When automating the creation of Dialogue Objects as you read from a file, use a dictionary with string keys that hold the value of different object types so that you can dynamically assign names.

- At the moment, project is on the tightly coupled side, try to go through and make it loosely coupled by putting in safety checks for errors. (What if something empty is passed in? What if this ends up being null when it's not supposed to be?)

- Change where the manager and nodes check for input before accessing the next node

- Alter the wait time on the WriteText method to give greater pause to punctuation rather than letters or numbers.

- Alter the wait time to speed up rather than fully skip

## Classes
Figure out what classes need to be written and what information each class would hold within the system.


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