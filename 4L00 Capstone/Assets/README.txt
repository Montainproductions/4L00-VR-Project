# Intro

Welcome to the 4L00 project README file. This README is meant for the newer programers that might not have as much experience with how the files are setup, the naming conventions used, and how to operate the github repo.

## Folder system

### Audio

Contains all of the audio files that will be used throughout the project.

### Example Assets 

Some base VR controllers that the player uses with related materials and models. (Wont need to touch this folder).

### Materials

Some basic materials and player physics that can be used to create some contrast with basic objects.

### Models

Diffrent models given from the art team. They dont contain any scripts attached to the objects so once if something special is needed then add corisponding scripts to the object or check in prefab folder for it.

### Oculus

Base Package that is provided by oculus with a working VR object and scenes to test things out in VR. (Wont need to touch this folder).

### Prefabs

Premade objects that already contain all of their necesary scripts and other components attached. If something is needed from this folder you can drag and drop where you need it and it should appear.

### Resources

VR platform things (Wont need to touch this folder).

### Samples

Some defult XR/VR items that run the VR controller. (Wont need to touch this folder).

### Scenes

Contains all the scenes in the project. Each scene being a "World" which contains a set of models and scripts already in the world that interact with each other in a certain way.

### Scripts

Contains all of the current scripts that were created in the project which can be used on object.
This is were you would create new scripts though it is recomended that you also read through the programming conventions tab below which explains in more detail how everything is organized.

### TextMeshPro

A folder containing a text related objects that can be used to make better looking text for UI and other areas.

### XR

Some basic XR settings that came with the Oculus package (Wont need to touch this folder).

### XRI

Simillar to the XR folder this controllers the interaction for XR systems that came with the Oculus package. (Wont need to touch this folder).

### Input System

The new input system that Unity created a few years ago that helps control the VR head set. (Wont need to touch this folder).

## Programming conventions

### Basic Compositions of script

When naming a new script make sure to call it a Sc_NameOfScript so that the other programmers know what script was created by programmers and what scripts might be part of the oculus integration information

Libaries:
A list of Unity libraies that are being used for that certain script.

Class:
The class/script name and if it is a monobehaviour script or if it inherits from another script.

Variables:
A list of global variables that are being used through out the script and can appear in the component section for the script for the objects.

Follow this convention:

//This headders help better divide sections of variables and group them depending on what they are used for. For example all of the lights variables will be grouped together under the "Lights" header while additional options that normally arented needed would be under the "Additional options" header.
[Header("")]

//Only if you want this to appear as part of the component script when attached to an object but the variable is normally privated.
[SerializeField]
//Private means that it cant be touch by other scripts and wont normally appear in the component of the script when attached to an object. While public allows it to be accessed in other scripts and will nromally appear as part of the script component when attached to a object.
//datatype is what the variable will be (Examples: light, float, bool, etc). If a [] appears at the end of the datatype then it is an array which contains multiple of that datatype. 
//variableName is what the variable will be called through out the script, normal conventions has the name in a camle case format where all letter are lower case and all first letters of words (except the first letter of variable) are upper case.
private/public datatype variableName

Common Methods:
//The awake method is meant to run the first frame that it is created and tends to be used to search for certain components or objects that might be needed for other sections of the script.
public void Awake(){}

//The start method which tends to occur the first couple of frames it exists and normally is used to set up variable values that might not of been set up on the component section of the script on the object.
public void Start(){}

//This will run each frame that the project is running and tends to be used for continuasly checking for certain variables to be met and to run other methods if things are met.
public void Update(){}

//Each frame that the physics engine is being runed. Is controlled so it wont occure more or less times depending on the hardware that the project is being run on. Wont normally be used unless something realted to the physics is being used in the script.
//Whenever creating a new method make sure you add a comment that explains what the method is doing so that other people can know roughly what it is doing. C# comments work by placing "//" in front of each line you wish to have commented.
public void FixedUpdate(){}

//Aditional methods that were created that help complete the task related to the script. This methods help spread out the code into more reausable bitsize chuncks of code instead of having it all be part of one update method.
//Methods are normally named with all the first letters of words as uppercase letter while the rest are lowercase letters.
private/public void OtherMethods(){}

//All the OnTrigger variations work on checking wether another object is interacting with the object that the script is attached to or if it has recently started or finished interacting.
public void OnTrigger...(){}

### Extra things

when writing a section for/if/while loops and creating the indentation make sure the "{" is on the same line of the initial statement as seen in example below.

if(){
/*
*Sudo code
*/
}