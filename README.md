# Learning-unity-developement
-14th.Feb.2025 ~ 17th.Feb.2025 : Started watching YouTube tutorial video from 'Nomad Coder'.
  It's mainly about following every step and making the duplicate of 'Kimchi-Run'.
  I didn't really know about Unity engine and C# language, so I just decided to learn by 'Learn by doing' method.
  The language itself had some similarities with the C language which I learned from the last semester's class.
  And the Unity engine's UI was not that familiar, but for some reasons it reminded me of Cinema4D's UI.

~3rd.march
 mixed the kimchi run score system and an example practice game fore 유니티 교과서, making my own ui deigns and adding healing packs
 and animations.
 learning SetActive() method and button functions and codes in Unity was quite simple but very useful.
 After about 2weeks since I started learning Unity, I was able to build my very first original game called "Yun's Blade Rain".
 It's simple and has a lot of mixed code structures from the examples I learned, but I utilized those structures since they were very basic
 codes in order to make the game works, naking them my own codes. Thanks to the Nomad Coder and the book "유니티 교과서".

Unity Development Log (March 6 - March 10)
March 6 - March 10
Studied Chapter 6 of the Unity Textbook (ClimbCloud).
Rigidbody2D rigid2D; must be declared as a variable first, then assigned an instance using GetComponent at the start.
Used a key variable to return 1 for the right arrow key and -1 for the left arrow key. When applying AddForce with Vector3, setting the x-coordinate value to key determines the movement direction based on the sign. The character’s image also flips accordingly.

March 10 (After 11 PM)
Implemented camera movement following player movement by writing a CameraController script.
Passed the player’s coordinates (transform.position) to a Vector3 variable (playerPos).
The object with this script as a component does not need to call a separate variable but can directly assign:
csharp
transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
This automatically adjusts the camera’s Y position based on the player's Y coordinate.
Collision detection is divided into collision mode and trigger mode.
Functions include OnCollisionEnter2D and OnTriggerEnter2D, with collision states categorized as:
Enter (collision starts)
Stay (ongoing collision)
Exit (collision ends)
For collision detection only: Both objects must have Colliders, but only one needs a Rigidbody.
For physical interactions after collision: Both objects must have Rigidbody and Colliders.
