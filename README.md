# SaveSystem
 
Simple save system concept.

Inside the canvas object there are two heroes (PlayerOneTest and PlayerTwoTest) with a HeroStatus component (in the HeroOne/HeroTwo game object) where some data can be tweeked. There are also three buttons for each player which will give the heroes "abilities" that will get stored in their data.

After the data has been tweeked press the "Save ALL Data" button to save. Now you can load your tweeked values with the "Load Game Data".

Game Data can also be tweeked in the "Game Manager" gameobject, but for simplification in this example it will only take effect if its changed outside of runtime.

Improvements can be made regarding different aspects. The one who needs special detail is the codification of how the data get stored so the users cannot easily modify it. Obfuscation techniques such as requiring values from a server to decode/encode the data could be implemented.
